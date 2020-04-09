export class User
{
    name : string;
    lastname : string;
    username : string;
    password : string;
    address : string;
    email : string;

    constructor(name: string, lastname: string, username: string, password: string, address: string, email: string) {
        this.name = name;
        this.lastname = lastname;
        this.username = username;
        this.address = address;
        this.password = password;
        this.email = email;
    }
}