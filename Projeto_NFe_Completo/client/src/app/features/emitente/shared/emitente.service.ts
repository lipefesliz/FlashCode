import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { BaseService } from './../../../core/utils/base-service';
import { Emitente, EmitenteRegisterCommand, EmitenteEditCommand, EmitenteRemoveCommand } from './emitente.model';
import { AbstractResolveService } from './../../../../app/core/utils/abstract-resolve.service';

@Injectable()
export class EmitenteService extends BaseService {

    private api: string;

    constructor( @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);

        this.api = `${config.apiEndpoint}api/emitentes`;
    }

    public delete(emitente: EmitenteRemoveCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, emitente);
    }

    public edit(emitente: EmitenteEditCommand): Observable<boolean> {
        return this.http.put(this.api, emitente).map((reponse: boolean) => reponse);
    }

    public getAll(): Observable<Emitente[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public get(entityId: number): Observable<Emitente> {
        return this.http.get(`${this.api}/${entityId}`).map((response: Emitente) => response);
    }

    public getByName(name: any): Observable<Emitente[]> {

        return this.http
            .get(`${this.api}?$count=true&$filter=contains(tolower(nome),tolower('${name}'))`)
            .map((response: any) => response.items);
    }

    public add(emitente: EmitenteRegisterCommand): Observable<number> {
        return this.http.post(this.api, emitente).map((reponse: number) => reponse);
    }
}

@Injectable()
export class EmitenteResolveService extends AbstractResolveService<Emitente>{

    constructor(private emitenteService: EmitenteService, router: Router, private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'emitenteId';
    }

    protected loadEntity(entityId: number): Observable<Emitente> {
        return this.emitenteService.get(entityId).take(1).do((emitente: Emitente) => {
            this.breadcrumbService.setMetadata({
                id: 'Emitente',
                label: emitente.nome,
                sizeLimit: true,
            });
        });
    }

}
