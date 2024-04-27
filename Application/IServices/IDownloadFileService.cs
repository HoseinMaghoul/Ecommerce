using Domain.DTOs;

namespace Application.IServices;

public interface IDownloadFileService
{
    string CreateDownloadFileToken(string filePath,bool isInMainDir, long UserID, int expireInMinutes = 1);
    bool CheckTokenValidation(string token);
    DownloadFileTokenData GetDownloadFileDataFromToken(string token);
}