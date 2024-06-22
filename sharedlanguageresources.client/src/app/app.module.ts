import { HttpClientModule } from '@angular/common/http';
import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import en from '@angular/common/locales/en';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { registerLocaleData } from '@angular/common';
import { TranslocoModule, provideTransloco } from '@jsverse/transloco';
import { TranslocoHttpLoader } from './transloco-loader';

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    TranslocoModule
  ],  
  bootstrap: [AppComponent],
  providers: [
    provideTransloco({
      config: {
        availableLangs: ['en', 'es', 'fr'],
        defaultLang: 'en',
        // Remove this option if your application doesn't support changing language in runtime.
        reRenderOnLangChange: true,
        prodMode: !isDevMode(),
      },
      loader: TranslocoHttpLoader
    }),
  ],
})
export class AppModule { }
