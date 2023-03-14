using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Attributes;

public class ProducesNoContentAttribute : ProducesResponseTypeAttribute
{
    public ProducesNoContentAttribute() 
        : base(StatusCodes.Status204NoContent)
    {
        
    }
}