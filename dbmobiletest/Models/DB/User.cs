using System;
namespace dbmobiletest.Models.DB
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }

        public int Status { get; set; }
    }
}
