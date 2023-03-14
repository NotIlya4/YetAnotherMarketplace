using Api.Controllers.Views;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Attributes;

public class ProducesInternalExceptionAttribute : ProducesResponseTypeAttribute
{
    public ProducesInternalExceptionAttribute() 
        : base(typeof(InternalExceptionView), StatusCodes.Status500InternalServerError)
    {
        
    }
}