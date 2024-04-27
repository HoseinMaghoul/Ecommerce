// namespace Infrastructure.FileSystem;

// using Application.IServices;
// using Infrastructure.FileSystem.Configs;
// using Infrastructure.FileSystem.Services;
// using Infrastructure.Services;
// using Microsoft.Extensions.DependencyInjection;
// public static class DependencyInjection
// {
//     public static IServiceCollection AddInfrastructureFileSystem(this IServiceCollection services, LicenseKeys licenseKeys)
//     {
//         services.AddScoped<IUploadFileService, UploadFileService>();
//         services.AddScoped<IFileManagementService,FileManagementService>();
//         services.AddScoped<IDownloadFileService, DownloadFileService>();
//         services.AddScoped<IFileConvertService, FileConvertService>();
//         Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey: licenseKeys.SyncfusionLicense);
//         return services;
//     }

// }