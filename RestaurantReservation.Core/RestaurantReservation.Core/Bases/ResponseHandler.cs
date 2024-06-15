
namespace RestaurantReservation.Core.Bases;
public class ResponseHandler
{

    public ResponseHandler()
    {

    }
    public Response<T> Deleted<T>()
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = "Deleted Successfully"
        };
    }
    public Response<T> Success<T>(T entity, object Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = "Added Successfully",
            Meta = Meta
        };
    }
    public Response<T> Unauthorized<T>()
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = "UnAuthorized"
        };
    }
    public Response<T> BadRequest<T>(T entity)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = "Bad Request",
        };
    }


    public Response<T> NotFound<T>(string message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message == null ? "Not Found" : message
        };
    }

    public Response<T> Created<T>(T entity, object Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
            Message = "Created Success",
            Meta = Meta
        };
    }
    public Response<T> BadRequest<T>(string msg)
    {
        return new Response<T>()
        {
            Data = default(T),
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = msg ?? "Bad Request", 
        };
    }

}

