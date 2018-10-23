import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Router, ActivatedRoute } from '@angular/router';

import { DestinatarioResolveService } from '../../shared/destinatario.service';
import { Destinatario } from '../../shared/destinatario.model';

@Component({
    templateUrl: './destinatario-detail.component.html',
})
export class DestinatarioDetailComponent implements OnInit, OnDestroy{
    public destinatario: Destinatario;
    public isLoading: boolean;
    public isJuridica: boolean = true;
    private ngUnsubscrive: Subject<void> = new Subject<void>();

    constructor(private service: DestinatarioResolveService,
        private router: Router,
        private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((destinatario: Destinatario) => {
            this.isLoading = false;
            this.destinatario = Object.assign(new Destinatario(), destinatario);
            this.setIsJuridica();
        });
    }

    public setIsJuridica(): void {
        if (this.destinatario.cnpj !== '') {
            this.isJuridica = true;
        } else {
            this.isJuridica = false;
        }
    }

    public ngOnDestroy(): void {
        this.ngUnsubscrive.next();
        this.ngUnsubscrive.complete();
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public onEdit(): void {
        this.router.navigate(['./editar'], { relativeTo: this.route, skipLocationChange: true });
    }
}
