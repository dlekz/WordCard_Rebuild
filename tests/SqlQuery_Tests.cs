using System;
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
            WordTable word = sql.words[0];
            if (word.Word != actualFirstWord) {
                throw new Exception($"{word.Word} != {actualFirstWord}");
            }
        }
        [TestMethod]
        public void GetWord_Test() {
            int id = 1;
            string actualWordName = "a_test";
            
            WordTable word = sql.GetWordById(id);

            if (word.Word != actualWordName) {
                throw new Exception($"{word.Word} != {actualWordName}");
            }
        }
        [TestMethod]
        public void Update_Test_Translate() {
            int id = 1;
            string translate = "test_5";
            
            sql.Update(id,translate);

            var newSql = SqlQuery.Create();
            WordTable word = newSql.GetWordById(id);            

            if (word.Translate != translate) {
                throw new Exception($"{word.Translate} != {translate}");
            }
        }
    }
}
