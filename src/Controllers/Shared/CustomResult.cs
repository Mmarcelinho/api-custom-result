namespace AspNetCore.WebApi.Controllers.Shared;

public class CustomResult
{

    public HttpStatusCode StatusCode { get; private set; }

    public bool Sucess { get; private set; }

    public object Data { get; private set; }

    public IEnumerable<string> Errors { get; private set; }

    public CustomResult(HttpStatusCode statuscode, bool sucess)
    {
        StatusCode = statuscode;
        Sucess = sucess;

    }

    public CustomResult(HttpStatusCode statusCode, bool sucess, object data) : this(statusCode, sucess) => Data = data;

    public CustomResult(HttpStatusCode statusCode, bool sucess, IEnumerable<string> errors) : this(statusCode, sucess) => Errors = errors;

    public CustomResult(HttpStatusCode statusCode, bool sucess, object data, IEnumerable<string> errors) : this(statusCode, sucess) => Errors = errors;

}
