import { NgModule } from '@angular/core';
import { EnderecoModule } from '../../shared/endereco/endereco.module';
import { SharedModule } from '../../shared/shared.module';
import { GridModule } from '@progress/kendo-angular-grid';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { TransportadorCreateComponent } from './transportador-view/transportador-create/transportador-create.component';
import { TransportadorViewComponent } from './transportador-view/transportador-view.component';
import { TransportadorEditComponent } from './transportador-view/transportador-edit/transportador-edit.component';
import { TransportadorDetailComponent } from './transportador-view/transportador-detail/transportador-detail.component';
import { TransportadorGridService } from './shared/transportador-grid.service';
import { TransportadorResolveService } from './shared/transportador.service';
import { TransportadorSharedModule } from './shared/transportador-shared.service';
import { TransportadorRoutingModule } from './transportador-routing.module';
import { TransportadorListComponent } from './transportador-list/transportador-list.component';

@NgModule({
    imports: [
        TransportadorSharedModule,
        EnderecoModule,
        TransportadorRoutingModule,
        SharedModule,
        GridModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
    ],
    declarations: [
        TransportadorListComponent,
        TransportadorCreateComponent,
        TransportadorViewComponent,
        TransportadorEditComponent,
        TransportadorDetailComponent,
    ],
    exports: [
    ],
    providers: [
        TransportadorGridService,
        TransportadorResolveService,
    ],
})
export class TransportadorModule {

}
