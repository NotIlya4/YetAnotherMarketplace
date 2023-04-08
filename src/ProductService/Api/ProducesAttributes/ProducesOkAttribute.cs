using Microsoft.AspNetCore.Mvc;

namespace Api.ProducesAttributes;

public class ProducesOkAttribute : ProducesResponseTypeAttribute
{
    public ProducesOkAttribute() : 
        base(StatusCodes.Status200OK)
    {
        
    }
}