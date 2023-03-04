using Infrastructure.ExceptionCatching;
using Microsoft.AspNetCore.Mvc;

namespace Api.ControllersAttributes;

public class ProducesEntityNotFoundAttribute : ProducesResponseTypeAttribute
{
    public ProducesEntityNotFoundAttribute() : 
        base(typeof(BadResponseDto), 404)
    {
        
    }
}