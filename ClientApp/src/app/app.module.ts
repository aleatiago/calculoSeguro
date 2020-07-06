import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './Components/app/app.component';
import { HttpClientModule } from '@angular/common/http'
import { AppService } from './Components/shared/Services/app.service';
import { RelatorioComponent } from './Components/relatorios/relatorio.component';
import { CalculoSeguroComponent } from './Components/calculo-seguro/calculo-seguro.component';

@NgModule({
  declarations: [
    AppComponent,
    RelatorioComponent,
    CalculoSeguroComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
