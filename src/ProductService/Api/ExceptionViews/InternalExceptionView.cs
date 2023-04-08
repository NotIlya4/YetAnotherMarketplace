using Api.SwaggerEnrichers.InternalExceptionView;

namespace Api.ExceptionViews;

public class InternalExceptionView
{
    [InternalExceptionTitle]
    public required string Title { get; set; }
    [InternalExceptionDetail]
    public required string Detail { get; set; }
}