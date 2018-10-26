import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { NfeEditCommand, NfeViewModel, Nfe } from '../../shared/nfe.model';
import { Emitente } from '../../../emitente/shared/emitente.model';
import { Destinatario } from '../../../destinatario/shared/destinatario.model';
import { Transportador } from '../../../transportador/shared/transportador.model';
import { Produto } from '../../../produto/shared/produto.model';

import { NfeService, NfeResolveService } from '../../shared/nfe.service';
import { EmitenteService } from '../../../emitente/shared/emitente.service';
import { DestinatarioService } from '../../../destinatario/shared/destinatario.service';
import { TransportadorService } from '../../../transportador/shared/transportador.service';
import { ProdutoService } from '../../../produto/shared/produto.service';

@Component({
    templateUrl: './nfe-edit.component.html',
})
export class NfeEditComponent implements OnInit {

    public isLoading: boolean;
    public nfe: NfeEditCommand;
    public emitentes: Emitente[];
    public destinatarios: Destinatario[];
    public transportadores: Transportador[];
    public produtos: Produto[];
    public total: number = 0;
    public totalOriginal: number = 0;
    public defaultItemEmitente: any;
    public defaultItemTrasportador: any;
    public defaultItemDestinatario: any;
    public formModel: FormGroup = this.fb.group({
        id: [''],
        naturezaOperacao: ['', [Validators.required]],
        frete: ['', [Validators.required]],
        emitenteId: ['', [Validators.required]],
        destinatarioId: ['', [Validators.required]],
        transportadorId: ['', [Validators.required]],
    });
    private gridData: any[] = [];
    private produtoSelecionado: Produto;
    private listaProdutos: number[] = [];
    private data: any;

    constructor(private service: NfeService,
        private serviceResolver: NfeResolveService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute,
        private emitenteService: EmitenteService,
        private destinatarioService: DestinatarioService,
        private transportadorService: TransportadorService,
        private produtoService: ProdutoService) {
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.serviceResolver.onChanges.take(1).subscribe((nfe: any) => {
            this.isLoading = false;
            this.nfe = Object.assign(new NfeEditCommand(nfe), nfe);
            this.populateDefaulItens(nfe);
            this.patchValueFormModel(nfe);
            this.total = nfe.valor.totalNota;
            this.totalOriginal = nfe.valor.totalNota;
        });

        this.formModel.valueChanges.subscribe(() => this.calculateTotal());
    }

    public save(): void {
        this.nfe = new NfeEditCommand(this.formModel.value);
        this.isLoading = true;
        this.service.edit(this.nfe)
            .take(1)
            .finally(() => this.isLoading = false)
            .subscribe((response: boolean) => {
                alert('Salvo com sucesso');
                this.redirect();
                this.serviceResolver.resolveFromRouteAndNotify();
            });
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public onFilterEmitente(nome: any): void {
        this.isLoading = true;
        this.emitenteService.getByName(nome).subscribe((emitentes: Emitente[]) => {
            this.emitentes = emitentes;
            this.isLoading = false;
        });
    }

    public onSelectEmitente(emitente: Emitente): void {
        this.formModel.patchValue({ emitenteId: emitente.id });
    }

    public onFilterDestinatario(nome: any): void {
        this.isLoading = true;
        this.destinatarioService.getByName(nome).subscribe((destinatarios: Destinatario[]) => {
            this.destinatarios = destinatarios;
            this.isLoading = false;
        });
    }

    public onSelectDestinatario(destinatario: Destinatario): void {
        this.formModel.patchValue({ destinatarioId: destinatario.id });
    }

    public onFilterTransportador(nome: any): void {
        this.isLoading = true;
        this.transportadorService.getByName(nome).subscribe((transportadores: Transportador[]) => {
            this.transportadores = transportadores;
            this.isLoading = false;
        });
    }

    public onSelectTransportador(transportador: Transportador): void {
        this.formModel.patchValue({ transportadorId: transportador.id });
    }

    public addProduto(): void {
        this.gridData.push(this.produtoSelecionado);
    }

    public onSelectProduto(produto: Produto): void {
        this.listaProdutos.push(produto.id);
        this.formModel.patchValue({ produtoId: this.listaProdutos });
        this.produtoSelecionado = produto;
    }

    public onFilterProduto(nome: any): void {
        this.isLoading = true;
        this.produtoService.getByName(nome).subscribe((produtos: Produto[]) => {
            this.produtos = produtos;
            this.isLoading = false;
        });
    }

    private populateDefaulItens(nfe: Nfe): void {
        this.defaultItemEmitente = { nome: nfe.emitente.nome };
        this.defaultItemDestinatario = { nome: nfe.destinatario.nome };
        this.defaultItemTrasportador = { nome: nfe.transportador.nome };
    }

    private calculateTotal(): any {
        const valorFrete: number = this.formModel.get('frete').value;
        this.total = this.totalOriginal + valorFrete;
    }
    private patchValueFormModel(nfe: any): any {
        this.formModel.patchValue(nfe);
        this.formModel.patchValue({
            emitenteId: nfe.emitente.id,
            transportadorId: nfe.transportador.id,
            destinatarioId: nfe.destinatario.id,
            frete: this.nfe.frete,
        });
        this.formModel.updateValueAndValidity();
    }
}
