import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { BaseService } from './../../../core/utils/base-service';
import { AbstractResolveService } from './../../../../app/core/utils/abstract-resolve.service';
import { Nfe, NfeRegisterCommand, NfeRemoveCommand, NfeEditCommand, ProdutoNotaCommand, ProdutoNotaRemoveCommand } from './nfe.model';

@Injectable()
export class NfeService extends BaseService {

    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);

        this.api = `${config.apiEndpoint}api/notasfiscais`;
    }

    public delete(nfe: NfeRemoveCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, nfe);
    }

    public edit(nfe: NfeEditCommand): Observable<boolean> {
        return this.http.put(this.api, nfe).map((reponse: boolean) => reponse);
    }

    public get(entityId: number): Observable<Nfe> {
        return this.http.get(`${this.api}/${entityId}`).map((response: Nfe) => response);
    }
    public getByName(nome: any): Observable<Nfe[]> {

        return this.http
            .get(`${this.api}?$count=true&$filter=contains(tolower(nome),tolower('${nome}'))`)
            .map((response: any) => response.items);
    }

    public add(nfe: NfeRegisterCommand): Observable<number> {
        return this.http.post(this.api, nfe).map((reponse: number) => reponse);
    }

    public removeProdutos(produtoNotaRemoveCommand: ProdutoNotaRemoveCommand): Observable<boolean> {
        return this.deleteRequestWithBody(`${this.api}/produtos`, produtoNotaRemoveCommand)
            .map((response: boolean) => response);
    }

    public addProduto(produtoNota: any): Observable<boolean> {
        return this.http.patch(this.api, produtoNota).map((reponse: boolean) => reponse);
    }
}

@Injectable()
export class NfeResolveService extends AbstractResolveService<Nfe>{

    constructor(private nfeService: NfeService, router: Router, private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'nfeId';
    }

    protected loadEntity(entityId: number): Observable<Nfe> {
        return this.nfeService.get(entityId).take(1).do((nfe: Nfe) => {
            this.breadcrumbService.setMetadata({
                id: 'Nfe',
                label: nfe.naturezaOperacao,
                sizeLimit: true,
            });
        });
    }

}
