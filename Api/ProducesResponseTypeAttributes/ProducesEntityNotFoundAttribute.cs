using Infrastructure.ExceptionCatching.ExceptionMappers.BadResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProducesResponseTypeAttributes;

public class ProducesEntityNotFoundAttribute : ProducesResponseTypeAttribute
{
    public ProducesEntityNotFoundAttribute() : 
        base(typeof(BadResponseDto), 404)
    {
        
    }
}