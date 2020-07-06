import { Component, OnInit } from '@angular/core';
import { AppService } from '../shared/Services/app.service';
import { RelatorioMedia } from '../shared/Models/relatorioMedia.model';
import { SeguroVeiculo } from '../shared/Models/seguroVeiculo.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'relatorio',
  templateUrl: './relatorio.component.html',
  styleUrls: ['./relatorio.component.css']
})

export class RelatorioComponent implements OnInit {

  pesquisaForm: FormGroup;
  title = 'Relatórios';
  relMedias: RelatorioMedia[];
  todosSeguros: SeguroVeiculo[];
  load:boolean= true;

  constructor(
    private fb: FormBuilder,
    private appService: AppService
  ) {
    this.pesquisaForm = fb.group({
      'CPF': ['', Validators.required]
    });
  }

  submitForm(pesquisa) {
    this.load = true;
    this.appService.getRelatorioTodosSegurosCPF(pesquisa.CPF)
      .subscribe(x => {
        this.todosSeguros = x;
        this.load = false;
      });


  }

  ngOnInit(): void {
    this.appService.getRelatorioMediaSeguro().subscribe(x => {
      this.relMedias = x;
    });

    this.appService.getRelatorioTodosSeguros().subscribe(x => {
      this.todosSeguros = x;
      this.load = false;
    });

  }





}
