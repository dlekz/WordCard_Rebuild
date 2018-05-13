using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace logic {
    public class SqlQuery {
//        private string _sqlConnect {set;get;}
//        private string _sqlSelect {set; get;}
//        private SqlDataAdapter _dataAdapter {set; get;}
//        public DataRelation _dataRelation {set;get;}
//        public DataTable word {set;get;}
//        public DataTable img {set;get;}
        private DataSet _dataSet {set; get;}

        public SqlQuery() { DefDataSet(); }
        public SqlQuery(string sqlConnect, 
                        IDictionary<string,string> sqlQuery) {
            string _sqlConnect = sqlConnect;
            string _sqlSelect = sqlQuery.Select(n => n.Value).ToString();
            var _dataAdapter = new SqlDataAdapter(_sqlSelect, _sqlConnect);

            int i = 0;
            foreach (var query in sqlQuery) {
                _dataAdapter.TableMappings.Add($"Table{i}",query.Key);
                i++;
            }
            _dataSet = new DataSet();
            _dataAdapter.Fill(_dataSet);            
        }

        public List<WordTable> GetWordCard(){
            return (
                from word in _dataSet.Tables["Word"]
                from img in _dataSet.Tables["Img"]
                where word.Columns["WordId"] == img.Columns["ImgId"]
                select new {
                    Id = word.Columns["WordId"],
                    Word = word.Columns["WordName"],
                    Translate = word.Columns["TransName"],
                    ImgPath = img.Columns["imgPath"],
                    Status = word.Columns["Status"],
                }
                // select new WordTable (
                //     word.Columns["WordId"],
                //     word.Columns["WordName"],
                //     word.Columns["TransName"],
                //     img.Columns["imgPath"],
                //     word.Columns["Status"]
                // )
            );
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
