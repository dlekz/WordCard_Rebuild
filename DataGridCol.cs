using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.Generic;

namespace WordCard {
    public class DataGridCol: DataGridTextColumn {
        public DataGridCol(string header, Binding binding, float width) {
            this.Header = header;
            this.Binding = binding;
            this.Width = width;
            this.IsReadOnly = true;
        }
        public DataGridCol(string header, Binding binding, Visibility visibility) {
            this.Header = header;
            this.Binding = binding;
            this.Visibility = Visibility.Hidden;
            this.IsReadOnly = true;
        }
        public DataGridCol(string header, Binding binding) {
            this.Header = header;
            this.Binding = binding;
            this.IsReadOnly = true;
        }
        
    }

    public class DataGridCheckBoxCol : DataGridCheckBoxColumn {
        public DataGridCheckBoxCol(string header, Binding binding) {
            this.Header = header;
            this.Binding = binding;
            this.Width = 10;
        }
    }

    public class DataGridComboBoxCol : DataGridComboBoxColumn {
        public DataGridComboBoxCol(string header, string[] src, Binding binding) {
            this.Header = header;
            this.ItemsSource = src;
            this.SelectedValueBinding = binding;
        }
    }

}
