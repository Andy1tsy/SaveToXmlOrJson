using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SaveToXmlOrJson
{
    public class BaseForBinding : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseForBinding()
        {
            PropertyChanged += (sender, e) => { };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
