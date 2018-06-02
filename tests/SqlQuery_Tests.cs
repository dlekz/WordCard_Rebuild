using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using logic;
using System.Collections.Generic;

namespace tests {
    [TestClass]
    public class SqlQuery_Tests {
        private SqlQuery sql {set; get;}

        public SqlQuery_Tests(){
            sql = SqlQuery.Create();
        }
        [TestMethod]
        public void GetWords_Test() {
            string actualFirstWord = "a_test";
            DataRow word = sql.words[0];
            if ((string)word["WORD_NAME"] != actualFirstWord) {
                throw new Exception($"{word["WORD_NAME"]} != {actualFirstWord}");
            }
        }
        [TestMethod]
        public void GetWord_Test() {
            int id = 1;
            string actualWordName = "a_test";
            
            DataRow word = sql.GetWordById(id);

            if ((string)word["WORD_NAME"] != actualWordName) {
                throw new Exception($"{(string)word["WORD_NAME"]} != {actualWordName}");
            }
        }
        [TestMethod]
        public void Update_Test_Translate() {
            int id = 1;
            string translate = "test_1";
            string status = "2";
            
           sql.Update(id, new Dictionary<SqlQuery.ActualRows,string>{
               {SqlQuery.ActualRows.WORD_TRANSLATE,translate},
               {SqlQuery.ActualRows.STATUS,status}
            });

            var newSql = SqlQuery.Create();
            DataRow word = newSql.GetWordById(id);            

            if ((string)word["WORD_TRANSLATE"] != translate) {
                throw new Exception($"{word["WORD_TRANSLATE"]} != {translate}");
            }
            if ((int)word["STATUS"] != Int32.Parse(status)) {
                throw new Exception($"{word["STATUS"]} != {status}");
            }

        }
    }
}
