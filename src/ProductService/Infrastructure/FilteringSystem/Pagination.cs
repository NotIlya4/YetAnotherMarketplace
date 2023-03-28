using Domain.Exceptions;

namespace Infrastructure.FilteringSystem;

public class Pagination
{
    public int Offset { get; }
    public int Limit { get; }

    public static int MaxLimit => 50;

    public Pagination(int offset, int limit)
    {
        if (offset < 0)
        {
            throw new ValidationException($"offset must be grater than 0, actual value {offset}");
        }
        
        if (limit < 1 || limit > MaxLimit)
        {
            throw new ValidationException($"limit must be grater than 0 and less {MaxLimit}, actual value {limit}");
        }

        Offset = offset;
        Limit = limit;
    }
}