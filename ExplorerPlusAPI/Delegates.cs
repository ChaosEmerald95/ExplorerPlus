namespace ExplorerPlus.API
{
    //Hier kommen nur alle verwendeten Delegates rein. Somit ist noch ein Überblick über 
    //alle Delegates möglich
    public delegate void ExplorerPlusFilesystemHandler(string path); //wird auch bei Menüs verwendet
    public delegate void ExplorerPlusFilesystemHandlerEx(string path, ENTRY_TYPE type);
    public delegate void ExplorerPlusControlsMenuHandler();

    //Ein Enumerator, der bei ExplorerPlusFilesystemHandlerEx zum Einsatz kommt
    public enum ENTRY_TYPE
    {
        Drive,
        Directory,
        File
    }
}
