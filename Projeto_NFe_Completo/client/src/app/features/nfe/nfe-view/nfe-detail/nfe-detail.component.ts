import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Router, ActivatedRoute } from '@angular/router';

import { NfeViewModel, Nfe } from '../../shared/nfe.model';

import { NfeResolveService } from '../../shared/nfe.service';

@Component({
    templateUrl: './nfe-detail.component.html',
})
export class NfeDetailComponent implements OnInit, OnDestroy {
    public nfe: NfeViewModel;
    public isLoading: boolean;
    private ngUnsubscrive: Subject<void> = new Subject<void>();

    constructor(private service: NfeResolveService,
        private router: Router,
        private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((nfe: Nfe) => {
            this.isLoading = false;
            this.nfe = Object.assign(new NfeViewModel(nfe), nfe);
        });
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
