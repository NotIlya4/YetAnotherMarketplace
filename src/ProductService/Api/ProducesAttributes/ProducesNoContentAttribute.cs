using Microsoft.AspNetCore.Mvc;

namespace Api.ProducesAttributes;

public class ProducesNoContentAttribute : ProducesResponseTypeAttribute
{
    public ProducesNoContentAttribute() 
        : base(StatusCodes.Status204NoContent)
    {
        
    }
}