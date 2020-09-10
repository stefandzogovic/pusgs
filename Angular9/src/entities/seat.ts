import { Stop } from './stop';
import { Flight } from './flight';

export class Seat
{
   seatId: number;
   reserved: boolean;
   name: string;
   flightId: number;
   flight: Flight;

    // constructor(dtascend: string, dtdescend: string, duration: number, distance: number, ticketprice: number, stops: Array<Stop>)
    // {
    //     this.distance = distance;
    //     this.dtascend = dtascend;
    //     this.dtdescend = dtdescend;
    //     this.ticketprice = ticketprice;
    //     this.stops = stops;
    //     this.duration = duration;
    // }
    /**
     *
     */
    constructor(name: string) {
        this.reserved = false;
        this.name = name
    }
}