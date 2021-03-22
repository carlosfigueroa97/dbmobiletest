using System;
using System.IO;
using dbmobiletest.Droid.Services.LiteDB;
using dbmobiletest.Helpers;
using dbmobiletest.Services.LiteDB;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace dbmobiletest.Droid.Services.LiteDB
{
    public class PathService : IPathService
    {
        public string GetLiteDatabasePath()
        {
            var pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libFolder = Path.Combine(pathFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, Strings.LiteDBName);
        }
    }
}