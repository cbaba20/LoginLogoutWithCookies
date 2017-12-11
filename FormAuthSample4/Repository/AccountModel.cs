using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAuthSample4.Repository
{
    public class AccountModel
    {
        public bool login(string username,string password)
        {
            return username.Equals("abc", StringComparison.CurrentCultureIgnoreCase)
                && password.Equals("123", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}