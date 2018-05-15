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

        public SqlQuery() { DefDataSet(); }
        public SqlQuery(string sqlConnect, 
                        IDictionary<string,string> sqlQuery) {
            try {
                string _sqlConnect = sqlConnect;
                string _sqlSelect = sqlQuery.Select(n => n.Value).ToString();
                var _dataAdapter = new MySqlDataAdapter(_sqlSelect, _sqlConnect);

                int i = 0;
                foreach (var query in sqlQuery) {
                    _dataAdapter.TableMappings.Add($"Table{i}",query.Key);
                    i++;
                }
                _dataSet = new DataSet();
                _dataAdapter.Fill(_dataSet); 
            } catch(Exception ex) { Console.WriteLine(ex); }          
        }

        public List<WordTable> GetWordCard(){
                DataTable words = _dataSet.Tables["Word"];
                DataTable imgs = _dataSet.Tables["Img"];
            return (
                from word in words.AsEnumerable()
                join img in imgs.AsEnumerable()
                on word.Field<int>("WordId") equals img.Field<int>("ImgId")
                select new WordTable (
                    word.Field<int>("WordId"),
                    word.Field<string>("WordName"),
                    word.Field<string>("TransName"),
                    img.Field<string>("imgPath"),
                    word.Field<int>("Status")
                )
            ).ToList();
        }

        public string SetSelect(string[] tableList) {
            string result = "";
            foreach (string el in tableList) {
                result += $"SELECT * FROM {el};";
            }
            return result;
        }
// Default dataset parameters
        public void DefDataSet() {
            // _sqlConnect = "Database=worddb;Data Source=localhost;"+
            //               "User Id=lekz;PassWord=30d04d93v;";
            // _sqlSelect = "SELECT * FROM word; SELECT * FROM img;";

            // _dataAdapter = new SqlDataAdapter(_sqlSelect, _sqlConnect);

            // _dataAdapter.TableMappings.Add("Table0","Word");
            // _dataAdapter.TableMappings.Add("Table1","Img");
            
            // _dataSet = new DataSet();
            // _dataAdapter.Fill(_dataSet);

            // _dataRelation = _dataSet.Relations.Add("Word_Img",
            //     _dataSet.Tables["Word"].Columns["WordId"],
            //     _dataSet.Tables["Img"].Columns["ImgId"]
            // );

            // word = _dataSet.Tables["Word"];
            // img = _dataSet.Tables["Img"];
        }

        public void DataExport(){
            // var query = (
            //     from w in word
            //     from i in img
            //     where w.Field<int>("WordId") = i.Field<int>("ImgId")
            //     select new WordTable (
            //         w.Field<int>("WordId"),
            //         w.Field<string>("WordName"),
            //         w.Field<string>("TransName"),
            //         i.Field<string>("imgPath"),
            //         w.Field<int>("Status")
            //     )
            // ).ToList();
        }
    }
}
