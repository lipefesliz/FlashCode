import { Routes, RouterModule } from '@angular/router';
import { EmitenteListComponent } from './emitente-list/emitente-list.component';
import { EmitenteViewComponent } from './emitente-view/emitente-view.component';
import { EmitenteDetailComponent } from './emitente-view/emitente-detail/emitente-detail.component';
import { EmitenteEditComponent } from './emitente-view/emitente-edit/emitente-edit.component';
import { NgModule } from '@angular/core';
import { EmitenteResolveService } from './shared/emitente.service';
import { EmitenteCreateComponent } from './emitente-view/emitente-create/emitente-create.component';

const emitenteRoutes: Routes = [
    {
        path: '',
        component: EmitenteListComponent,
    },
    {
        path: 'cadastrar',
        component: EmitenteCreateComponent,
        data:
            {
                breadcrumbOptions:
                    {
                        breadcrumbLabel: 'Cadastrar',
                    },
            },
    },
    {
        path: ':emitenteId',
        resolve:
        {
            emitente: EmitenteResolveService,
        },
        data:
            {
                breadcrumbOptions:
                    {
                        breadcrumbId: 'emitente',
                    },
            },
        children:
            [
                {
                    path: '',
                    component: EmitenteViewComponent,
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
                                            component: EmitenteDetailComponent,
                                        },
                                        {
                                            path: 'editar',
                                            component: EmitenteEditComponent,
                                        },
                                    ],
                            },
                        ],
                },
            ],
    },

];

@NgModule({
    imports: [RouterModule.forChild(emitenteRoutes)],
    declarations: [],
    exports: [RouterModule],
    providers: [],
})
export class EmitenteRoutingModule {

}
