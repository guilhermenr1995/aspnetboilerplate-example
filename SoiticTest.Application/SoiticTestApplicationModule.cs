using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using SoiticTest.Authorization.Roles;
using SoiticTest.Authorization.Users;
using SoiticTest.Models;
using SoiticTest.Products.DTO;
using SoiticTest.Providers.Dto;
using SoiticTest.Roles.Dto;
using SoiticTest.Users.Dto;

namespace SoiticTest
{
    [DependsOn(typeof(SoiticTestCoreModule), typeof(AbpAutoMapperModule))]
    public class SoiticTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                #region Providers
                cfg.CreateMap<CreateProviderInput, Provider>().ReverseMap();
                cfg.CreateMap<UpdateProviderInput, Provider>().ReverseMap();
                cfg.CreateMap<DeleteProviderInput, Provider>().ReverseMap();
                #endregion


                #region Products
                cfg.CreateMap<CreateProductInput, Provider>().ReverseMap();
                cfg.CreateMap<UpdateProductInput, Provider>().ReverseMap();
                cfg.CreateMap<DeleteProductInput, Provider>().ReverseMap();
                #endregion
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                //Provider
                cfg.CreateMap<CreateProviderInput, Provider>().ReverseMap();
            });
        }
    }
}
