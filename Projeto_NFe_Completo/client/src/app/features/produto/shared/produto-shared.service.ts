import { NgModule } from '@angular/core';

import { ProdutoService } from './produto.service';

@NgModule({
    providers: [
        ProdutoService,
    ],
})
export class ProdutoSharedModule {

}
