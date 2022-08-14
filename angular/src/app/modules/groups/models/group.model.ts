import { UserData } from "../../users/models/users/user-data.model";

export interface Group {
    Id: string,
    Name: string;
    Members: UserData[],
}