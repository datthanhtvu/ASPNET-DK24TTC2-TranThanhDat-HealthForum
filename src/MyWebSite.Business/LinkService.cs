using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;
namespace MyWebSite.Business
{
public   class LinkService
    {
    private static LinkDAL db = new LinkDAL();
        #region[GetByTop]
    public static List<Link> Link_GetByTop(string Top,string Where,string Order)
       {
           return db.Link_GetByTop(Top,Where,Order);
       }

        #endregion
        #region[GetById]
    public static List<Link> Link_GetById(string Id)
    {
        return db.Link_GetById(Id);
    }
        #endregion
        #region[Insert]
    public static bool Link_Insert(Link data)
    {
        return db.Link_Insert(data);
    }
        #endregion
        #region[Update]
    public static bool Link_Update(Link data)
    {
        return db.Link_Update(data);
    }
        #endregion
        #region[Delete]
    public static bool Link_Delete(string Id)
    {
        return db.Link_Delete(Id);
    }
        #endregion
    }
}
