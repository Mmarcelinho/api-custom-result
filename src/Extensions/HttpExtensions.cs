namespace AspNetCore.WebApi.Extensions;

public static class HttpExtensions
{
    public static bool IsSucess(this HttpStatusCode statusCode) => new HttpResponseMessage(statusCode).IsSuccessStatusCode;

}
