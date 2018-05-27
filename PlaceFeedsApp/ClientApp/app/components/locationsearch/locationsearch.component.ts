import { Component } from '@angular/core';

import { LocationSearchService } from '../../services/locationsearch/locationsearch.service';
import { TransferService } from '../../services/shared/transfer/transfer.service';
import { IPlaceObject } from '../../interfaces/IPlaceObject';

@Component({
    selector: 'location-search',
    templateUrl: './locationsearch.component.html',
    providers: [LocationSearchService]
})
export class LocationSearchComponent {

    locationName: string;
    locationLat: number;
    locationLong: number;
    result: any;
    errorMessage: string;
    placeObject: IPlaceObject;

    constructor(private _LocationSearchService: LocationSearchService, private _TransferService: TransferService) {
    }

    search(locationName: string): void {

        this.placeObject = {
            townName: '',
            admin_area_level2: '',
            admin_area_level1: '',
            country: '',
            formattedAddress: '',
            latitude: 0,
            longitude: 0,
            placeType: '',
        };


        this._LocationSearchService.getSearchData(locationName)
            .subscribe(data => {
                this.result = data;
                this.result = this.result.locationData;

                if (this.result.status == "OK") {
                    let results = this.result.results[0];
                    for (let addressComponent of results.address_components) {
                        switch (addressComponent.types[0]) {
                            case 'postal_town':
                                this.placeObject.townName = addressComponent.long_name;
                                break;
                            case 'administrative_area_level_2':
                                this.placeObject.admin_area_level2 = addressComponent.long_name;
                                break;
                            case 'administrative_area_level_1':
                                this.placeObject.admin_area_level1 = addressComponent.long_name;
                                break;
                            case 'country':
                                this.placeObject.country = addressComponent.long_name;
                                break;
                            default:
                                break;
                        }
                    }
                    this.placeObject.formattedAddress = results.formatted_address;
                    this.placeObject.latitude = results.geometry.location.lat;
                    this.placeObject.longitude = results.geometry.location.lng;
                    this.placeObject.placeType = results.types[0];

                    console.log(this.placeObject);
                    this._TransferService.transferData(this.placeObject);
                }
            });
    }


}