import { EmitenteDetailComponent } from './emitente-view/emitente-detail/emitente-detail.component';
import { EmitenteEditComponent } from './emitente-view/emitente-edit/emitente-edit.component';
import { EmitenteGridService } from './../emitente/shared/emitente-grid.service';
import { EmitenteListComponent } from './emitente-list/emitente-list.component';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';
import { SharedModule } from './../../shared/shared.module';
import { EmitenteRoutingModule } from './../emitente/emitente-routing.module';
import { EmitenteSharedModule } from './../emitente/shared/emitente-shared.service';
import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { EmitenteViewComponent } from '../emitente/emitente-view/emitente-view.component';
import { EnderecoModule } from '../../shared/endereco/endereco.module';
import { EmitenteResolveService } from './shared/emitente.service';
import { EmitenteCreateComponent } from './emitente-view/emitente-create/emitente-create.component';
@NgModule({
    imports: [
        EmitenteSharedModule,
        EnderecoModule,
        EmitenteRoutingModule,
        SharedModule,
        GridModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
    ],
    declarations: [
        EmitenteListComponent,
        EmitenteCreateComponent,
        EmitenteViewComponent,
        EmitenteEditComponent,
        EmitenteDetailComponent,
    ],
    exports: [
    ],
    providers: [
        EmitenteGridService,
        EmitenteResolveService,
    ],
})
export class EmitenteModule {

}
