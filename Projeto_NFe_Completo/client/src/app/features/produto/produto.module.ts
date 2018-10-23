import { ProdutoDetailComponent } from './produto-view/produto-detail/produto-detail.component';
import { ProdutoEditComponent } from './produto-view/produto-edit/produto-edit.component';
import { ProdutoGridService } from './../produto/shared/produto-grid.service';
import { ProdutoListComponent } from './produto-list/produto-list.component';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';
import { SharedModule } from './../../shared/shared.module';
import { ProdutoRoutingModule } from './../produto/produto-routing.module';
import { ProdutoSharedModule } from './../produto/shared/produto-shared.service';
import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { ProdutoViewComponent } from '../produto/produto-view/produto-view.component';
import { EnderecoModule } from '../../shared/endereco/endereco.module';
import { ProdutoResolveService } from './shared/produto.service';
import { ProdutoCreateComponent } from './produto-create/produto-create.component';

@NgModule({
    imports: [
        ProdutoSharedModule,
        EnderecoModule,
        ProdutoRoutingModule,
        SharedModule,
        GridModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
    ],
    declarations: [
        ProdutoListComponent,
        ProdutoCreateComponent,
        ProdutoViewComponent,
        ProdutoEditComponent,
        ProdutoDetailComponent,
    ],
    exports: [
    ],
    providers: [
        ProdutoGridService,
        ProdutoResolveService,
    ],
})
export class ProdutoModule {

}
