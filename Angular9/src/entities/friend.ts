import { User } from './user';

export class Friend
{
    MainUserId: number;
    MainUser:User;
    FriendUserId: number;
    FriendUser: User;
    Accepted: boolean;

    constructor()
    {

    }
}