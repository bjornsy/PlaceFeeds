import { Component, Input } from '@angular/core';

@Component({
    selector: 'gallery',
    templateUrl: './gallery.component.html',
    styleUrls: ['./gallery.component.css']
})
export class GalleryComponent {

    @Input()
    datasource: any;
    selectedImage: any;

    setSelectedImage(image: any) {
        this.selectedImage = image;
    }
}