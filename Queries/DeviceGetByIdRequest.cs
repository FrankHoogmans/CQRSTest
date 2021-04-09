using AutoMapper;
using MediatR;

public class DeviceGetByIdRequest<TResult> : IRequest<TResult>
{
    public DeviceGetByIdRequest(
        int id,
        IConfigurationProvider mapping)
    {
        this.Id = id;
        this.Mapping = mapping;
    }

    public int Id { get; }
    public IConfigurationProvider Mapping { get; }
}