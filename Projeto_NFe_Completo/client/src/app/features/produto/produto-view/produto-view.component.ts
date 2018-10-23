import { ProdutoViewModel } from './../shared/produto.model';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { ProdutoResolveService } from '../shared/produto.service';

@Component({
    templateUrl: './produto-view.component.html',
})
export class ProdutoViewComponent implements OnInit, OnDestroy {
    public produto: ProdutoViewModel;
    public title: string;
    public infoItems: object[];

    private ngUnsubscrive: Subject<void> = new Subject<void>();

    constructor(private service: ProdutoResolveService) {

    }

    public ngOnInit(): void {
        this.service.onChanges.takeUntil(this.ngUnsubscrive).subscribe((produto: ProdutoViewModel) => {
            this.produto = produto;
            this.createProperty();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscrive.next();
        this.ngUnsubscrive.complete();
    }

    public createProperty(): void {
        this.title = this.produto.descricao;
        this.infoItems = [
            {
                value: this.produto.codigoProduto,
                description: this.produto.descricao,
            },
        ];
    }
}
