import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Nfe } from './../shared/nfe.model';

import { NfeResolveService } from '../shared/nfe.service';

@Component({
    templateUrl: './nfe-view.component.html',
})
export class NfeViewComponent implements OnInit, OnDestroy {
    public nfe: Nfe;
    public title: string;
    public infoItems: object[];

    private ngUnsubscrive: Subject<void> = new Subject<void>();

    constructor(private service: NfeResolveService) {
    }

    public ngOnInit(): void {
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((nfe: Nfe) => {
            this.nfe = nfe;
            this.createProperty();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscrive.next();
        this.ngUnsubscrive.complete();
    }

    public createProperty(): void {
        this.title = this.nfe.naturezaOperacao;
        this.infoItems = [
            {
                value: this.nfe.dataEntrada,
                description: this.nfe.naturezaOperacao,
            },
        ];
    }
}
