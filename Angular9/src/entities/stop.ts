import { Flight } from './flight';

export class Stop
{
    stopId : number;
    city : string;
    flightid: number;
    flight: Flight;

    constructor(city: string) {
        this.city = city
    }
}