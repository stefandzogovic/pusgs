import { Flight } from './flight';

export class Destination
{
    ascenddest: string;
    descenddest: string;
    flights: Array<Flight>;

    constructor(ascenddest: string, descenddest: string, flights: Array<Flight>)
    {
        this.ascenddest = ascenddest;
        this.descenddest = descenddest;
        this.flights = flights;
    }
}