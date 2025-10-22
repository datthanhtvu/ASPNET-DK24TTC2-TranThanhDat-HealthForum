using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSite.Data;

namespace MyWebSite.Business
{
    
   public class EnquiryService
    {
       private static EnquiryDAL db = new EnquiryDAL();
       #region[Enquiry_Paging]
       public static List<Data.Enquiry> Enquiry_Paging(string CurentPage, string PageSize, string Where, string Order)
       {
           return db.Enquiry_Paging(CurentPage, PageSize, Where, Order);
       }
       #endregion
        #region[GetByTop]
       public static List<Enquiry> Enquiryt_GetByTop(string Top, string Where, string Order)
        {
            return db.Enquiry_GetByTop(Top, Where, Order);
        }
        #endregion
        #region[GetById]
      
        #endregion
        #region[Insert]
       public static bool Enquiry_Insert(Enquiry data)
        {
            return db.Enquiry_Insert(data);
        }
        #endregion
       #region[Update]
       public static bool Enquiry_Update(Enquiry data)
       {
           return db.Enquiry_Update(data);
       }
       #endregion 
       public static bool Enquiry_Update_Click(string tag)
       {
           return db.Enquiry_Update_Click(tag);
       }


       #region[Delete]
       public static bool Enquiry_Delete(string Id)
        {
            return db.Enquiry_Delete(Id);
        }
        #endregion
    }
}
