import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/shared/header.component';
import { LocationSearchComponent } from './components/locationsearch/locationsearch.component';
import { WeatherComponent } from './components/weather/weather.component';
import { WeatherTemperaturePipe } from './components/weather/weather-temp.pipe';
import { ImagesComponent } from './components/images/images.component';
import { GalleryComponent } from './components/images/gallery.component';
import { TwitterComponent } from './components/twitter/twitter.component';
import { MeetupComponent } from './components/meetup/meetup.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        HomeComponent,
        HeaderComponent,
        LocationSearchComponent,
        WeatherComponent,
        WeatherTemperaturePipe,
        ImagesComponent,
        GalleryComponent,
        TwitterComponent,
        MeetupComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
