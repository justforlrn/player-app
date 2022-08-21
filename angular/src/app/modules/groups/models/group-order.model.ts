import { UserData } from '../../users/models/users/user-data.model';

export interface GroupOrder {
  id: string;
  groupId: string;
  restaurantId: string;
  restaurant: any;
  status: number;
  fromTime: string;
  toTime: string;
  discount: number;
  userOders: any[];
}
