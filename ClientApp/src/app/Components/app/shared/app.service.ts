import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { SeguroInput } from './seguroInput.model';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { Marca } from './marca.model';
import { Veiculo } from './veiculo.model';
import { Modelo } from './modelo.model';
import { DadosVeiculo } from './dadosVeiculo.model';

@Injectable()
export class AppService {
    headers: HttpHeaders = new HttpHeaders({ "Content-Type": "application/json" });
   

    constructor(private http: HttpClient) { }

    getRelatorioSeguro(): Observable<SeguroInput[]> {
        return this.http
            .get(`${environment.apiGateway}/seguro-veiculo/relatorio`, { headers: this.headers })
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