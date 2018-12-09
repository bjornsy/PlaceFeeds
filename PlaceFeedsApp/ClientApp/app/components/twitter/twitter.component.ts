import { Component } from '@angular/core';

import { TransferService } from '../../services/shared/transfer/transfer.service';
import { TwitterService } from '../../services/twitter/twitter.service';
import { IPlaceObject } from '../../interfaces/IPlaceObject';

@Component({
    selector: 'twitter-component',
    templateUrl: './twitter.component.html',
    providers: [TwitterService]
})
export class TwitterComponent {

    placeObject: IPlaceObject;
    twitterData: any;

    constructor(private _TransferService: TransferService, private _TwitterService: TwitterService) {
        this._TransferService.placeSearched$
            .subscribe(data => {
                this.placeObject = data;

                if (this.placeObject != null) {
                    this.getData(this.placeObject);
                }
            })
    }

    getData(placeObject: IPlaceObject) {
        this._TwitterService.getTwitterData(placeObject.formattedAddress, placeObject.latitude, placeObject.longitude)
            .subscribe(twitterData => {
                this.twitterData = twitterData;
            })
    }

}

