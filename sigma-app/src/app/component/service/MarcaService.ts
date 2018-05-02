import { Headers, Http, HttpModule, RequestOptions, Response } from '@angular/http';
import { Observable, Subscription } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

import { MarcaModels } from './../model/marca/MarcaModels';
import { Injectable } from '@angular/core';

@Injectable()
export class MarcaService {

    private url = "http://localhost:53447/api/Marca/";

    constructor(private http: Http) {

    }

    post(Marca: MarcaModels) {
        return this.http
            .post(this.url, Marca);
    }

    getAll() {
        return this.http
            .get(this.url)
            .map((res: Response) => res.json());
    }

    getById(id: any) {
        return this.http
            .get(this.url + id)
            .map((res: Response) => res.json());
    }

    put(id:any, Marca:MarcaModels){
        return this.http
            .put(this.url + id, Marca);
            
    }
}