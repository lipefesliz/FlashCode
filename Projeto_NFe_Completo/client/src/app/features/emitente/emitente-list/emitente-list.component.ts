import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { EmitenteRemoveCommand, Emitente } from './../../emitente/shared/emitente.model';
import { EmitenteService } from './../../emitente/shared/emitente.service';
import { EmitenteGridService } from './../../emitente/shared/emitente-grid.service';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';

@Component({
    templateUrl: './emitente-list.component.html',
})
export class EmitenteListComponent extends GridUtilsComponent implements OnInit{

    constructor(
        private gridService: EmitenteGridService,
        private emitenteService: EmitenteService,
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

    public deleteEmitente(): void {
        this.gridService.loading = true;
        const emitenteCommand: EmitenteRemoveCommand = new EmitenteRemoveCommand(this.getSelectedEntities());
        this.emitenteService.delete(emitenteCommand).take(1).subscribe((result: boolean) => {
            this.selectedRows = [];
            this.gridService.loading = false;
            this.gridService.query(this.createFormattedState());
        });
    }

    public openEmitente(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public novoEmitente(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
    }

    public setDocumento(emitente: Emitente): string {
        if (emitente.cpf !== '') {
            return emitente.cpf;
        } else if (emitente.cnpj !== '') {
            return emitente.cnpj;
        }
    }
}
