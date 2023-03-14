using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Attributes;

public class ProducesOkAttribute : ProducesResponseTypeAttribute
{
    public ProducesOkAttribute() : 
        base(StatusCodes.Status200OK)
    {
        
    }
}