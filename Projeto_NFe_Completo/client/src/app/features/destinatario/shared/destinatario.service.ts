import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../../core/utils';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

import { DestinatarioRemoveCommand, DestinatarioEditCommand, Destinatario, DestinatarioRegisterCommand } from './destinatario.model';

@Injectable()
export class DestinatarioService extends BaseService {

    private api: string;

    constructor( @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);

        this.api = `${config.apiEndpoint}api/destinatarios`;
    }

    public delete(product: DestinatarioRemoveCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, product);
    }

    public edit(product: DestinatarioEditCommand): Observable<boolean> {
        return this.http.put(this.api, product).map((reponse: boolean) => reponse);
    }

    public getAll(): Observable<Destinatario[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public get(entityId: number): Observable<Destinatario> {
        return this.http.get(`${this.api}/${entityId}`).map((response: Destinatario) => response);
    }

    public getByName(name: any): Observable<Destinatario[]> {

        return this.http
        .get(`${this.api}?$count=true&$filter=contains(tolower(nome),tolower('${name}'))`)
            .map((response: any) => response.items);
    }

    public add(destinatario: DestinatarioRegisterCommand): Observable<number> {
        return this.http.post(this.api, destinatario).map((reponse: number) => reponse);
    }
}

@Injectable()
export class DestinatarioResolveService extends AbstractResolveService<Destinatario>{

    constructor(private destinatarioService: DestinatarioService, router: Router, private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'destinatarioId';
    }

    protected loadEntity(entityId: number): Observable<Destinatario> {
        return this.destinatarioService.get(entityId).take(1).do((destinatario: Destinatario) => {
            this.breadcrumbService.setMetadata({
                id: 'destinatario',
                label: destinatario.nome,
                sizeLimit: true,
            });
        });
    }
}
