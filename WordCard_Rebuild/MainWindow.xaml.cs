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
        private CommandBinding ReloadWords { set; get; }
        private CommandBinding PrintWords { set; get; }
        private CommandBinding AddWord { set; get; }
        private CommandBinding UpdateWord { set; get; }
        private CommandBinding DeleteWord { set; get; }

        public MainWindow() {
            InitializeComponent();
            this.Background = SystemColors.ControlBrush;

            _sql = SqlQuery.Create();

            LoadWords = new CommandBinding(Commands.LoadWords);
            ReloadWords = new CommandBinding(Commands.ReloadWords);
            PrintWords = new CommandBinding(Commands.PrintWords);
            AddWord = new CommandBinding(Commands.AddWord);
            UpdateWord = new CommandBinding(Commands.UpdateWord);
            DeleteWord = new CommandBinding(Commands.DeleteWord);

            this.CommandBindings.Add(LoadWords);
            this.CommandBindings.Add(ReloadWords);
            this.CommandBindings.Add(PrintWords);
            this.CommandBindings.Add(AddWord);
            this.CommandBindings.Add(UpdateWord);
            this.CommandBindings.Add(DeleteWord);

            LoadWords.Executed += LoadWords_Executed;
            ReloadWords.Executed += ReloadWords_Executed;
            PrintWords.Executed += PrintWords_Executed;
            AddWord.Executed += AddWord_Executed;
            UpdateWord.Executed += UpdateWord_Executed;
            DeleteWord.Executed += DeleteWord_Executed;

            this.MainGrid.Loaded += LoadWords_Executed;
            bAddWord.Command = AddWord.Command;
            bUpdateWord.Command = UpdateWord.Command;
            bDeleteWord.Command = DeleteWord.Command;
            bPrintWords.Command = PrintWords.Command;
        }

        private void LoadWords_Executed(object sender, RoutedEventArgs e) {
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
        private void ReloadWords_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show("This is reload data");
        }
        private void PrintWords_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show("This is output to print");
        }
        private void AddWord_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show("This is new word");
        }
        private void UpdateWord_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show("This is update this word");
        }
        private void DeleteWord_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show("This is delete this word");
        }

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
