

public class imageFolder
{

    private string path;
    private string FolderName;
    private int numberOfPics = 0;
    private string firstPic;

    public imageFolder()
    {

    }

    public imageFolder(string path, string folderName)
    {
        this.path = path;
        FolderName = folderName;
    }

    public string getPath()
    {
        return path;
    }

    public void setPath(string path)
    {
        this.path = path;
    }

    public string getFolderName()
    {
        return FolderName;
    }

    public void setFolderName(string folderName)
    {
        FolderName = folderName;
    }

    public int getNumberOfPics()
    {
        return numberOfPics;
    }

    public void setNumberOfPics(int numberOfPics)
    {
        this.numberOfPics = numberOfPics;
    }

    public void addpics()
    {
        this.numberOfPics++;
    }

    public string getFirstPic()
    {
        return firstPic;
    }

    public void setFirstPic(string firstPic)
    {
        this.firstPic = firstPic;
    }
}
