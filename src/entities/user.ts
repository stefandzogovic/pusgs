export class User
{
    id : number;
    name : string;
    lastname : string;
    username : string;
    password : string;
    address : string;

    constructor(name: string, lastname: string, username: string, password: string, address: string) {
        this.name = name;
        this.lastname = lastname;
        this.username = username;
        this.address = address;
        this.password = password;
    }
}