import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { IPlaceObject } from '../../../interfaces/IPlaceObject';

@Injectable()
export class TransferService {
    //transfers placeObject data to components that require it after location search
    private placeSearched = new Subject<IPlaceObject>();

    placeSearched$ = this.placeSearched.asObservable();

    transferData(placeObject: IPlaceObject) {
        this.placeSearched.next(placeObject);
    }

};
