import { AvioCompan } from './aviocompany';

export class User
{
    id : number;
    name : string;
    lastname : string;
    username : string;
    password : string;
    address : string;
    email : string;
    phone : string;
    type : string;
    aviocompanyid: number;
    aviocompany: AvioCompan;

    constructor(id: number, name: string, lastname: string, username: string, password: string, address: string, type: string, email: string, phone: string) {
        this.id = id;
        this.name = name;
        this.lastname = lastname;
        this.username = username;
        this.address = address;
        this.password = password;
        this.type = type;
        this.email = email;
        this.phone = phone;
    }
}