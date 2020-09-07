import { Flight } from './flight';

export class Destination
{
    destinationid: number;
    ascenddest: string;
    descenddest: string;
    flights: Array<Flight>;

    constructor(ascenddest: string, descenddest: string)
    {
        this.ascenddest = ascenddest;
        this.descenddest = descenddest;
    }
}