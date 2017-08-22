import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class WeatherService {
    //Uses OpenWeatherMap

    constructor(private _http: Http) { }

    getWeatherData(lat: number, lon: number): Observable<Response> {

        return this._http.get(`api/Weather/GetWeatherData/?latitude=${lat}&longitude=${lon}`)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.log(error);
        return Observable.throw(error.json().error || 'Server error');
    }

};