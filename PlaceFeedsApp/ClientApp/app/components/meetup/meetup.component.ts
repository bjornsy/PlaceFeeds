import { Component } from '@angular/core';

import { TransferService } from '../../services/shared/transfer/transfer.service';
import { MeetupService } from '../../services/meetup/meetup.service';
import { IPlaceObject } from '../../interfaces/IPlaceObject';


@Component({
    selector: 'meetup-component',
    templateUrl: './meetup.component.html',
    providers: [MeetupService]
})
export class MeetupComponent {

    placeObject: IPlaceObject;
    result: any;
    meetupData: any;

    constructor(private _TransferService: TransferService, private _MeetupService: MeetupService) {
        this._TransferService.placeSearched$
            .subscribe(data => {
                this.placeObject = data;

                if (this.placeObject != null) {
                    this.getData(this.placeObject);
                }
            })
    }

    getData(placeObject: IPlaceObject) {
        this._MeetupService.getMeetupData(this.placeObject.latitude, this.placeObject.longitude)
            .subscribe(data => {
                this.result = data;
                this.meetupData = this.result.meetupData;
                this.meetupData = this.meetupData.slice(0, 5);
                console.log(this.meetupData)
            })
    }

}