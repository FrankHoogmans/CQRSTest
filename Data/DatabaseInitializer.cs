using Microsoft.AspNetCore.DataProtection;

namespace CQRSTest.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context, IDataProtectionProvider dataProtectionProvider)
        {
            var deviceType = new DeviceType
            {
                Name = "The best device type",
                FunctionalConfiguration = Configuration.Optional,
                SecureContent = dataProtectionProvider.CreateProtector("Secure").Protect("Some secure text")
            };
            context.DeviceTypes.Add(deviceType);

            context.Devices.Add(new Device
            {
                Name = "The best device",
                Uid = "DEVICE001",
                DeviceType = deviceType,
            });
            context.SaveChanges();
        }
    }
}
