using Infrastructure.ExceptionCatching;
using Microsoft.AspNetCore.Mvc;

namespace Api.ControllersAttributes;

public class ProducesNotFoundAttribute : ProducesResponseTypeAttribute
{
    public ProducesNotFoundAttribute() : 
        base(typeof(BadResponseDto), 404)
    {
        
    }
}