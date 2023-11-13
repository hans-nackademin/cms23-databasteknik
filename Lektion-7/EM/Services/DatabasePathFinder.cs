using System.Diagnostics;

namespace EM.Services;

public static class DatabasePathFinder
{
    public static string GetPath()
    {
        var databaseName = "mauiapp2.db";

        try
        {
            if (DeviceInfo.Platform == DevicePlatform.Android)
                return Path.Combine(FileSystem.AppDataDirectory, databaseName);

            if (DeviceInfo.Platform == DevicePlatform.iOS)
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "..",
                    "Library",
                    databaseName);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return databaseName;
    }
}
