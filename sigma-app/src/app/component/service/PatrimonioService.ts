import { Headers, Http, HttpModule, RequestOptions, Response } from '@angular/http';
import { Observable, Subscription } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

import { Injectable } from '@angular/core';
import { PatrimonioModels } from '../model/patrimonio/PatriomonioModels';

@Injectable()
export class PatrimonioService {

    private url = "http://localhost:52928/api/Patrimonio/";

    constructor(private http: Http) {

    }

    post(patrimonio: PatrimonioModels) {
        return this.http
            .post(this.url, patrimonio)
            .map((res: Response) => res.json());
    }

    put(id: any, patrimonio: PatrimonioModels) {
        return this.http
            .put(this.url + id, patrimonio)
            .map((res: Response) => res.json());
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
}