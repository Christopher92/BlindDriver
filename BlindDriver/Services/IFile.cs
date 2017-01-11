namespace BlindDriver
{
    public interface IFile
    {
        void SaveText(string fileName, string text);
        string ReadText(string fileName);
        bool FileExists(string fileName);
    }
}
