namespace Delegates.FileWork;

public class FileProcessr
{
    public event EventHandler<FileEventArgs>? FileFound;

    public bool Cancellation { get; set; }

    public void Find(string catalog)
    {
        foreach (var findFile in Directory.EnumerateFiles(catalog))
        {
            if (Cancellation) { break; }

            Thread.Sleep(200);

            FileInfo fileInfo;

            try
            {
                fileInfo = new FileInfo(findFile);

                if (fileInfo.Exists)
                {
                    if (FileFound != null)
                    {
                        FileFound(this, new FileEventArgs(fileInfo));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
    }
}
