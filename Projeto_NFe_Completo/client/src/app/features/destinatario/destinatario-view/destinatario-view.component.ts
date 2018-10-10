import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Destinatario } from '../shared/destinatario.model';
import { DestinatarioResolveService } from '../shared/destinatario.service';

@Component({
    templateUrl: './destinatario-view.component.html',
})
export class DestinatarioViewComponent implements OnInit, OnDestroy {
    public destinatario: Destinatario;

    public title: string;
    public infoItems: object[];

    private ngUnsubscrive: Subject<void> = new Subject<void>();

    constructor(private service: DestinatarioResolveService) {
    }

    public ngOnInit(): void {
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((destinatario: Destinatario) => {
            this.destinatario = destinatario;
            this.createProperty();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscrive.next();
        this.ngUnsubscrive.complete();
    }

    public createProperty(): void {
        this.title = this.destinatario.nome;
        let tipoDoc: string;
        let pfpj: string;
        if (this.destinatario.cpf === '') {
            tipoDoc = 'CNPJ:' + this.destinatario.cnpj;
            pfpj = 'Juridica';
        } else {
            tipoDoc = 'CPF:' + this.destinatario.cpf;
            pfpj = 'Pessoa Fisica';
        }
        this.infoItems = [
            {
                value: pfpj,
                description: pfpj,
            },
            {
                value: tipoDoc,
                description: tipoDoc,
            },
        ];
    }
}
