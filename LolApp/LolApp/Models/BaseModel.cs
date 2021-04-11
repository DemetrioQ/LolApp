using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LolApp.Models
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
