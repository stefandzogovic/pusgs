export class Flight
{
    dtascend: Date;
    dtdescend: Date;
    duration: number;
    distance: number;
    ticketprice: number;
    stops: Array<string>;


    constructor(dtascend: Date, dtdescend: Date, duration: number, distance: number, ticketprice: number, stops: Array<string>)
    {
        this.distance = distance;
        this.dtascend = dtascend;
        this.dtdescend = dtdescend;
        this.ticketprice = ticketprice;
        this.stops = stops;
    }
}