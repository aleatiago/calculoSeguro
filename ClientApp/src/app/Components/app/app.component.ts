import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppService } from '../shared/app.service';
import { Marca } from '../shared/marca.model';
import { Veiculo } from '../shared/veiculo.model';
import { Modelo } from '../shared/modelo.model';
import { DadosVeiculo } from '../shared/dadosVeiculo.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  title = 'Seguro';
  valorSeguro: number = 0;
  seguroForm: FormGroup;
  marcas: Marca[];
  veiculos: Veiculo[];
  modelos: Modelo[];
  idMarca: number;
  idVeiculo: number;
  dadosVeiculo: DadosVeiculo;

  constructor(
    private fb: FormBuilder,
    private appService: AppService
  ) {
    this.seguroForm = fb.group({
      'Nome': ['', Validators.required],
      'CPF': ['', Validators.required],
      'Idade': ['', Validators.required],
      'ValorVeiculo': ['', Validators.required],
      'Marca': ['', Validators.required],
      'Veiculo': ['', Validators.required],
      'Modelo': ['', Validators.required]
    });
  }



  submitForm(SeguroInput) {

    SeguroInput.ValorVeiculo = SeguroInput.ValorVeiculo.replace("R$", "").replace(".","").replace(",",".");
    SeguroInput.Marca = this.dadosVeiculo.marca;
    SeguroInput.Veiculo = this.dadosVeiculo.veiculo;
    SeguroInput.Modelo = this.dadosVeiculo.ano_modelo;

    this.appService.postCriarSeguro(SeguroInput)
      .subscribe(x => {
        this.valorSeguro = x;
      });


  }

  onMarcaChange(event) {
    this.appService.getVeiculos(event).subscribe(x => {
      this.veiculos = x;
      this.idMarca = event;
    });
  }

  onVeiculoChange(event) {
    this.appService.getModelos(this.idMarca, event).subscribe(x => {
      this.modelos = x;
      this.idVeiculo = event;
    });
  }

  onModeloChange(event) {
    this.appService.getDadosVeiculo(this.idMarca, this.idVeiculo, event).subscribe(x => {
      this.seguroForm.patchValue({ ValorVeiculo: x.preco });
      this.dadosVeiculo = x;
    });
  }

  ngOnInit(): void {
    this.appService.getMarcas().subscribe(x => {
      this.marcas = x;
    });
  }





}
