//using Player.Options;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp;

//namespace Player.Items
//{
//    [RemoteService(IsEnabled = false)]
//    public class ItemService: PlayerAppService, IItemService
//    {
//        private readonly IItemRepository _itemRepository;
//        private readonly IOptionService _optionService;
//        public ItemService(IItemRepository itemRepository, IOptionService optionService)
//        {
//            _itemRepository = itemRepository;
//            _optionService = optionService;
//        }
//        public async Task<ItemDto> CreateAsync(ItemDto input)
//        {

//            var item = await _itemRepository.FindAsync(input.Id);
//            if (item == null)
//            {
//                item = new Item(
//                    id: input.Id,
//                    name: input.Name,
//                    imageUrl: input.ImageUrl,
//                    priceOrigin: input.PriceOrigin,
//                    priceDiscount: input.PriceDiscount
//                    );
//                if(input.Options != null)
//                {
//                    var options = new List<Option>();
//                    for(var i = 0; i < input.Options.Count(); i++)
//                    {
//                        var optionDto = input.Options[i];
//                        var option = await _optionService.CreateAsync(optionDto);
//                        options.Add(option);
//                    }
//                }
//                await _itemRepository.InsertAsync(item);
//            }
//            return ObjectMapper.Map<Item, ItemDto>(item);
//        }
//    }
//}
