using Microsoft.AspNetCore.Mvc;

namespace Api.ControllersAttributes;

public class ProducesOkAttribute : ProducesResponseTypeAttribute
{
    public ProducesOkAttribute() : 
        base(StatusCodes.Status200OK)
    {
        
    }
}