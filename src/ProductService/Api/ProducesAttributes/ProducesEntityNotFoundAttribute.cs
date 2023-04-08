using Api.ExceptionViews;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProducesAttributes;

public class ProducesEntityNotFoundAttribute : ProducesResponseTypeAttribute
{
    public ProducesEntityNotFoundAttribute() : base(typeof(EntityNotFoundExceptionView), StatusCodes.Status404NotFound)
    {
        
    }
}