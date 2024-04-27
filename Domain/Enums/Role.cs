namespace Domain.Enums;
//start from 0
public enum Role
{
	SupperAdmin = 0,
}
public static class RoleConstants
{
	public const string SupperAdminName = "SupperAdmin";

	public static string GetRoleName(this Role role)
	{
		switch (role)
		{
			case Role.SupperAdmin:
				return SupperAdminName;
			default:
				break;
		}
		return "";
	}
	public static string GetRoleNameById(string role)
	{
		switch (role)
		{
			case "0": return SupperAdminName;
			default:
				break;
		}
		return "";
	}
}
