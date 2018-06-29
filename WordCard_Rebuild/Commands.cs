using System.Windows.Input;

namespace WordCard {
    class Commands {
        private static RoutedUICommand _loadWords = new RoutedUICommand();
        private static RoutedUICommand _reloadWords = new RoutedUICommand();
        private static RoutedUICommand _printWords = new RoutedUICommand();
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
        public static RoutedUICommand ReloadWords {
            set {
                string text = "Перезагрузка двнных в GUI";
                string name = "Перезагрузка слов";
                InputGestureCollection inputGestures = new InputGestureCollection();
                inputGestures.Add(new KeyGesture(Key.F5,ModifierKeys.None,"F5"));
                _reloadWords = new RoutedUICommand(text, name, typeof(Commands),inputGestures);
            } get {
                return _reloadWords;
            }
        }
        public static RoutedUICommand PrintWords {
            set {
                string text = "Отправка выбранных данных на печать";
                string name = "Печать слов";
                InputGestureCollection inputGestures = new InputGestureCollection();
                inputGestures.Add(new KeyGesture(Key.P,ModifierKeys.Control,"Ctrl + P"));
                _printWords = new RoutedUICommand(text, name, typeof(Commands), inputGestures);
            } get {
                return _printWords;
            }
        }
        public static RoutedUICommand AddWord {
            set {
                string text = "Добвление нового слова в БД. Синхронизация данных в БД и GUI";
                string name = "Добавление слова";
                InputGestureCollection inputGentures = new InputGestureCollection();
                inputGentures.Add(new KeyGesture(Key.N, ModifierKeys.Control, "Ctrl + N"));
                _addWord = new RoutedUICommand(text, name, typeof(Commands), inputGentures);
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
