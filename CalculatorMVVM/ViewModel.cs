using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using System.Windows.Forms;

namespace CalculatorMVVM
{
    class ViewModel : INotifyPropertyChanged
    {
        Model model;
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            model = new Model();
            model.PropertyChanged += (s, e) => NotifyPropertyChanged(e.PropertyName);

            TypeCommand = new RoutedCommand();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string OuterString { get { return model.OuterString; } }

        public double Result { get { return model.Result; } }

        public RoutedCommand TypeCommand { get; }

        public void EnterStr(object sender, ExecutedRoutedEventArgs e)
        { model.AddString(e.Parameter.ToString()) ; }
    }
}
