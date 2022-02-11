namespace GherkinOnlineEditor;

public class FileManager
{
    public List<string> FileContent { get; } = new List<string>();

    public void AddFeatureFile(string content)
    {
        FileContent.Add(content);
    }
}