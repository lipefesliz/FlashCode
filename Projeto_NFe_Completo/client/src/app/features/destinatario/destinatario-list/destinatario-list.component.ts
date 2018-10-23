import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';

import { DestinatarioRemoveCommand, Destinatario } from '../shared/destinatario.model';

import { DestinatarioGridService } from '../shared/destinatario-grid.service';
import { DestinatarioService } from '../shared/destinatario.service';

@Component({
    templateUrl: './destinatario-list.component.html',
})
export class DestinatarioListComponent extends GridUtilsComponent implements OnInit{

    constructor(
        private gridService: DestinatarioGridService,
        private emitenteService: DestinatarioService,
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

    public deleteDestinatario(): void {
        this.gridService.loading = true;
        const emitenteCommand: DestinatarioRemoveCommand = new DestinatarioRemoveCommand(this.getSelectedEntities());
        this.emitenteService.delete(emitenteCommand).take(1).subscribe((result: boolean) => {
            this.selectedRows = [];
            this.gridService.loading = false;
            this.gridService.query(this.createFormattedState());
        });
    }
    public openDestinatario(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public novoDestinatario(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
    }

    public setDocumento(destinatario: Destinatario): string {
        if (destinatario.cpf !== '') {
            return destinatario.cpf;
        } else if (destinatario.cnpj !== '') {
            return destinatario.cnpj;
        }
    }
}
