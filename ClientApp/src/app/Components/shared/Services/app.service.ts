import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { SeguroInput } from '../Inputs/seguroInput.model';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { Marca } from '../Models/marca.model';
import { Veiculo } from '../veiculo.model';
import { Modelo } from '../Models/modelo.model';
import { DadosVeiculo } from '../Models/dadosVeiculo.model';
import { RelatorioMedia } from '../Models/relatorioMedia.model';
import { SeguroVeiculo } from '../Models/seguroVeiculo.model';

@Injectable()
export class AppService {
    headers: HttpHeaders = new HttpHeaders({ "Content-Type": "application/json" });
   

    constructor(private http: HttpClient) { }

    getRelatorioMediaSeguro(): Observable<RelatorioMedia[]> {
        return this.http
            .get(`${environment.apiGateway}/seguro-veiculo/relatorio-media`, { headers: this.headers })
            .pipe(catchError(this.handleError));
    }

    getRelatorioTodosSeguros(): Observable<SeguroVeiculo[]> {
        return this.http
            .get(`${environment.apiGateway}/seguro-veiculo/todos-seguros`, { headers: this.headers })
            .pipe(catchError(this.handleError));
    }

    getRelatorioTodosSegurosCPF(cpf: string): Observable<SeguroVeiculo[]> {
        return this.http
            .get(`${environment.apiGateway}/seguro-veiculo/buscar-seguros/${cpf}`, { headers: this.headers })
            .pipe(catchError(this.handleError));
    }

    getMarcas(): Observable<Marca[]> {
        return this.http
            .get(`http://fipeapi.appspot.com/api/1/carros/marcas.json`)
            .pipe(catchError(this.handleError));
    }

    getVeiculos(marca: number): Observable<Veiculo[]> {
        return this.http
            .get(`http://fipeapi.appspot.com/api/1/carros/veiculos/${marca}.json`)
            .pipe(catchError(this.handleError));
    }

    getModelos(marca: number, veiculo : number): Observable<Modelo[]> {
        return this.http
            .get(`http://fipeapi.appspot.com/api/1/carros/veiculo/${marca}/${veiculo}.json`)
            .pipe(catchError(this.handleError));
    }

    
    getDadosVeiculo(marca: number, veiculo : number, modelo: number): Observable<DadosVeiculo> {
        return this.http
            .get(`http://fipeapi.appspot.com/api/1/carros/veiculo/${marca}/${veiculo}/${modelo}.json`)
            .pipe(catchError(this.handleError));
    }


    postCriarSeguro(seguro: SeguroInput): Observable<number> {
        return this.http
            .post(`${environment.apiGateway}/seguro-veiculo/calcular-seguro-veiculo`, seguro, { headers: this.headers })
            .pipe(catchError(this.handleError));
    }


    handleError(error: any): Promise<any> {
        console.error("An error occurred", error); // mudar para gerar log de erro
        return Promise.reject(error);
    }
}