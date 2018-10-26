import { SortableModule } from '@progress/kendo-angular-sortable';
import { NgModule } from '@angular/core';
import { NfeSharedModule } from './shared/nfe-shared.service';
import { EnderecoModule } from '../../shared/endereco/endereco.module';
import { NfeRoutingModule } from './nfe-routing.component';
import { SharedModule } from '../../shared/shared.module';
import { GridModule } from '@progress/kendo-angular-grid';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { EmitenteSharedModule } from '../emitente/shared/emitente-shared.service';
import { DestinatarioSharedModule } from '../destinatario/shared/destinatario-shared.service';
import { TransportadorSharedModule } from '../transportador/shared/transportador-shared.service';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { ProdutoSharedModule } from '../produto/shared/produto-shared.service';
import { NfeListComponent } from './nfe-list/nfe-list.component';
import { NfeCreateComponent } from './nfe-view/nfe-create/nfe-create.component';
import { NfeViewComponent } from './nfe-view/nfe-view.component';
import { NfeEditComponent } from './nfe-view/nfe-edit/nfe-edit.component';
import { NfeDetailComponent } from './nfe-view/nfe-detail/nfe-detail.component';
import { NfeGridService, NfeProdutoGridService } from './shared/nfe-grid.service';
import { NfeResolveService } from './shared/nfe.service';
import { NfeDetailProdutoComponent } from './nfe-view/nfe-detail/nfe-detail-produto/nfe-detail-produto.component';

@NgModule({
    imports: [
        NfeSharedModule,
        EnderecoModule,
        NfeRoutingModule,
        SharedModule,
        GridModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        EmitenteSharedModule,
        DestinatarioSharedModule,
        TransportadorSharedModule,
        DropDownsModule,
        SortableModule,
        EmitenteSharedModule,
        DestinatarioSharedModule,
        TransportadorSharedModule,
        ProdutoSharedModule,
        DropDownsModule,
        SortableModule,
    ],
    declarations: [
        NfeListComponent,
        NfeCreateComponent,
        NfeViewComponent,
        NfeEditComponent,
        NfeDetailComponent,
        NfeDetailComponent,
        NfeDetailProdutoComponent,
    ],
    exports: [
    ],
    providers: [
        NfeGridService,
        NfeResolveService,
        NfeProdutoGridService,
    ],
})
export class NfeModule {

}
