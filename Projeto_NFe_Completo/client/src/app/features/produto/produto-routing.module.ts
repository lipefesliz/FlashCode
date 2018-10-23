import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProdutoListComponent } from './produto-list/produto-list.component';
import { ProdutoViewComponent } from './produto-view/produto-view.component';
import { ProdutoDetailComponent } from './produto-view/produto-detail/produto-detail.component';
import { ProdutoEditComponent } from './produto-view/produto-edit/produto-edit.component';
import { ProdutoResolveService } from './shared/produto.service';
import { ProdutoCreateComponent } from './produto-create/produto-create.component';

const produtoRoutes: Routes = [
    {
        path: '',
        component: ProdutoListComponent,
    },
    {
        path: 'cadastrar',
        component: ProdutoCreateComponent,
        data:
        {
            breadcrumbOptions:
            {
                breadcrumbLabel: 'Cadastrar',
            },
        },
    },
    {
        path: ':produtoId',
        resolve:
        {
            produto: ProdutoResolveService,
        },
        data:
        {
            breadcrumbOptions:
            {
                breadcrumbId: 'produto',
            },
        },
        children:
        [
            {
                path: '',
                component: ProdutoViewComponent,
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
                                component: ProdutoDetailComponent,
                            },
                            {
                                path: 'editar',
                                component: ProdutoEditComponent,
                            },
                        ],
                    },
                ],
            },
        ],
    },

];

@NgModule({
    imports: [RouterModule.forChild(produtoRoutes)],
    declarations: [],
    exports: [RouterModule],
    providers: [],
})
export class ProdutoRoutingModule {

}
