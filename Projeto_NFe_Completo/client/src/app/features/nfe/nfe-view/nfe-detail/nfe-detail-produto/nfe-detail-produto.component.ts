import { Component, OnInit } from '@angular/core';
import { GridUtilsComponent } from '../../../../../shared/grid-utils/grid-utils-component';
import { NfeProdutoGridService } from '../../../shared/nfe-grid.service';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { NfeService, NfeResolveService } from '../../../shared/nfe.service';
import { ProdutoService } from '../../../../produto/shared/produto.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Produto } from '../../../../produto/shared/produto.model';
import { ProdutoNotaCommand, ProdutoNotaRemoveCommand } from '../../../shared/nfe.model';
@Component({
    templateUrl: './nfe-detail-produto.component.html',
})
export class NfeDetailProdutoComponent extends GridUtilsComponent implements OnInit {

    public nfeId: number;
    public produtoSelecionado: Produto;
    public produtos: Produto[] = [];
    public defaultItem: any = { nome: 'Selecione...', descricao: 'Selecione...' };
    public isLoading: boolean;
    public formModel: FormGroup = this.fb.group({
        quantidade: ['1', Validators.required],
    });
    constructor(private nfeProdutoService: NfeProdutoGridService,
        private serviceResolver: NfeResolveService,
        private nfeService: NfeService,
        private produtoService: ProdutoService,
        private fb: FormBuilder) {
        super();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.serviceResolver.onChanges.take(1).subscribe((nfe: any) => {
            this.isLoading = false;
            this.nfeId = nfe.id;
            this.nfeProdutoService.query(this.createFormattedState(), this.nfeId);
        });
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.nfeProdutoService.query(this.createFormattedState(), this.nfeId);
        this.selectedRows = [];
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }

    public deleteNfe(): void {
        this.isLoading = true;
        const nfeCommand: ProdutoNotaRemoveCommand = new ProdutoNotaRemoveCommand(this.nfeId, this.getSelectedEntities());
        this.nfeService.removeProdutos(nfeCommand).take(1).subscribe((result: boolean) => {
            this.selectedRows = [];
            this.isLoading = false;
            this.nfeProdutoService.query(this.createFormattedState(), this.nfeId);
            if (result) {
                alert('Deletado com sucesso');
            } else {
                alert('Erro ao deletar');
            }
        });

    }

    public addProduto(): void {
        const quantidade: number = this.formModel.get('quantidade').value;
        this.produtoSelecionado.quantidade = quantidade;
        this.formModel.updateValueAndValidity();

        this.addProdutoFromApi();

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
    private addProdutoFromApi(): any {
        this.isLoading = true;
        const produtoNota: ProdutoNotaCommand = new ProdutoNotaCommand();
        produtoNota.produtoId = this.produtoSelecionado.id;
        produtoNota.notaFiscalId = this.nfeId;
        produtoNota.quantidade = this.produtoSelecionado.quantidade;

        this.nfeService.addProduto(produtoNota)
            .take(1)
            .finally(() => this.isLoading = false)
            .subscribe((response: boolean) => {
                if (response) {
                    alert('Adicionado com sucesso');
                } else {
                    alert('Erro ao adicionar. Verifique se o produto já está adicionado');
                } this.nfeProdutoService.query(this.createFormattedState(), this.nfeId);
            });
    }
}
