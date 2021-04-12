using System.Threading.Tasks;
using AutoMapper;
using MediatR;

public class SimpleDeviceViewModel : IModelWithMapping
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DeviceTypeName { get; set; }

    public IConfigurationProvider GetMapping()
    {
        return new MapperConfiguration(cfg =>
            cfg.CreateMap<Device, SimpleDeviceViewModel>()
            .ForMember(dto => dto.DeviceTypeName, conf => conf.MapFrom(ol => ol.DeviceType.Name)));
    }
}

public interface IModelWithMapping
{
    IConfigurationProvider GetMapping();
}

public interface IModelWithMappingFactory
{
    Task<T> Load<T>(IRequestWithMapping<T> request) where T : new();
}

public class ModelWithMappingFactory : IModelWithMappingFactory
{
    private readonly IMediator _mediator;

    public ModelWithMappingFactory(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public async Task<T> Load<T>(IRequestWithMapping<T> request) where T : new()
    {
        request.Mapping = ((IModelWithMapping)new T()).GetMapping();
        return await this._mediator.Send(request);
    }
}
