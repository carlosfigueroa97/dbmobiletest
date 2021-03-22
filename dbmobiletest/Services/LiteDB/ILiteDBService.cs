using System;
using System.Collections.Generic;
using dbmobiletest.Models.DB;

namespace dbmobiletest.Services.LiteDB
{
    public interface ILiteDBService
    {
        bool RegisterUser(User user);

        List<User> GetUsers();
    }
}
