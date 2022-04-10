namespace Core;

public class FolderNotFoundException : Exception
{
    public FolderNotFoundException(string folderPath) : base($"Can not find a folder with path {folderPath}")
    {
    }
};