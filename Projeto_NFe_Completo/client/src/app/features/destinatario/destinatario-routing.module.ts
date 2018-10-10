import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DestinatarioViewComponent } from './destinatario-view/destinatario-view.component';
import { DestinatarioDetailComponent } from './destinatario-view/destinatario-detail/destinatario-detail.component';
import { DestinatarioCreateComponent } from './destinatario-view/destinatario-create/destinatario-create.component';
import { DestinatarioListComponent } from './destinatario-list/destinatario-list.component';
import { DestinatarioEditComponent } from './destinatario-view/destinatario-edit/destinatario-edit.component';
import { DestinatarioResolveService } from './shared/destinatario.service';

const destinatarioRoutes: Routes = [
    {
        path: '',
        component: DestinatarioListComponent,
    },
    {
        path: 'cadastrar',
        component: DestinatarioCreateComponent,
        data:
            {
                breadcrumbOptions:
                    {
                        breadcrumbLabel: 'Cadastrar',
                    },
            },
    },
    {
        path: ':destinatarioId',
        resolve:
        {
            destinatario: DestinatarioResolveService,
        },
        data:
            {
                breadcrumbOptions:
                    {
                        breadcrumbId: 'destinatario',
                    },
            },
        children:
            [
                {
                    path: '',
                    component: DestinatarioViewComponent,
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
                                            component: DestinatarioDetailComponent,
                                        },
                                        {
                                            path: 'editar',
                                            component: DestinatarioEditComponent,
                                        },
                                    ],
                            },
                        ],
                },
            ],
    },

];

@NgModule({
    imports: [RouterModule.forChild(destinatarioRoutes)],
    declarations: [],
    exports: [RouterModule],
    providers: [],
})
export class DestinatarioRoutingModule {

}
