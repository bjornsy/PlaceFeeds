import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/observable';
import 'rxjs/add/operator/map';

@Injectable()
export class TwitterService {

    constructor(private _http: Http) { }

    getTwitterData(placeName: string, lat: number, lon: number): Observable<any> {

        return this._http.get('Twitter/GetTwitterResults/?placeName=' + placeName + '&latitude=' + lat + '&longitude=' + lon)
            .map((response: Response) => response.json());
    }
};