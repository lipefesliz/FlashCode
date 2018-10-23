import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TransportadorCreateComponent } from './transportador-view/transportador-create/transportador-create.component';
import { TransportadorResolveService } from './shared/transportador.service';
import { TransportadorViewComponent } from './transportador-view/transportador-view.component';
import { TransportadorDetailComponent } from './transportador-view/transportador-detail/transportador-detail.component';
import { TransportadorEditComponent } from './transportador-view/transportador-edit/transportador-edit.component';
import { TransportadorListComponent } from './transportador-list/transportador-list.component';

const transportadorRoutes: Routes = [
    {
        path: '',
        component: TransportadorListComponent,
    },
    {
        path: 'cadastrar',
        component: TransportadorCreateComponent,
        data:
            {
                breadcrumbOptions:
                    {
                        breadcrumbLabel: 'Cadastrar',
                    },
            },
    },
    {
        path: ':transportadorId',
        resolve:
        {
            Transportador: TransportadorResolveService,
        },
        data:
            {
                breadcrumbOptions:
                    {
                        breadcrumbId: 'Transportador',
                    },
            },
        children:
            [
                {
                    path: '',
                    component: TransportadorViewComponent,
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
                                            component: TransportadorDetailComponent,
                                        },
                                        {
                                            path: 'editar',
                                            component: TransportadorEditComponent,
                                        },
                                    ],
                            },
                        ],
                },
            ],
    },

];

@NgModule({
    imports: [RouterModule.forChild(transportadorRoutes)],
    declarations: [],
    exports: [RouterModule],
    providers: [],
})
export class TransportadorRoutingModule {

}
