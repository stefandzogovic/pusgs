export class Flight
{
    dtascend: string;
    dtdescend: string;
    duration: number;
    distance: number;
    ticketprice: number;
    stops: Array<string>;

    constructor(dtascend: string, dtdescend: string, duration: number, distance: number, ticketprice: number, stops: Array<string>)
    {
        this.distance = distance;
        this.dtascend = dtascend;
        this.dtdescend = dtdescend;
        this.ticketprice = ticketprice;
        this.stops = stops;
        this.duration = duration;
    }
}