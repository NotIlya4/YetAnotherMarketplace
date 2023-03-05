using Domain.Exceptions;

namespace Infrastructure.Repositories.Primitives;

public record Pagination
{
    public int Offset { get; }
    public int Limit { get; }
    
    private const int MaxLimit = 50;
    
    public Pagination(int offset, int limit)
    {
        if (offset < 0)
        {
            throw new ValidationException($"offset must be grater than 0, actual value {offset}");
        }
        
        if (limit is < 1 or > MaxLimit)
        {
            throw new ValidationException($"limit must be grater than 0 and less {MaxLimit}, actual value {limit}");
        }

        Offset = offset;
        Limit = limit;
    }
}