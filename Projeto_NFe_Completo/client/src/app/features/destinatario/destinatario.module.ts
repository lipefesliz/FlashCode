import { NgModule } from '@angular/core';
import { DestinatarioRoutingModule } from './destinatario-routing.module';
import { DestinatarioSharedModule } from './shared/destinatario-shared.service';
import { SharedModule } from '../../shared/shared.module';
import { GridModule } from '@progress/kendo-angular-grid';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { EnderecoModule } from '../../shared/endereco/endereco.module';

import { DestinatarioViewComponent } from './destinatario-view/destinatario-view.component';
import { DestinatarioDetailComponent } from './destinatario-view/destinatario-detail/destinatario-detail.component';
import { DestinatarioListComponent } from './destinatario-list/destinatario-list.component';
import { DestinatarioCreateComponent } from './destinatario-view/destinatario-create/destinatario-create.component';
import { DestinatarioEditComponent } from './destinatario-view/destinatario-edit/destinatario-edit.component';

import { DestinatarioGridService } from './shared/destinatario-grid.service';
import { DestinatarioResolveService } from './shared/destinatario.service';

@NgModule({
    imports: [
        EnderecoModule,
        DestinatarioSharedModule,
        DestinatarioRoutingModule,
        SharedModule,
        GridModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
    ],
    declarations: [
        DestinatarioListComponent,
        DestinatarioViewComponent,
        DestinatarioDetailComponent,
        DestinatarioCreateComponent,
        DestinatarioEditComponent,
    ],
    exports: [
    ],
    providers: [
        DestinatarioGridService,
        DestinatarioResolveService,
    ],
})
export class DestinatarioModule {

}
