using System.Windows.Input;
using System;

namespace WordCard {
    [Obsolete]public class Commander {
        private static RoutedUICommand _addWordFromGui { set; get; }
        private static RoutedUICommand _addWordToDb { set; get; }
        private static RoutedUICommand _outputToWordApp { set; get; }

        public static RoutedUICommand getAddWordFromGui { get { return _addWordFromGui; } }
        public static RoutedUICommand getAddWordToDb { get { return _addWordToDb; } }
        public static RoutedUICommand getOutputToWordApp { get { return _outputToWordApp; } }

        static Commander() {
            InputGestureCollection addWordFromGui = new InputGestureCollection();
            InputGestureCollection addWordToDb = new InputGestureCollection();
            InputGestureCollection outputToWordApp = new InputGestureCollection();

            addWordFromGui.Add(new KeyGesture(Key.N, ModifierKeys.Control, "Cntl + N"));
            outputToWordApp.Add(new KeyGesture(Key.O,ModifierKeys.Control, "Cntrl + O"));

            _addWordFromGui = new RoutedUICommand("Добавление слова", "getAddWordFromGui", typeof(Commander),addWordFromGui);
            _addWordToDb = new RoutedUICommand("Добавление слова в ДБ", "getAddWordToDb", typeof(Commander));
            _outputToWordApp = new RoutedUICommand("Вывод в Word", "getOutputToWordApp", typeof(Commander), outputToWordApp);
        }
    }
}
