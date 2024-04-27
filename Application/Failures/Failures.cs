namespace Application.Failures;

public record Failure(int Code, string Message);

public record UserFailure(int Code, string Message) : Failure(Code, Message);

public record LoginFailure(int Code, string Message): Failure(Code, Message);

public record ContactFailure(int Code, string Message): Failure(Code, Message);

public record CategoryFailure(int Code, string Message): Failure(Code, Message);




public record AlreadyUserExistInSystem() : UserFailure(1, "Already User Exist In System And You can't Create New User");


public record UserNameOrPasswordIsInvalid() : LoginFailure(2, "UserName Or Password Is Invalid");

public record FailedToSaveMessage() : ContactFailure(3, "Failed to save message");

public record CanNotAddCategory() : CategoryFailure(4, "Can Not Add New Category");


public record CategoryCanNotBeNull() : CategoryFailure(5, "Category Can Not Be Null");


public record CategoryNameCanNotBeNull() : CategoryFailure(6, "Category Name Can Not Be Null");