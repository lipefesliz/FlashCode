import { Component, OnInit, OnDestroy } from '@angular/core';
import { Transportador } from '../shared/transportador.model';
import { Subject } from 'rxjs/Subject';
import { TransportadorResolveService } from '../shared/transportador.service';

@Component({
    templateUrl: './transportador-view.component.html',
})
export class TransportadorViewComponent implements OnInit, OnDestroy {
    public transportador: Transportador;
    public title: string;
    public infoItems: object[];

    private ngUnsubscrive: Subject<void> = new Subject<void>();

    constructor(private service: TransportadorResolveService) {

    }

    public ngOnInit(): void {
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((transportador: Transportador) => {
            this.transportador = transportador;
            this.createProperty();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscrive.next();
        this.ngUnsubscrive.complete();
    }

    public createProperty(): void {
        this.title = this.transportador.nome;
        let cpfCnpj: string;
        let pessoa: string;

        if (this.transportador.cpf !== '') {
            cpfCnpj = 'CPF: ' + this.transportador.cpf;
            pessoa = 'Pessoa fisíca';
        } else {
            cpfCnpj = 'CNPJ: ' + this.transportador.cnpj;
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
