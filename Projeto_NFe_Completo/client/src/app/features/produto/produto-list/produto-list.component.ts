import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { ProdutoRemoveCommand } from './../../produto/shared/produto.model';
import { ProdutoService } from './../../produto/shared/produto.service';
import { ProdutoGridService } from './../../produto/shared/produto-grid.service';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';

@Component({
    templateUrl: './produto-list.component.html',
})
export class ProdutoListComponent extends GridUtilsComponent implements OnInit{

    constructor(
        private gridService: ProdutoGridService,
        private produtoService: ProdutoService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
        this.gridService.query(this.createFormattedState());
    }

    public ngOnInit(): void {
        this.gridService.query(this.createFormattedState());
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }

    public deleteProduto(): void {
        this.gridService.loading = true;
        const produtoCommand: ProdutoRemoveCommand = new ProdutoRemoveCommand(this.getSelectedEntities());
        this.produtoService.delete(produtoCommand).take(1).subscribe((result: boolean) => {
            this.selectedRows = [];
            this.gridService.loading = false;
            this.gridService.query(this.createFormattedState());
        });
    }

    public openProduto(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public novoProduto(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
    }
}
