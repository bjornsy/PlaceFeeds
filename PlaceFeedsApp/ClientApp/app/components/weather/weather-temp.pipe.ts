import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
    name: 'temperatureFilter'
})
export class WeatherTemperaturePipe implements PipeTransform {

    transform(value: number, args: any[]): number {

        //Kelvin to celsius
        if (value && !isNaN(value) && args[0] === 'celsius') {
            let temp = (value - 273.15);
            let places = args[1];
            return Number(temp.toFixed(places));
        }
    }
}