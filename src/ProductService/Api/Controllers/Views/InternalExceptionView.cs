using Api.Swagger.Enrichers.InternalExceptionView;

namespace Api.Controllers.Views;

public class InternalExceptionView
{
    [InternalExceptionTitle]
    public required string Title { get; set; }
    [InternalExceptionDetail]
    public required string Detail { get; set; }
}