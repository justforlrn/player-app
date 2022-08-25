export interface ItemAndCount {
  item: Item;
  count: number;
}

export interface Item {
  id: string;
  name: string;
  imageUrl: string;
  priceOrigin: number;
  priceDiscount: number;
  optionGroups: OptionGroup[];
}

export interface OptionGroup {
  id: string;
  name: string;
  isAvailable: boolean;
  selectMin: number;
  selectMax: number;
  options: Option[];
}

export interface Option {
  id: string;
  name: string;
  isAvailable: boolean;
  price: number;
}

export interface OptionAndCount {
  option: Option;
  count: number;
}
