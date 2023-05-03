using System.Collections.Generic;
using CommaBoard.Store.Class;

namespace CommaBoard.Store.Interface
{
    public interface IDataAccess
    {
        void CreateQuery(string querystring);
        void DeleteQuery(string querystring);
        void UpdateQuery(string querystring);
        List<SettingsParameter> LoadSettings(string querystring);
        List<CommaBoardButton> LoadCommaBoardButtons(string querystring);

    }
}