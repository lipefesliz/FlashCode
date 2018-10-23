import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { BaseService } from './../../../core/utils/base-service';
import { AbstractResolveService } from './../../../../app/core/utils/abstract-resolve.service';
import { TransportadorRemoveCommand, TransportadorEditCommand, Transportador, TransportadorRegisterCommand } from './transportador.model';

@Injectable()
export class TransportadorService extends BaseService {

    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);

        this.api = `${config.apiEndpoint}api/transportadores`;
    }

    public delete(transportador: TransportadorRemoveCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, transportador);
    }

    public edit(transportador: TransportadorEditCommand): Observable<boolean> {
        return this.http.put(this.api, transportador).map((reponse: boolean) => reponse);
    }

    public getAll(): Observable<Transportador[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public get(entityId: number): Observable<Transportador> {
        return this.http.get(`${this.api}/${entityId}`).map((response: Transportador) => response);
    }

    public getByName(name: any): Observable<Transportador[]> {

        return this.http
            .get(`${this.api}?$count=true&$filter=contains(tolower(nome),tolower('${name}'))`)
            .map((response: any) => response.items);
    }

    public add(transportador: TransportadorRegisterCommand): Observable<number> {
        return this.http.post(this.api, transportador).map((reponse: number) => reponse);
    }
}

@Injectable()
export class TransportadorResolveService extends AbstractResolveService<Transportador>{

    constructor(private transportadorService: TransportadorService,
        router: Router,
        private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'transportadorId';
    }

    protected loadEntity(entityId: number): Observable<Transportador> {
        return this.transportadorService.get(entityId).take(1).do((tansportador: Transportador) => {
            this.breadcrumbService.setMetadata({
                id: 'Transportador',
                label: tansportador.nome,
                sizeLimit: true,
            });
        });
    }

}
