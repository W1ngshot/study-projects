namespace Minio.S3;

public class FileModel
{
    public required string FileName { get; set; }
    
    public required IFormFile File { get; set; }
}