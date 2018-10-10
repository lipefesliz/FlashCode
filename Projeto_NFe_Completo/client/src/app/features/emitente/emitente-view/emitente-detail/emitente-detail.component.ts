import { Component, OnInit, OnDestroy } from '@angular/core';
import { Emitente } from '../../shared/emitente.model';
import { Subject } from 'rxjs/Subject';
import { EmitenteResolveService } from '../../shared/emitente.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './emitente-detail.component.html',
})
export class EmitenteDetailComponent implements OnInit, OnDestroy {

    public emitente: Emitente;
    public isLoading: boolean;
    public isEmpresa: boolean;
    private ngUnsubscrive: Subject<void> = new Subject<void>();
    constructor(private service: EmitenteResolveService,
        private router: Router,
        private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((emitente: Emitente) => {
            this.emitente = Object.assign(new Emitente(), emitente);
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
        if (this.emitente.cnpj !== '') {
            this.isEmpresa = true;
        } else {
            this.isEmpresa = false;
        }
    }
}
