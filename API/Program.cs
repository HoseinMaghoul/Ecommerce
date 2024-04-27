using MediatR;
using Infrastructure;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Identity;
using Infrastructure.Identity.Configs;
using System.Reflection;
using Infrastructure.FileSystem.Configs;
// using Infrastructure.FileSystem;
using API.SwaggerSettings;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
{
	x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


string connectionString = builder.Configuration.GetConnectionString("API")!;
// string cacheDbConnectionString = builder.Configuration.GetConnectionString("CacheDatabase")!;
builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.OperationFilter<AddAcceptLanguageHeaderParameter>();
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
	opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Please enter token",
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
		Scheme = "bearer"
	});
	opt.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type=ReferenceType.SecurityScheme,
					Id="Bearer"
				}
			},
			new string[]{}
		}
	});
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	opt.IncludeXmlComments(xmlPath);
});


var jwtSettings = new JwtSettings();
builder.Configuration.Bind(nameof(JwtSettings), jwtSettings);
builder.Services.AddSingleton(jwtSettings);
// var filePathConfigs = new FilePathConfigs();
// builder.Configuration.Bind(nameof(FilePathConfigs), filePathConfigs);
// builder.Services.AddSingleton(filePathConfigs);
var downloadFileTokenSettings = new DownloadFileTokenSettings();
builder.Configuration.Bind(nameof(DownloadFileTokenSettings), downloadFileTokenSettings);
builder.Services.AddSingleton(downloadFileTokenSettings);
var licenses = new LicenseKeys();
builder.Configuration.Bind(nameof(LicenseKeys), licenses);
builder.Services.AddSingleton(licenses);



builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
	ValidateIssuer = true,
	ValidateAudience = true,
	ValidateLifetime = true,
	ValidateIssuerSigningKey = true,
	ValidIssuer = jwtSettings.Issuer,
	ValidAudience = jwtSettings.Audience,
	IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Secret)),
});


builder.Services.AddMediatR(cfg => {
	cfg.RegisterServicesFromAssembly(typeof(MediatorDI).Assembly);
});
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddInfrastructureIdentity();
// builder.Services.AddInfrastructureFileSystem(licenses);



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseStaticFiles();
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());




app.UseAuthentication();
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();

}

app.MapControllers();


app.Run();





// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// // builder.Services.AddEndpointsApiExplorer();
// // builder.Services.AddSwaggerGen();


// // Add services to the container.
// builder.Services.AddControllers().AddJsonOptions(x =>
// {
// 	x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
// });

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
