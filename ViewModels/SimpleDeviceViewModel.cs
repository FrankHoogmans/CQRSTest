using AutoMapper;
using CQRSTest.AutoMapper;

public class SimpleDeviceViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string DeviceTypeName { get; set; }

    public string SecureContent { get; set; }

    public bool RequiresConfiguration { get; set; }
}

public class SimpleDeviceViewModelProfile : Profile
{
    public SimpleDeviceViewModelProfile()
    {
        CreateMap<Device, SimpleDeviceViewModel>()
            .ForMember(dto => dto.DeviceTypeName, conf => conf.MapFrom(ol => ol.DeviceType.Name))
            .ForMember(dto => dto.RequiresConfiguration, conf => conf.MapFrom(ol => ol.DeviceType.FunctionalConfiguration != Configuration.NotSupported || ol.DeviceType.TechnicalConfiguration != Configuration.NotSupported))
            .ForMember(dto => dto.SecureContent, conf => conf.MapFrom(ol => ol.DeviceType.SecureContent));

        // Decryption mapping, could also be used for doing translations on enums or whatever value conversions that are not supported in Expressions
        CreateMap<SimpleDeviceViewModel, SimpleDeviceViewModel>()
            .ForMember(dto => dto.SecureContent, conf => conf.ConvertUsing<SecureValueConverter, string>());
    }
}

