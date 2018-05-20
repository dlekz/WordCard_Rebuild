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
            sqlConnect = "Database=worddb_test;server=localhost;port=3306;"+
                           "User=lekz;Password=30d04d93v;";
            sqlQuery = new Dictionary<string,string>();
                sqlQuery.Add("Word","SELECT * FROM word;");
                sqlQuery.Add("Img","SELECT * FROM img;");
        }

        [TestMethod]
        public void GetWord_Test() {
            SqlQuery sql = new SqlQuery(sqlConnect, sqlQuery);
            int id = 1;
            string actualWordName = "a_test";
            
            WordTable word = sql.GetWord(id);

            if (word.Word != actualWordName) {
                throw new Exception($"{word.Word} != {actualWordName}");
            }
        }
    }
}
