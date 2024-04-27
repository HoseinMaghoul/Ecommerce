// using Domain.Pagination;
// using System.Linq.Expressions;

// namespace Infrastructure.Shared.HelperFunctions;

// public static class IQueryableExtensionFunctions
// {
// 	public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, bool isASC)
// 	{



// 		var type = typeof(T);
// 		var property = type.GetProperty(ordering);
// 		var parameter = Expression.Parameter(type, "p");
// 		var propertyAccess = Expression.MakeMemberAccess(parameter, property!);
// 		var orderByExp = Expression.Lambda(propertyAccess, parameter);
// 		MethodCallExpression resultExp = Expression.Call(typeof(Queryable), isASC ? "OrderBy" : "OrderByDescending",
// 			new Type[] { type, property!.PropertyType },
// 			source.Expression,
// 			Expression.Quote(orderByExp));
// 		return source.Provider.CreateQuery<T>(resultExp);
// 	}

// 	public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string parent, string child, bool isASC)
// 	{



// 		var type1 = typeof(T);
// 		var property1 = type1.GetProperty(parent);
// 		var parameter1 = Expression.Parameter(type1, "p");
// 		var propertyAccess1 = Expression.MakeMemberAccess(parameter1, property1!);
// 		var type = property1!.PropertyType;
// 		var property = type!.GetProperty(child);
// 		var propertyAccess = Expression.MakeMemberAccess(propertyAccess1, property!);
// 		var orderByExp = Expression.Lambda(propertyAccess, parameter1);
// 		MethodCallExpression resultExp = Expression.Call(typeof(Queryable), isASC ? "OrderBy" : "OrderByDescending",
// 			new Type[] { type1, property!.PropertyType },
// 			source.Expression,
// 			Expression.Quote(orderByExp));
// 		return source.Provider.CreateQuery<T>(resultExp);
// 	}

	
// 	public static (IQueryable<T>, PaginationResponse) Pagination<T>(this IQueryable<T> source, int page, int amountPerPage)
// 	{
// 		var total = source.Count();
// 		if (page == 0 || amountPerPage < 0)
// 		{
// 			return (source, new PaginationResponse(page, amountPerPage, total, 1));
// 		}
// 		var pageCount = (total % amountPerPage == 0 && total != 0) ? total / amountPerPage : (total / amountPerPage) + 1;

// 		return (source.Skip((page * amountPerPage) - amountPerPage).Take(amountPerPage)
// 			, new PaginationResponse(page, amountPerPage, total, (total == 0) ? 0 : pageCount));
// 	}
// 	public static IQueryable<T> Search<T>(this IQueryable<T> source, string searchKey, string search)
// 	{
// 		//TODO To be fixed
// 		var type = typeof(T);
// 		var property = type.GetProperty(searchKey);
// 		var parameter = Expression.Parameter(type, "p");
// 		var propertyAccess = Expression.MakeMemberAccess(parameter, property!);
// 		var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
// 		var contansStatement = Expression.Call(propertyAccess, containsMethod!, Expression.Constant(search, typeof(string)));
// 		var containsExp = Expression.Lambda(contansStatement, parameter);
// 		MethodCallExpression resultExp2 = Expression.Call(typeof(Queryable), nameof(Queryable.Where),
// 			new[] { typeof(T) },
// 			source.Expression,
// 			Expression.Quote(containsExp));
// 		return source.Provider.CreateQuery<T>(resultExp2);

// 	}
// }
