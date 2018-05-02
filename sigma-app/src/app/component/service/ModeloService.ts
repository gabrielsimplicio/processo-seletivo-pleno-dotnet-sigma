import { Headers, Http, HttpModule, RequestOptions, Response } from '@angular/http';
import { Observable, Subscription } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

import { Injectable } from '@angular/core';
import { ModeloModels } from '../model/modelo/ModeloModels';

@Injectable()
export class ModeloService {

    private url = "http://localhost:58481/api/Modelo/"

    constructor(private http: Http) {

    }

    post(Modelo: ModeloModels) {      
        return this.http
            .post(this.url, Modelo);            
    }

    put(id:any, Modelo:ModeloModels){
        return this.http
        .put(this.url + id, Modelo)
        .map((res: Response) => res.json());
    }

    getAll() {
        return this.http
            .get(this.url)
            .map((res: Response) => res.json());
    }

    getById(id:any){
        return this.http
        .get(this.url + id)
        .map((res: Response) => res.json());
    }
}