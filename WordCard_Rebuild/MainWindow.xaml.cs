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

    public partial class MainWindow : Window {
        private SqlQuery _sql {set;get;}
        private List<DataRow> _words {set;get;}
        private List<Word> words {set;get;}

        private CommandBinding LoadWords { set; get; }
        private CommandBinding AddWord { set; get; }
        private CommandBinding UpdateWord { set; get; }
        private CommandBinding DeleteWord { set; get; }

        public MainWindow() {
            InitializeComponent();
            this.Background = SystemColors.ControlBrush;

            _sql = SqlQuery.Create();
//            words = GetWords(_sql.Words);

            LoadWords = new CommandBinding(Commands.LoadWords);
            AddWord = new CommandBinding(Commands.AddWord);
            UpdateWord = new CommandBinding(Commands.UpdateWord);
            DeleteWord = new CommandBinding(Commands.DeleteWord);

            this.CommandBindings.Add(LoadWords);
            this.CommandBindings.Add(AddWord);
            this.CommandBindings.Add(UpdateWord);
            this.CommandBindings.Add(DeleteWord);

            LoadWords.CanExecute += LoadWords_CanExecute;
            AddWord.CanExecute += AddWord_CanExecute;
            UpdateWord.CanExecute += UpdateWord_CanExecute;
            DeleteWord.CanExecute += DeleteWord_CanExecute;

            this.MainGrid.Loaded += LoadWords_CanExecute;
        }

        private void LoadWords_CanExecute(object sender, RoutedEventArgs e) {
            words = GetWords(_sql.Words);
            MainGrid.ItemsSource = words;
            int i = -1;
            MainGrid.Columns[++i] = new DataGridCol("WORD_ID", new Binding("WordId"), Visibility.Hidden);
            MainGrid.Columns[++i] = new DataGridCol("Изображение", new Binding("ImgId"), Visibility.Hidden);
            MainGrid.Columns[++i] = new DataGridCol("Слово", new Binding("WordName"));
            MainGrid.Columns[++i] = new DataGridCol("Перевод", new Binding("WordTranslate"));
            MainGrid.Columns[++i] = new DataGridCol("Статус", new Binding("Status"));
            MainGrid.Columns[++i] = new DataGridCol("Контекст", new Binding("Context"), Visibility.Hidden);
        }
        private void AddWord_CanExecute(object sender, CanExecuteRoutedEventArgs e) { }
        private void UpdateWord_CanExecute(object sender, CanExecuteRoutedEventArgs e) { }
        private void DeleteWord_CanExecute(object sender, CanExecuteRoutedEventArgs e) { }

        private List<Word> GetWords(List<DataRow> rows){
            List<Word> words = new List<Word>();
            for (int i = 0; i < rows.Count(); i++) {
                DataRow row = rows[i];
                Word word = new Word() {
                    WordId = (int)row["WORD_ID"],
                    WordName = (string)row["WORD_NAME"],
                    WordTranslate = (string)row["WORD_TRANSLATE"],
                };
                words.Add(word);
            }
            return words;
        }

        private void MainGrid_LoadingRow(object sender, DataGridRowEventArgs e){}
        private void MainGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e){}
        private void MainGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e){}
    }
}
