import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule, BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
    imports: [
        BrowserModule,
        CoreModule,
        SharedModule,
        AppRoutingModule,
        NoopAnimationsModule,
        BrowserAnimationsModule,
    ],
    declarations: [
        AppComponent,
    ],
    bootstrap: [AppComponent],
})
export class AppModule { }
