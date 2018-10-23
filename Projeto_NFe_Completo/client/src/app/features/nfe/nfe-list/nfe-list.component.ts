import { Component, OnInit } from '@angular/core';
import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { NfeGridService } from '../shared/nfe-grid.service';
import { NfeService } from '../shared/nfe.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { NfeRemoveCommand } from '../shared/nfe.model';

@Component({
    templateUrl: './nfe-list.component.html',
})
export class NfeListComponent extends GridUtilsComponent implements OnInit{

    constructor(
        private gridService: NfeGridService,
        private nfeService: NfeService,
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

    public deleteNfe(): void {
        this.gridService.loading = true;
        const nfeCommand: NfeRemoveCommand = new NfeRemoveCommand(this.getSelectedEntities());
        this.nfeService.delete(nfeCommand).take(1).subscribe((result: boolean) => {
            this.selectedRows = [];
            this.gridService.loading = false;
            this.gridService.query(this.createFormattedState());
        });
    }

    public openNfe(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public newNfe(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
    }
}
