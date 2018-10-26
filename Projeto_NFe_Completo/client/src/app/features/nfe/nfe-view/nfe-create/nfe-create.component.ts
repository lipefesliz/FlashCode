import { Destinatario } from './../../../destinatario/shared/destinatario.model';
import { Component, OnInit, Input } from '@angular/core';
import { NfeService } from '../../shared/nfe.service';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Emitente } from '../../../emitente/shared/emitente.model';
import { Transportador } from './../../../transportador/shared/transportador.model';
import { Produto } from '../../../produto/shared/produto.model';

import { EmitenteService } from '../../../emitente/shared/emitente.service';
import { DestinatarioService } from './../../../destinatario/shared/destinatario.service';
import { TransportadorService } from '../../../transportador/shared/transportador.service';
import { ProdutoService } from './../../../produto/shared/produto.service';
import { NfeRegisterCommand } from '../../shared/nfe.model';

@Component({
    templateUrl: './nfe-create.component.html',
    styles: ['./_styles.scss'],
})
export class NfeCreateComponent implements OnInit {

    public isLoading: boolean;
    public emitentes: Emitente[];
    public destinatarios: Destinatario[];
    public transportadores: Transportador[];
    public produtos: Produto[];
    public defaultItem: any = { nome: 'Selecione...', descricao: 'Selecione...' };
    public total: number = 0;

    public formModel: FormGroup = this.fb.group({
        naturezaOperacao: ['', [Validators.required]],
        frete: ['', [Validators.required]],
        emitenteId: ['', [Validators.required]],
        destinatarioId: ['', [Validators.required]],
        transportadorId: ['', [Validators.required]],
        produtosNota: this.fb.array([], Validators.required),
        quantidade: ['1'],
    });

    private produtoSelecionado: Produto;
    private listaProdutos: number[] = [];
    private listaQuantidades: number[] = [];
    private data: any;
    private nfe: NfeRegisterCommand;
    private gridData: any[] = [];
    private valoresProdutos: Produto[] = [];
    constructor(private nfeService: NfeService,
        private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute,
        private emitenteService: EmitenteService,
        private destinatarioService: DestinatarioService,
        private transportadorService: TransportadorService,
        private produtoService: ProdutoService) {
    }

    public ngOnInit(): void {
        this.formModel.valueChanges.subscribe(() => {
            this.calcularTotal();
        });
    }
    public save(): void {
        this.nfe = new NfeRegisterCommand(this.formModel.value);

        this.isLoading = true;

        this.nfeService.add(this.nfe)
            .take(1)
            .finally(() => this.isLoading = false)
            .subscribe((nfeId: number) => {
                alert('Salvo com sucesso');
                this.redirect();
            });
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    //#region Emitente
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
    //#endregion

    // #region Destinatario
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

    //#endregion

    //#region Trasnportador
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
    //#endregion
    public addProduto(): void {
        if (this.validateProdutosDuplicados()) {
            const quantidade: number = this.formModel.get('quantidade').value;
            this.produtoSelecionado.quantidade = quantidade;
            const control: FormArray = this.formModel.get('produtosNota') as FormArray;
            control.push(this.createProdutos(this.produtoSelecionado));

            this.gridData.push(this.produtoSelecionado);
            this.formModel.updateValueAndValidity();
            this.valoresProdutos.push(this.produtoSelecionado);

            this.calcularTotal();
        } else {
            alert('Produto já adicionado');
        }
    }

    public onSelectProduto(produto: Produto): void {
        this.produtoSelecionado = produto;
    }

    public onFilterProduto(nome: any): void {
        this.isLoading = true;
        this.produtoService.getByName(nome).subscribe((produtos: Produto[]) => {
            this.produtos = produtos;
            this.isLoading = false;
        });
    }

    public clearAll(): void {
        this.gridData = [];
        this.listaProdutos = [];
        const control: FormArray = this.formModel.get('produtosNota') as FormArray;
        control.reset();
        this.total = 0;

    }

    private calcularTotal(): void {
        const valueFrete: number = this.formModel.get('frete').value;

        let valoresProdutos: number = 0;

        for (const item of this.valoresProdutos) {
            if (item.valor > 0) {
                valoresProdutos = (valoresProdutos + (item.valor * item.quantidade));
            }
        }

        this.total = (valueFrete + valoresProdutos);
    }

    private createProdutos(produto: Produto): FormGroup {
        return this.fb.group({
            produtoId: [produto.id, Validators.required],
            quantidade: [produto.quantidade, Validators.required],
        });
    }

    private validateProdutosDuplicados(): boolean {
        for (const produto of this.valoresProdutos) {
            if (produto.id === this.produtoSelecionado.id) {
                return false;
            }
        }

        return true;
    }
}
