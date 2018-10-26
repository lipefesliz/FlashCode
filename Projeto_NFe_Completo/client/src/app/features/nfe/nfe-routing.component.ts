import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NfeListComponent } from './nfe-list/nfe-list.component';
import { NfeCreateComponent } from './nfe-view/nfe-create/nfe-create.component';
import { NfeResolveService } from './shared/nfe.service';
import { NfeViewComponent } from './nfe-view/nfe-view.component';
import { NfeDetailComponent } from './nfe-view/nfe-detail/nfe-detail.component';
import { NfeEditComponent } from './nfe-view/nfe-edit/nfe-edit.component';
import { NfeDetailProdutoComponent } from './nfe-view/nfe-detail/nfe-detail-produto/nfe-detail-produto.component';

const nfeRoutes: Routes = [
    {
        path: '',
        component: NfeListComponent,
    },
    {
        path: 'cadastrar',
        component: NfeCreateComponent,
        data:
        {
            breadcrumbOptions:
            {
                breadcrumbLabel: 'Cadastrar',
            },
        },
    },
    {
        path: ':nfeId',
        resolve:
        {
            Nfe: NfeResolveService,
        },
        data:
        {
            breadcrumbOptions:
            {
                breadcrumbId: 'Nfe',
            },
        },
        children:
            [
                {
                    path: '',
                    component: NfeViewComponent,
                    children:
                        [
                            {
                                path: '',
                                redirectTo: 'info',
                                pathMatch: 'full',
                            },
                            {
                                path: 'info',
                                children:
                                    [
                                        {
                                            path: '',
                                            component: NfeDetailComponent,
                                        },
                                        {
                                            path: 'editar',
                                            component: NfeEditComponent,
                                        },
                                    ],
                            },
                            {
                                path: 'produtos', children:
                                    [
                                        {
                                            path: '',
                                            component: NfeDetailProdutoComponent,
                                        },
                                    ],
                            },
                        ],
                },
            ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(nfeRoutes)],
    declarations: [],
    exports: [RouterModule],
    providers: [],
})
export class NfeRoutingModule {

}
