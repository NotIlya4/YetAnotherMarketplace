using Infrastructure.ExceptionCatching;
using Microsoft.AspNetCore.Mvc;

namespace Api.ControllersAttributes;

public class ProducesBadRequestAttribute : ProducesResponseTypeAttribute
{
    public ProducesBadRequestAttribute() : 
        base(typeof(BadResponseDto), 400)
    {
        
    }
}