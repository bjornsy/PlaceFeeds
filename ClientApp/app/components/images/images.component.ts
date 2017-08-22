import { Component } from '@angular/core';
import { TransferService } from '../../services/shared/transfer/transfer.service';
import { ImageService } from '../../services/images/images.service';
import { GalleryComponent } from './gallery.component';
import { IPlaceObject } from '../../interfaces/IPlaceObject';

@Component({
    selector: 'images-component',
    templateUrl: './images.component.html',
    providers: [ImageService]
})
export class ImagesComponent {

    placeObject: IPlaceObject;
    result: any;
    imageData: any;
    placeName: string;
    imageList: any[];

    constructor(private _TransferService: TransferService, private _ImageService: ImageService) {
        this._TransferService.placeSearched$
            .subscribe(data => {
                this.placeObject = data;

                if (this.placeObject != null) {
                    this.getData(this.placeObject);
                }
            }
            )
    }

    getData(placeObject: IPlaceObject) {


        switch (this.placeObject.placeType) {
            case 'locality':
                this.placeName = this.placeObject.townName;
                break;
            case 'administrative_area_level_1':
                this.placeName = this.placeObject.admin_area_level1;
                break;
            case 'country':
                this.placeName = this.placeObject.country;
                break;
            default:
                this.placeName = this.placeObject.formattedAddress;
                break;
        }

        this._ImageService.getImageData(this.placeName, this.placeObject.placeType, this.placeObject.latitude, this.placeObject.longitude)
            .subscribe(data => {
                this.result = data;
                this.imageData = this.result.imageData.photos.photo;
                //Below is to get photos with unique owner ids for more variation

                this.imageData = this.filterUniqueOwnerImageData(this.imageData);
                console.log(this.imageData)


                //https://farm{farm-id}.staticflickr.com/{server-id}/{id}_{secret}_[mstzb].jpg
                //https://www.flickr.com/services/api/misc.urls.html


                this.imageList = [];

                for (let image of this.imageData) {
                    let imageUrls = {
                        photoUrl: '',
                        ownerUrl: ''
                    };
                    imageUrls.photoUrl = ('https://farm' + image.farm + '.staticflickr.com/' + image.server +
                        '/' + image.id + '_' + image.secret + '_b.jpg');

                    imageUrls.ownerUrl = ('https://www.flickr.com/photos/' + image.owner + '/' + image.id);

                    this.imageList.push(imageUrls);
                }
                console.log(this.imageList);

            })

    }

    filterUniqueOwnerImageData(imageData: [any]) {

        let uniqueOwners = [];
        for (let item of imageData) {
            if (uniqueOwners.length < 12) { //set to 12 images
                if (uniqueOwners.indexOf(item.owner) < 0) {  //if owner id doesn't exist in the array, add it
                    uniqueOwners.push(item.owner);
                }
            } else break;
        }

        let uniqueOwnerObj = {};
        //Convert to object to keep count of which owner has already been checked
        for (let owner of uniqueOwners) {
            uniqueOwnerObj[owner] = 0;
        }

        let keysOfUniqueImageData = [];
        for (let item of imageData) {
            if ((uniqueOwners.indexOf(item.owner) > -1) && (uniqueOwnerObj[item.owner] == 0)) {
                uniqueOwnerObj[item.owner] = 1;
                keysOfUniqueImageData.push(imageData.indexOf(item))  //get only keys of images with unique owner id who hasn't been checked yet
            }
        }

        let uniqueImageData: any = [];
        for (let i in keysOfUniqueImageData) {
            uniqueImageData[i] = imageData[keysOfUniqueImageData[i]];
        }

        return uniqueImageData;
    }


}