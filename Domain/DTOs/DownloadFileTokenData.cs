namespace Domain.DTOs;
public record DownloadFileTokenData(string FilePath, bool IsMainDir, long UserID, DateTime ExpirationDateTime);