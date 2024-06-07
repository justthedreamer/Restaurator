using System.Text;
using System.Text.Json;

namespace Razor_App.ApiClient.Utilities;

public static class SerializeHelper
{
    public static StringContent CreateJsonStringContent(object obj)
    {
        var json = JsonSerializer.Serialize(obj);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return content;
    }
}