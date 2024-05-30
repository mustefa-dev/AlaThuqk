using e_parliament.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlaThuqk.DATA;
using AlaThuqk.Helpers;
using AlaThuqk.Repository;
using AlaThuqk.Services;
using AlaThuqk.Helpers.OneSignal;
using AlaThuqk.Interface;
using AlaThuqk.Respository;
using BackEndStructuer.Services;
using Gaz_BackEnd.Services;

namespace AlaThuqk.Extensions{
    public static class ApplicationServicesExtension{
        public static IServiceCollection
            AddApplicationServices(this IServiceCollection services, IConfiguration config) {
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryServices, CategoryService>();
            services.AddScoped<IProductServices, ProductService>();
            services.AddScoped<IColorServices, ColorService>();
            services.AddScoped<ISizeServices, SizeService>();
            services.AddScoped<ITemplateServices, TemplateService>();
            services.AddScoped<IComponentServices, ComponentService>();
            services.AddScoped<IOrderServices, OrderService>();
            services.AddScoped<IFileService, FileService>();
            // services.AddScoped<IOrderItemServices, OrderItemService>();
            services.AddScoped<IPrintComponentServices, PrintComponentServices>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IGovernorateService, GovernoratesService>();
            services.AddScoped<ISettingServices, SettingServices>();



            services.AddScoped<IPrintComponentServices, PrintComponentServices>();
            // here to Add
services.AddScoped<IAddressServices, AddressServices>();

            return services;
        }
    }
}
