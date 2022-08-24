export interface RestaurantDTO {
    id: string
    name: string
    star: number
    open: string
    close: string
    imageUrl: string
    webUrl: string
    items: ItemDTO[]
  }
  
  export interface ItemDTO {
    id: string
    name: string
    quantity: number
    imageUrl: string
    priceOrigin: number
    priceDiscount: number
    optionGroups: OptionGroupDTO[]
  }
  
  export interface OptionGroupDTO {
    id: string
    name: string
    isAvailable: boolean
    selectMin: number
    selectMax: number
    options: OptionDTO[]
  }
  
  export interface OptionDTO {
    id: string
    name: string
    isAvailable: boolean
    price: number
  }

  export interface ItemCardDTO {
    id: string
    name: string
    quantity: number
    total: number
  }
  export interface CardDTO {
    quantity: number
    item: ItemCardDTO
  }


  export interface UserOrderDTO {
    restaurantId: string,
    groupOrderId: string,
    itemCountAndIds: ItemDTO[]
    optionCountAndIds: ItemOptionDTO[]
    note: string
}

export interface ItemOrderDTO {
    id: string,
    count: number
}

export interface ItemOptionDTO {
    id: string,
    count: number
}

  