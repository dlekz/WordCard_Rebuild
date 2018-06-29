using System.Windows.Input;

namespace WordCard_Rebuild {
    class Commands {
        private static RoutedUICommand _loadWords = new RoutedUICommand();
        private static RoutedUICommand _addWord = new RoutedUICommand();
        private static RoutedUICommand _updateWord = new RoutedUICommand();
        private static RoutedUICommand _deleteWord = new RoutedUICommand();

        public static RoutedUICommand LoadWords {
            set {
                string text = "Загрузка всех слов из БД";
                string name = "Загрузка слов";
                _loadWords = new RoutedUICommand(text,name,typeof(Commands));
            } get {
                return _loadWords;
            }
        }
        public static RoutedUICommand AddWord {
            set {
                string text = "Добвление нового слова в БД. Синхронизация данных в БД и GUI";
                string name = "Добавление слова";
                _addWord = new RoutedUICommand(text,name,typeof(Commands));
            } get {
                return _addWord;
            }
        }
        public static RoutedUICommand UpdateWord {
            set {
                string text = "Изменение слова в БД. Синхронизация данных в БД и GUI";
                string name = "Изменение слова";
                _updateWord = new RoutedUICommand(text,name,typeof(Commands));
            } get {
                return _updateWord;
            }
        }
        public static RoutedUICommand DeleteWord {
            set {
                string text = "Удаление слова из БД. Синхронизация данных в БД и GUI";
                string name = "Удаление слова";
                _deleteWord = new RoutedUICommand(text, name, typeof(Commands));
            } get {
                return _deleteWord;
            }
        }
    }
}
