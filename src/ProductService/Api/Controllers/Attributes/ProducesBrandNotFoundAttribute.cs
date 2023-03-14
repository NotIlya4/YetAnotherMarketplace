using Api.Controllers.Views;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Attributes;

public class ProducesBrandNotFoundAttribute : ProducesResponseTypeAttribute
{
    public ProducesBrandNotFoundAttribute() : 
        base(typeof(BrandNotFoundExceptionView), 404)
    {
        
    }
}