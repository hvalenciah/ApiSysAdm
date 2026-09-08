/**
 *
 * @file ResponseModel.cs
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

namespace ADP.API.Model.Model;
public class ResponseModel<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}
