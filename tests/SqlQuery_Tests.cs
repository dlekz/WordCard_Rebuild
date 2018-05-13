using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using logic;
using System.Collections.Generic;

namespace tests {
    [TestClass]
    public class SqlQuery_Tests {
        
        private string sqlConnect {set;get;}
        private Dictionary<string,string> sqlQuery {set;get;}

        public SqlQuery_Tests(){
            sqlConnect = "Database=worddb;Data Source=localhost;"+
                           "User Id=lekz;PassWord=30d04d93v;";
            sqlQuery = new Dictionary<string,string>();
                sqlQuery.Add("Word","SELECT * FROM word;");
                sqlQuery.Add("Img","SELECT * FROM img;");
        }

        [TestMethod]
        public void SelectData() {
            SqlQuery sql = new SqlQuery(sqlConnect,sqlQuery);
            

            if(1==1){
                throw new Exception(sql.word[0].ransName);
            }
        }
    }
}
