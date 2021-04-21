using MediatR;

public class DeviceGetByIdRequest<TResult> : IRequest<TResult>
{
    public DeviceGetByIdRequest(int id)
    {
        this.Id = id;
    }

    public int Id { get; }
}