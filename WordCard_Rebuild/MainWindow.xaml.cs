using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using logic;

namespace WordCard {
    public struct Word {
        public int WordId { get; set; }
        public int ImgId { get; set; }
        public string WordName { get; set; }
        public string WordTranslate { get; set; }
        public int Status { get; set; }
        public string Context { get; set; }
    }

    public partial class MainWindow : Window {
        private SqlQuery _sql {set;get;}
        private List<DataRow> _words {set;get;}
        private List<Word> words {set;get;}

        public MainWindow() {
            InitializeComponent();
            this.Background = SystemColors.ControlBrush;

            _sql = SqlQuery.Create();
            _words = _sql.GetWords();
            words = GetWords(_sql.GetWords());
        }

        private List<Word> GetWords(List<DataRow> rows){
            List<Word> words = new List<Word>();
            for (int i = 0; i < rows.Count(); i++) {
                DataRow row = rows[i];
                Word word = new Word() {
                    WordId = (int)row["WORD_ID"],
//                    ImgId = (int?) row["IMG_ID"] ?? 0,
                    WordName = (string)row["WORD_NAME"],
                    WordTranslate = (string)row["WORD_TRANSLATE"],
                    //Status = (int?) row["STATUS"] ?? 0,
                    //Context = (string) row["CONTEXT"]
                };
                words.Add(word);
            }
            return words;
        }
        private void LoadContent(object sender, RoutedEventArgs e) {
            LoadContentToMainGrid();
        }
        public void LoadContentToMainGrid() {
            MainGrid.ItemsSource = words;
            int i = -1;
            MainGrid.Columns[++i] = new DataGridCol("WORD_ID", new Binding("WordId"),Visibility.Hidden);
            MainGrid.Columns[++i] = new DataGridCol("Изображение", new Binding("ImgId"),Visibility.Hidden);
            MainGrid.Columns[++i] = new DataGridCol("Слово", new Binding("WordName"));
            MainGrid.Columns[++i] = new DataGridCol("Перевод", new Binding("WordTranslate"));
            MainGrid.Columns[++i] = new DataGridCol("Статус", new Binding("Status"));
            MainGrid.Columns[++i] = new DataGridCol("Контекст", new Binding("Context"),Visibility.Hidden);
        }

        private void MainGrid_LoadingRow(object sender, DataGridRowEventArgs e){}
        private void MainGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e){}
        private void MainGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e){}
    }
}
