using AutoMapper;
using MediatR;
using System.Threading.Tasks;

public record SimpleDeviceViewModel(int Id, string Name, string DeviceTypeName)
{
    public static async Task<SimpleDeviceViewModel> Load(IMediator mediator, int id)
    {
        var mapping = new MapperConfiguration(cfg =>
            cfg.CreateMap<Device, SimpleDeviceViewModel>()
            .ForMember(dto => dto.DeviceTypeName, conf => conf.MapFrom(ol => ol.DeviceType.Name)));

        return await mediator.Send(new DeviceGetByIdRequest<SimpleDeviceViewModel>(id, mapping));
    }
}
