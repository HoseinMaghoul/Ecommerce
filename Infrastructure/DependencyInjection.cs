// using Application.Pipelines;
using Domain.Entities;
using Domain.Enums;
using Domain.IServices;
using Infrastructure.DBContext;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{

public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
    services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
    services.AddScoped<IUserService, UserService>();
	services.AddScoped<IContactService, ContactService>();
	services.AddScoped<ICategoryService, CategoriesService>();
    var serviceProvider = services.BuildServiceProvider();
	var dbContext = serviceProvider.GetService<ProjectDbContext>();
	InitializeDatabase(dbContext!);
    return services;
    }

    private static void InitializeDatabase(ProjectDbContext context)
    {
        context.Database.Migrate();


        AddOrEditVariable(context, 6, nameof(ReplyType));
        foreach (ReplyType item in Enum.GetValues(typeof(ReplyType)))
        {
            AddOrEditVariableValue(context, (int)item, item.GetDisplayName(), item.ToString(), 6);
        }



        

           foreach (Role role in Enum.GetValues(typeof(Role))){
			var record = context.Roles.Where(x => x.ID == (int)role).FirstOrDefault();
			if (record == null) {
				context.Roles.Add(new RoleEntity(){
					ID = (int)role,
					Name = role.ToString()
				});
			} else {
				record.Name = role.ToString();
			}
		}
 		context.SaveChanges();
    }



	private static void AddOrEditVariable(ProjectDbContext context, int ID, string Name)
	{
		var variable = context.Variables.Where(x => x.ID == ID).FirstOrDefault();
		if (variable == null)
		{
			context.Variables.Add(new VariablesEntity()
			{
				ID = ID,
				VaribaleName = Name
			});
		}
		else
		{
			variable.VaribaleName = Name;
		}
	}
    

    private static void AddOrEditVariableValue(ProjectDbContext context, int ID, string DisplaName, string Value, int VariableID)
	{
		var variableValue = context.VariableValues.Where(x => x.ID == ID).FirstOrDefault();
		if (variableValue == null)
		{
			context.VariableValues.Add(new VariableValuesEntity()
			{
				ID = ID,
				Value = Value,
				DisplaName = DisplaName,
				VariableID = VariableID
			});
		}
		else
		{
			variableValue.Value = Value;
			variableValue.DisplaName = DisplaName;
			variableValue.VariableID = VariableID;
		}
	}

}