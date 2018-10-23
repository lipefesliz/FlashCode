import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { BaseService } from './../../../core/utils/base-service';
import { Produto, ProdutoRegisterCommand, ProdutoEditCommand, ProdutoRemoveCommand, ProdutoViewModel } from './produto.model';
import { AbstractResolveService } from './../../../../app/core/utils/abstract-resolve.service';

@Injectable()
export class ProdutoService extends BaseService {

    private api: string;

    constructor( @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);

        this.api = `${config.apiEndpoint}api/produtos`;
    }

    public delete(produto: ProdutoRemoveCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, produto);
    }

    public edit(produto: ProdutoEditCommand): Observable<boolean> {
        return this.http.put(this.api, produto).map((reponse: boolean) => reponse);
    }

    public getAll(): Observable<Produto[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public get(entityId: number): Observable<ProdutoViewModel> {
        return this.http.get(`${this.api}/${entityId}`).map((response: ProdutoViewModel) => response);
    }

    public getByName(name: any): Observable<Produto[]> {

        return this.http
            .get(`${this.api}?$count=true&$filter=contains(tolower(descricao),tolower('${name}'))`)
            .map((response: any) => response.items);
    }

    public add(produto: ProdutoRegisterCommand): Observable<number> {
        return this.http.post(this.api, produto).map((reponse: number) => reponse);
    }
}

@Injectable()
export class ProdutoResolveService extends AbstractResolveService<ProdutoViewModel>{

    constructor(private produtoService: ProdutoService, router: Router, private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'produtoId';
    }

    protected loadEntity(entityId: number): Observable<ProdutoViewModel> {
        return this.produtoService.get(entityId).take(1).do((produto: ProdutoViewModel) => {
            this.breadcrumbService.setMetadata({
                id: 'Produto',
                label: produto.descricao,
                sizeLimit: true,
            });
        });
    }
}
