using Core.ValueObject.Staff.User;

namespace Web_API.Utilities;

internal sealed class ContextHelper
{
    public static UserId GetUserId(HttpContext httpContext)
    {
        var id = httpContext.User.Identity?.Name;
        if (id is null)
        {
            throw new NullReferenceException();
        }

        var guid = Guid.Parse(id);
        return new UserId(guid);
    }
}