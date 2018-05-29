using System;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace logic {
    public class SqlQuery {

        private MySqlConnection _sqlConnect { set; get; }
        private DataSet _dataSet {set; get;}
        public List<WordTable> words {private set;get;} 
        private DataContext _dataContext { set; get; }
        private MySqlDataAdapter _dataAdapter { set; get; }
        
        public SqlQuery() {}
        public static SqlQuery Create() {
            string connect = "Database=worddb_test;server=localhost;port=3306;User=lekz;Password=30d04d93v;";
            string select = "SELECT WORD_ID, WORD_NAME, WORD_TRANSLATE FROM WORDS;";
            SqlQuery sqlQuery = new SqlQuery();
            try {
                sqlQuery._sqlConnect = new MySqlConnection(connect);
                sqlQuery._dataAdapter = new MySqlDataAdapter(select,connect);
                sqlQuery._dataAdapter.TableMappings.Add("Table","Words");
                sqlQuery._dataSet = new DataSet();
                sqlQuery._dataAdapter.Fill(sqlQuery._dataSet);
                sqlQuery.words = sqlQuery.GetWords();
            } catch (Exception ex) {Console.WriteLine(ex);}
            return sqlQuery;            
        }
        private List<WordTable> GetWords(){
            return (
                from word in _dataSet.Tables["Words"].AsEnumerable()
                orderby word.Field<string>("WORD_NAME")
                select new WordTable(
                    word.Field<int>("WORD_ID"),
                    word.Field<string>("WORD_NAME"),
                    word.Field<string>("WORD_TRANSLATE"),
                    "", 0
                )
            ).ToList();
        }
        public WordTable GetWordById(int id) {
            return words.Where(el => el.Id == id).First();
        }
// It's work, but why?
        public void Update(int wordId, string translate) {
            _dataAdapter.Fill(_dataSet);
            var command = new MySqlCommand();
            command.CommandText = "UPDATE `WORDS` " +
                $"SET `WORD_TRANSLATE` = '{translate}'" + 
                $"WHERE `WORD_ID` = '{wordId}'";
            command.Connection = _sqlConnect;
            _dataAdapter.UpdateCommand = command;

            foreach(var el in _dataSet.Tables["Words"].AsEnumerable()){}

            var query = (from word in _dataSet.Tables["Words"].AsEnumerable()
                        where word.Field<int>("WORD_ID") == 2
                        select word).FirstOrDefault();
            query["WORD_TRANSLATE"]="";
            _dataAdapter.Update(_dataSet);
        }
    }
}
