using AutoMapper;

public class SimpleDeviceViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string DeviceTypeName { get; set; }
}

public class SimpleDeviceViewModelProfile : Profile
{
    public SimpleDeviceViewModelProfile()
    {
        CreateMap<Device, SimpleDeviceViewModel>()
            .ForMember(dto => dto.DeviceTypeName, conf => conf.MapFrom(ol => ol.DeviceType.Name));
    }
}