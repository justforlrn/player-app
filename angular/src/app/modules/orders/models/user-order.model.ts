import { UserData } from '../../users/models/users/user-data.model';
import { ItemAndCount, OptionAndCount } from './item-and-count.model';

export interface UserOder {
  id: string;
  groupOrderId: string;
  userDto: UserData;
  itemAndCounts: ItemAndCount[];
  totalItem: number;
  note: string;
  optionAndCounts: OptionAndCount[];
  totalOption: number;
}
