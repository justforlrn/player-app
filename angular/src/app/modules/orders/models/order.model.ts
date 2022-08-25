import { RestaurantDTO } from './restaurant.dto';
import { UserOder } from './user-order.model';

export interface OrderDto {
  id: string;
  groupId: string;
  restaurantId: string;
  restaurant: RestaurantDTO;
  status: number;
  fromTime: string;
  toTime: string;
  discount: number;
  userOders: UserOder[];
}
