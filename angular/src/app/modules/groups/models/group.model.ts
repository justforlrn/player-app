import { UserData } from "../../users/models/users/user-data.model";

export interface Group {
    id: string,
    name: string;
    members: UserData[],
}
