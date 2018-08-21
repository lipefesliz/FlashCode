using System.Collections.Generic;

namespace Bank.WebAPI.OAuth
{
    public static class BaseUsers
    {
        public static IEnumerable<Users> Users()
        {
            return new List<Users>
            {
                new Users { Name = "Fulano", Password = "1234" },
                new Users { Name = "Beltrano", Password = "5678" },
                new Users { Name = "Sicrano", Password = "0912" }
            };
        }
    }
}