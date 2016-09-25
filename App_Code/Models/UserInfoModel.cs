using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfoModel
/// </summary>
public class UserInfoModel
{

    public UserInformation GetUserInformation(string guid)
    {
        ShopDBEntities4 db = new ShopDBEntities4();
        UserInformation info = (from x in db.UserInformations where x.GUID == guid select x).FirstOrDefault();
        
        return info;
    }
    public void InsertUserInformation(UserInformation info)
    {
        ShopDBEntities4 db = new ShopDBEntities4();
        db.UserInformations.Add(info);
        db.SaveChanges();
    }
}