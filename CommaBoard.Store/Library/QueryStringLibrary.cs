
using System.Collections.Generic;
using System.Text;
using CommaBoard.Store.Class;

namespace CommaBoard.Store.Library
{
    public static class QueryStringLibrary
    {

        #region     Settings Parameters

        public static string QS_UpdateSettingsParameter(SettingsParameter pm)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE SettingsParameter ");
            sb.Append("SET StringValue = \"" + pm.StringValue + "\" , IntValue = " + pm.IntValue + " ");
            sb.Append("WHERE Id = " + pm.Id + " ");

            return sb.ToString();
        }

        public static string QS_LoadSettingsParameters()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Select sp.Id, sp.Name AS Name, sp.StringValue AS StringValue, sp.IntValue AS IntValue, st.Type AS Type ");
            sb.Append("From SettingsParameter sp ");
            sb.Append("Join SettingsType st On sp.TypeId = st.Id");

            return sb.ToString();
        }

        public static string QS_LoadSettingsParametersByType(string type)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Select sp.Id, sp.Name AS Name, sp.StringValue AS StringValue, sp.IntValue AS IntValue, sp.TypeId as TypeId, st.Type AS Type ");
            sb.Append("From SettingsParameter sp ");
            sb.Append("Join SettingsType st On sp.TypeId = st.Id ");
            sb.Append("Where Type = \"" + type  + "\"");

            return sb.ToString();
        }

        #endregion

        #region     CommaBoard Buttons

        public static string QS_LoadCommaBoardButtons()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select Id, Name, Buffer, SendData, ClickAndRelease, RequiresNumber, Value ");
            sb.Append("From CommaBoardButton ");
            return sb.ToString();
        }

        #endregion
    }
}
