import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class LocationSearchService {
    //Uses google geocode api to get lat/long and also check it is a real place
    //https://developers.google.com/maps/documentation/geocoding/intro

    constructor(private _http: Http) { }

    getSearchData(locationName: string): Observable<any> {
        return this._http.get('LocationSearch/GetLocationData/' + locationName)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    public handleError(error: Response) {
        console.log(error);
        return Observable.throw(error.json().error || 'Server error');
    }

};