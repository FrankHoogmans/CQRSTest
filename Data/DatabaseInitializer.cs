using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSTest.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            var deviceType = new DeviceType
            {
                Name = "The best device type"
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
