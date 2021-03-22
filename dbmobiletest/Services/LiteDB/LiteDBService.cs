using System;
using System.Collections.Generic;
using dbmobiletest.Helpers;
using dbmobiletest.Models.DB;
using dbmobiletest.Services.LiteDB;
using LiteDB;
using Xamarin.Forms;

[assembly: Dependency(typeof(LiteDBService))]
namespace dbmobiletest.Services.LiteDB
{
    public class LiteDBService : ILiteDBService
    {
        #region Variables

        private LiteDatabase _db { get; set; }
        private LiteCollection<User> _liteCollection { get; set; }

        #endregion

        public LiteDBService()
        {
            ConnectDB();
            _liteCollection = (LiteCollection<User>)_db.GetCollection<User>();
        }

        private void ConnectDB()
        {
            var path = DependencyService.Get<IPathService>().GetLiteDatabasePath();
            _db = new LiteDatabase(path);
        }

        #region Methods

        public bool RegisterUser(User user)
        {
            try
            {
                var existItem = _liteCollection.FindById(user.Id);

                if (existItem == null)
                    _liteCollection.Insert(user);
                else
                    _liteCollection.Update(user);

                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(RegisterUser), ex);
            }

            return false;
        }

        public List<User> GetUsers()
        {
            try
            {
                var user = _liteCollection.FindAll();

                return new List<User>(user);
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(RegisterUser), ex);
            }

            return new List<User>();
        }

        public bool DeleteUser(User user)
        {
            try
            {
                var response = _liteCollection.Delete(user.Id);

                return response;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(RegisterUser), ex);
            }

            return false;
        }

        #endregion
    }
}
