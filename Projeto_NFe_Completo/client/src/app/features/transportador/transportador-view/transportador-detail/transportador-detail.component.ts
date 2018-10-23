import { Component, OnInit, OnDestroy } from '@angular/core';
import { Transportador } from '../../shared/transportador.model';
import { Subject } from 'rxjs/Subject';
import { TransportadorResolveService } from '../../shared/transportador.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './transportador-detail.component.html',
})

export class TransportadorDetailComponent implements OnInit, OnDestroy {

    public transportador: Transportador;
    public isLoading: boolean;
    public isEmpresa: boolean;
    private ngUnsubscrive: Subject<void> = new Subject<void>();
    constructor(private service: TransportadorResolveService,
        private router: Router,
        private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((transportador: Transportador) => {
            this.transportador = Object.assign(new Transportador(), transportador);
            this.isLoading = false;
            this.verificarDocumento();
        });

    }
    public ngOnDestroy(): void {
        this.ngUnsubscrive.next();
        this.ngUnsubscrive.complete();
    }

    public redirect(): void {
        this.router.navigate(['../']);
    }

    public onEdit(): void {
        this.router.navigate(['./editar'], { relativeTo: this.route, skipLocationChange: true });
    }
    private verificarDocumento(): void {
        if (this.transportador.cnpj !== '') {
            this.isEmpresa = true;
        } else {
            this.isEmpresa = false;
        }
    }
}
