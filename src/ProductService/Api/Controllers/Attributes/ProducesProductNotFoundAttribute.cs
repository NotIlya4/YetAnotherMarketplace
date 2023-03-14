using Api.Controllers.Views;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Attributes;

public class ProducesProductNotFoundAttribute : ProducesResponseTypeAttribute
{
    public ProducesProductNotFoundAttribute() : 
        base(typeof(ProductNotFoundExceptionView), 404)
    {
        
    }
}