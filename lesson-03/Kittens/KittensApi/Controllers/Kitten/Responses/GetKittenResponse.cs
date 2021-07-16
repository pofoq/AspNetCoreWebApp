using System.Collections.Generic;
using BusinessLayer.Abstraction.Dto;

namespace KittensApi.Controllers.Kitten.Responses
{
    public class GetKittenResponse
    {
        public IEnumerable<KittenDto> Kittens { get; set; }
    }
}
