using Api.ExceptionViews;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProducesAttributes;

public class ProducesInternalExceptionAttribute : ProducesResponseTypeAttribute
{
    public ProducesInternalExceptionAttribute() 
        : base(typeof(InternalExceptionView), StatusCodes.Status500InternalServerError)
    {
        
    }
}