using AutoMapper.Extensions.ExpressionMapping;
using CQRSTest.Data;
using CQRSTest.Queries.Handlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQRSTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase()
                        .AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("CQRSTest"));

            services.AddControllersWithViews();
            services.AddDataProtection();
            services.AddTransient<SecureValueConverter>();

            // Init MediatR
            services.AddMediatR(typeof(Startup).Assembly);

            // Todo: Figure out if we can omit this... this sucks...
            // The default .NET DI container doesn't support the open generic in this implementation...
            services.AddTransient(typeof(IRequestHandler<DeviceGetByIdRequest<SimpleDeviceViewModel>, SimpleDeviceViewModel>), typeof(DeviceGetByIdRequestHandler<SimpleDeviceViewModel>));

            // Init AutoMapper with expression mapping
            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.AddMaps(typeof(Startup).Assembly);
            });

            // Init the database
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                var dataprotectionProvider = scope.ServiceProvider.GetRequiredService<IDataProtectionProvider>();
                DatabaseInitializer.Initialize(context, dataprotectionProvider);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
