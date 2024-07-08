namespace Delegates.FileWork;

public class FileEventArgs : EventArgs
{
    public FileEventArgs(FileInfo fileInfo)
    {
        FileEventInfo = fileInfo;
    }

    public FileInfo FileEventInfo { get; private set; }
}
