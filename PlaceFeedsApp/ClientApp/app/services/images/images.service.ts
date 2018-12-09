import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/observable';
import 'rxjs/add/operator/map';

@Injectable()
export class ImageService {

    constructor(private _http: Http) { }

    getImageData(placeName: string, placeType: string, lat?: number, lon?: number): Observable<any> {

        let radius: number = null;
        let locationSearchString: string = null;

        if (placeType == 'locality') {
            radius = 10;
            locationSearchString = '&lat=' + lat + '&lon=' + lon + '&radius=' + radius + '&radius_units=km'
        }

        return this._http.get(`Image/GetImageData/?placeName=${placeName}&locationSearchString=${locationSearchString}`)
            .map((response: Response) => response.json());
    }

}