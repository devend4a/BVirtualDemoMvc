using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class UserLogin
    {
        public static List<UserInfo> loginDb = new List<UserInfo>();

        public static UserInfo Login(string userName, string password, bool isProctor)
        {
            var obj = loginDb.Where(P => P.UserName.ToLower().Trim() == userName.ToLower().Trim() && P.IsProctor == isProctor).FirstOrDefault();
            if (obj == null)
            {
                obj = new UserInfo() { UID = Guid.NewGuid().ToString().ToLower(), IsProctor = isProctor, UserName = userName.Trim().ToLower() };
                loginDb.Add(obj);
            }

            return obj;
        }
    }


    public class UserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsProctor { get; set; }
        public string ConnectionId { get; set; }
        public string UID { get; set; }
    }
}