import { Component, OnInit } from '@angular/core';
import { AppService } from '../shared/Services/app.service';
import { RelatorioMedia } from '../shared/Models/relatorioMedia.model';

@Component({
  selector: 'relatorio',
  templateUrl: './relatorio.component.html',
  styleUrls: ['./relatorio.component.css']
})

export class RelatorioComponent implements OnInit {

  title = 'Relatórios';
  relMedias: RelatorioMedia[];
  

  constructor(
    private appService: AppService
  ) {
   
  }

  ngOnInit(): void {
    this.appService.getRelatorioMediaSeguro().subscribe(x => {
      this.relMedias = x;
      console.log(x);
    });
  }





}
