
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { TransportadorRemoveCommand, Transportador } from './../../transportador/shared/transportador.model';
import { TransportadorService } from './../../transportador/shared/transportador.service';
import { TransportadorGridService } from './../../transportador/shared/transportador-grid.service';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';

@Component({
    templateUrl: './transportador-list.component.html',
})
export class TransportadorListComponent extends GridUtilsComponent implements OnInit{

    constructor(
        private gridService: TransportadorGridService,
        private emitenteService: TransportadorService,
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

    public deleteTransportador(): void {
        this.gridService.loading = true;
        const emitenteCommand: TransportadorRemoveCommand = new TransportadorRemoveCommand(this.getSelectedEntities());
        this.emitenteService.delete(emitenteCommand).take(1).subscribe((result: boolean) => {
            this.selectedRows = [];
            this.gridService.loading = false;
            this.gridService.query(this.createFormattedState());
        });
    }

    public openTransportador(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public novoTransportador(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
    }

    public setDocumento(transportador: Transportador): string {
        if (transportador.cpf !== '') {
            return transportador.cpf;
        } else if (transportador.cnpj !== '') {
            return transportador.cnpj;
        }
    }
}
