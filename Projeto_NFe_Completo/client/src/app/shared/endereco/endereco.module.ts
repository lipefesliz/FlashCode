import { NgModule } from '@angular/core';
import { EnderecoComponent } from './endereco.component';
import { SharedModule } from '../shared.module';
import { NDDTitlebarModule } from '../ndd-ng-titlebar/component';
import { NDDTabsbarModule } from '../ndd-ng-tabsbar/component';

@NgModule({
    imports: [
        SharedModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
    ],
    declarations: [
        EnderecoComponent,
    ],
    exports: [
        EnderecoComponent,
    ],
    providers: [
    ],
})
export class EnderecoModule {

}
