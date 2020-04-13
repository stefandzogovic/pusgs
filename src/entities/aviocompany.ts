import { Flight } from './flight';

export class AvioCompan
{
    name : string;
    description : string;
    flight: Array<Flight>;
    

    constructor(name: string, description: string, flight: Array<Flight>)
    {
        this.name = name;
        this.description = description;
        this.flight = flight;
    }
}