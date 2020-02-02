using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalculatorMVVM
{
    class Model : INotifyPropertyChanged
    {
        private string outerstring;
        private double result;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string OuterString { 
            get { return outerstring; } 
            private set 
            {
                outerstring = value;
                NotifyPropertyChanged();
            } 
        }

        public double Result
        {
            get { return result; }
            private set 
            { 
                result = value;
                NotifyPropertyChanged();
            }
        }

        public void AddString(string str)
        { OuterString += str; }

        public void RemoveLastChar()
        { OuterString = OuterString.Remove(OuterString.Length); }

        public void ClearString()
        { OuterString = string.Empty; }

        public void CalcResult()
        {
            try 
            {
                Result = double.Parse(OuterString);
            } catch (FormatException) { OuterString = "Что-то не так"; }
        }
    }
}
