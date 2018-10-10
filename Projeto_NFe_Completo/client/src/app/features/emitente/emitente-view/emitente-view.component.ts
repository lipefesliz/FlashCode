import { Component, OnInit, OnDestroy } from '@angular/core';
import { Emitente } from '../shared/emitente.model';
import { Subject } from 'rxjs/Subject';
import { EmitenteResolveService } from '../shared/emitente.service';

@Component({
    templateUrl: './emitente-view.component.html',
})
export class EmitenteViewComponent implements OnInit, OnDestroy {
    public emitente: Emitente;
    public title: string;
    public infoItems: object[];

    private ngUnsubscrive: Subject<void> = new Subject<void>();

    constructor(private service: EmitenteResolveService) {

    }

    public ngOnInit(): void {
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((emitente: Emitente) => {
            this.emitente = emitente;
            this.createProperty();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscrive.next();
        this.ngUnsubscrive.complete();
    }

    public createProperty(): void {
        this.title = this.emitente.nome;
        let cpfCnpj: string;
        let pessoa: string;

        if (this.emitente.cpf !== '') {
            cpfCnpj = 'CPF: ' + this.emitente.cpf;
            pessoa = 'Pessoa fisíca';
        } else {
            cpfCnpj = 'CNPJ: ' + this.emitente.cnpj;
            pessoa = 'Pessoa juridica';
        }
        this.infoItems = [
            {
                value: pessoa,
                description: pessoa,
            },
            {
                value: cpfCnpj,
                description: cpfCnpj,
            },
        ];

    }
}
