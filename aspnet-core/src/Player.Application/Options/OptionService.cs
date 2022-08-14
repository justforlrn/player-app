//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp;

//namespace Player.Options
//{
//    [RemoteService(IsEnabled = false)]
//    public class OptionService : PlayerAppService, IOptionService
//    {
//        private readonly IOptionRepository _optionRepository;
//        public OptionService(IOptionRepository optionRepository)
//        {
//            _optionRepository = optionRepository;
//        }
//        public async Task<OptionDto> CreateAsync(OptionDto input)
//        {

//            var option = await _optionRepository.FindAsync(input.Id);
//            if (option == null)
//            {
//                option = new Option(
//                    id: input.Id,
//                    name: input.Name,
//                    isAvailable: input.IsAvailable,
//                    price: input.Price
//                    );
//                await _optionRepository.InsertAsync(option);
//            }
//            return ObjectMapper.Map<Option, OptionDto>(option);
//        }
//    }
//}