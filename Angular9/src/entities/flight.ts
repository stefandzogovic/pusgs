import { Stop } from './stop';
import { Seat } from './seat';

export class Flight
{
    flightId: number;
    dtaascend: string;
    dtadescend: string;
    duration: number;
    distance: number;
    ticketprice: number;
    stars: number;
    stops: Array<Stop>;
    seats: Array<Seat>;

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
    constructor() {
        this.stops = new Array<Stop>();
        this.seats = new Array<Seat>();
    }
}