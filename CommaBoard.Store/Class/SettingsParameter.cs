
using CommaBoard.Store.Interface;
using MvvmCross.ViewModels;

namespace CommaBoard.Store.Class
{
    public class SettingsParameter : MvxNotifyPropertyChanged, ISettingsParameter
    {
        public int Id { get; }

        string _name;
        public string Name
        {
            get { return _name; }

            set { SetProperty(ref _name, value); }

        }

        string _stringValue;
        public string StringValue
        {
            get { return _stringValue; }

            set { SetProperty(ref _stringValue, value); }

        }

        int _intValue;
        public int IntValue
        {
            get { return _intValue; }

            set { SetProperty(ref _intValue, value); }

        }

        int _typeId;
        public int TypeId
        {
            get { return _typeId; }

            set { SetProperty(ref _typeId, value); }

        }

        string _type;
        public string Type
        {
            get { return _type; }

            set { SetProperty(ref _type, value); }
        }

    }
}
