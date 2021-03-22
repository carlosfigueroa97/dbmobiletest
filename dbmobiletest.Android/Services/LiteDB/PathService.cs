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
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), Strings.LiteDBName);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            return path;
        }
    }
}