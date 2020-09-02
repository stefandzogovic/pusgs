import { Destination } from './destinations';

export class AvioCompan
{
    id : number;
    name : string;
    description : string;
    destinations: Array<Destination>;
    

    constructor(name: string, description: string, destinations: Array<Destination>)
    {
        this.name = name;
        this.description = description;
        this.destinations = destinations;
    }
}