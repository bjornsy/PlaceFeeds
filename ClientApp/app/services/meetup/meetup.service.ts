import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class MeetupService {

    constructor(private _http: Http) { }

    getMeetupData(latitude: number, longitude: number): Observable<Response> {

        return this._http.get(`api/Meetup/GetMeetupData/?latitude=${latitude}&longitude=${longitude}`)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }

    public handleError(error: Response) {
        console.log(error);
        return Observable.throw(error.json().error || 'Server error');
    }

};