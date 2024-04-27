//start from 100
namespace Domain.Enums;

public enum ReplyType
{
	reply = 600,
	attach = 601,
}

public static class ReplyTypeFunctions
{
    public static string GetDisplayName(this ReplyType replyType)
    {
        return replyType switch
        {
            ReplyType.reply => "replay",
            ReplyType.attach => "attach",
            _ => "",
        };
    }
}

