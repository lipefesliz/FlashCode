import { Observable } from 'rxjs/Observable';
import { State, toODataString } from '@progress/kendo-data-query';
import { HttpClient } from '@angular/common/http';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable, Inject } from '@angular/core';

import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';

@Injectable()
export class ProdutoGridService extends BehaviorSubject<GridDataResult>{
    public loading: Boolean = false;

    constructor( @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig,
        private http: HttpClient) {
        super(null);
    }

    public query(state: State): void {
        this.fetch(state).take(1).subscribe((result: GridDataResult) => super.next(result));
    }

    protected fetch(state: any): Observable<GridDataResult> {
        const queryStr: string = `${toODataString(state)}&$count=true`;
        this.loading = true;

        return this.http.get(`${this.config.apiEndpoint}api/produtos?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}
