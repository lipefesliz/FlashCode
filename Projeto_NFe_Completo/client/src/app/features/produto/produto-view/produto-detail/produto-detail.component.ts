import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProdutoViewModel } from '../../shared/produto.model';
import { Subject } from 'rxjs/Subject';
import { ProdutoResolveService } from '../../shared/produto.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './produto-detail.component.html',
})
export class ProdutoDetailComponent implements OnInit, OnDestroy {

    public produto: ProdutoViewModel;
    public isLoading: boolean;
    private ngUnsubscrive: Subject<void> = new Subject<void>();
    constructor(private service: ProdutoResolveService,
        private router: Router,
        private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((produto: ProdutoViewModel) => {
            this.produto = Object.assign(new ProdutoViewModel(), produto);
            this.isLoading = false;
        });

    }
    public ngOnDestroy(): void {
        this.ngUnsubscrive.next();
        this.ngUnsubscrive.complete();
    }

    public redirect(): void {
        this.router.navigate(['../produtos']);
    }

    public onEdit(): void {
        this.router.navigate(['./editar'], { relativeTo: this.route, skipLocationChange: true });
    }
}
