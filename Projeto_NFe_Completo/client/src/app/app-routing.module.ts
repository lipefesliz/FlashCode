import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LayoutComponent } from './core/layout/layout.component';

const appRoutes: Routes = [
    {
        path: 'page-not-found',
        loadChildren: './features/error-pages/page-not-found/page-not-found.module#PageNotFoundModule',
    },
    {
        path: '',
        component: LayoutComponent,
        children: [
            {
                path: '',
                redirectTo: 'emitentes',
                pathMatch: 'full',
            },
            {
                path: 'emitentes',
                loadChildren: './features/emitente/emitente.module#EmitenteModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Emitentes',
                    },
                },
            },
            {
                path: 'destinatarios',
                loadChildren: './features/destinatario/destinatario.module#DestinatarioModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Destinatarios',
                    },
                },
            },
            {
                path: 'transportadores',
                loadChildren: './features/transportador/transportador.module#TransportadorModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Transportadores',
                    },
                },
            },
            {
                path: 'nfe',
                loadChildren: './features/nfe/nfe.module#NfeModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Notas Fiscais',
                    },
                },
            },
            {
                path: 'produtos',
                loadChildren: './features/produto/produto.module#ProdutoModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Produtos',
                    },
                },
            },
        ],

    },
    { path: '**', redirectTo: 'page-not-found', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes, {
        paramsInheritanceStrategy: 'always',
    })],
    exports: [RouterModule],
})
export class AppRoutingModule { }
