using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace logic {
    public class SqlQuery {
        private DataSet _dataSet {set; get;}
        public List<WordTable> words {set;get;} 

        public SqlQuery(string sqlConnect, 
                        IDictionary<string,string> sqlQuery) {
            try {
                MySqlConnection _sqlConnect = new MySqlConnection(sqlConnect);
                _dataSet = new DataSet();
                int i = 0;
                foreach (var query in sqlQuery) {
                    new MySqlDataAdapter(query.Value,_sqlConnect)
                        .Fill(_dataSet, query.Key);
                    i++;
                }
                words = GetDataSet();
            } catch(Exception ex) { Console.WriteLine(ex); }          
        }
    
// return all words
        private List<WordTable> GetDataSet(){
            return (
                from word in _dataSet.Tables["Word"].AsEnumerable()
                join img in _dataSet.Tables["Img"].AsEnumerable()
                on word.Field<int>("WordId") equals img.Field<int>("ImgId")
                orderby word.Field<string>("WordName"), word.Field<string>("TransName")
                select new WordTable (
                    word.Field<int>("WordId"),
                    word.Field<string>("WordName"),
                    word.Field<string>("TransName"),
                    img.Field<string>("ImgPath"),
                    word.Field<int>("Status")
                )
            ).ToList();
        }
// return word for id
        public WordTable GetWord(int id) {
            return words.Where(el => el.Id == id).First();
        }
    }
}
