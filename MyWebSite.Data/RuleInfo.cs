using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MyWebSite.Data
{
  public  class Rule
    {
        #region[Declare Variables  ]
        private string _Id;
        private string _Name;
        private string _Description;

        #endregion
        #region[ Public  Properties ]
        public string Id { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        #endregion
        #region[User IDataReader]
        public Rule RuleIDataReader(IDataReader dr)
        {
            Data.Rule obj = new Data.Rule();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Description = (dr["Description"] is DBNull) ? string.Empty : dr["Description"].ToString();
           
            return obj;
        }
        #endregion

    }
}
