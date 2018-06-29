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
        private DataSet _dataSet { set; get; }
        public List<DataRow> Words {private set;get; }
        private DataContext _dataContext { set; get; }
        private MySqlDataAdapter _dataAdapter { set; get; }
        
        public SqlQuery() {}
        public static SqlQuery Create() {
            string connect = "Database=worddb_test;server=localhost;port=3306;User=lekz;Password=30d04d93v;";
            string select = "SELECT * FROM WORDS;";
            SqlQuery sqlQuery = new SqlQuery();
            try {
                sqlQuery._sqlConnect = new MySqlConnection(connect);
                sqlQuery._dataAdapter = new MySqlDataAdapter(select,connect);
                sqlQuery._dataAdapter.TableMappings.Add("Table","words");
                sqlQuery._dataSet = new DataSet();
                sqlQuery._dataAdapter.Fill(sqlQuery._dataSet);
                sqlQuery.Words = sqlQuery.GetWords();
            } catch (Exception ex) {Console.WriteLine(ex);}
            return sqlQuery;            
        }
        private List<DataRow> GetWords() {
            return _dataSet.Tables["Words"]
                    .AsEnumerable()
                    .OrderBy(word => word.Field<string>("WORD_NAME"))
                    .ToList();
        }
        public DataRow GetWordById(int id) {
            return Words.Where(word => word.Field<int>("WORD_ID") == id).First();
        }
        public enum  ActualRows {IMG_ID,WORD_NAME,WORD_TRANSLATE,STATUS,CONTEXT};
// It's work, but why?
        private string GetSet(string key, string value,int counter){
            string getSet =  $"`{key}` = '{value}'";
            getSet += (counter > 1) ? ", " : " ";
            if(counter < 0) 
                throw new ArgumentOutOfRangeException("counter","Argument don't be less then 0");
            return getSet;
        }
        public void Update(int wordId, Dictionary<ActualRows,string> values) {
            _dataAdapter.Fill(_dataSet);

            string[] actualRows = {"IMG_ID","WORD_NAME","WORD_TRANSLATE","STATUS","CONTEXT"}; 
            string commandUpdate = "UPDATE `WORDS` ";
            string commandSet = "SET ";
            string commandWhere = $"WHERE `WORD_ID` = {wordId} ";
            int counter = values.Count;
            DataRow dataRow = _dataSet.Tables["Words"].Rows[0];
            // dataRow["WORD_TRANSLATE"] = "";
            // dataRow["STATUS"] = 1;
            // commandSet = $"SET STATUS = {dataRow["STATUS"]} ";
            
            foreach (var el in values){
                string key = Enum.GetName(typeof(ActualRows),el.Key);
               if (!actualRows.Contains(key.ToUpper())) throw new Exception("This column not found");
                //DataRow dataRow = _dataSet.Tables["Words"].Rows[0];
                dataRow[key] = el.Value;
                commandSet += GetSet(key,el.Value,counter--);
            }

            var command = new MySqlCommand();
            command.CommandText = commandUpdate + commandSet + commandWhere + ";";
            command.Connection = _sqlConnect;
            _dataAdapter.UpdateCommand = command;
            _dataAdapter.Update(_dataSet);
        }

        public void Insert(){}
        public void Delete(){}
    }
}
