using AutoMapper;
using MediatR;

public interface IRequestWithMapping<TResult> : IRequest<TResult>
{
    IConfigurationProvider Mapping { get; set; }
}

public class DeviceGetByIdRequest<TResult> : IRequestWithMapping<TResult>
{
    public DeviceGetByIdRequest(
        int id)
    {
        this.Id = id;
    }

    public int Id { get; }
    public IConfigurationProvider Mapping { get; set; }
}