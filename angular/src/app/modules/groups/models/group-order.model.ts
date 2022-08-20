import { UserData } from "../../users/models/users/user-data.model";

export interface GroupOrder {
    Id: string,
    Name: string;
    Members: UserData[],
}
