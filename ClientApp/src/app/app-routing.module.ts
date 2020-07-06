import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CalculoSeguroComponent } from './Components/calculo-seguro/calculo-seguro.component';
import { RelatorioComponent } from './Components/relatorios/relatorio.component';


const routes: Routes = [{ path: "calculo-seguro", component: CalculoSeguroComponent },
                        { path: "relatorios", component: RelatorioComponent },
                        { path: "", component: CalculoSeguroComponent }]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
