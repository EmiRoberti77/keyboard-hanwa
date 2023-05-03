using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommaBoard.Store.Class;

namespace CommaBoard.Store.Interface
{ 
    public interface IDataSentModel
    {
        #region     Properties

        string Status { get; set; }

        bool StatusError { get; set; }

        int CurrentNumber { get; set; }

        bool WithNumber { get; set; }

        #endregion

        #region     Public Methods

        void Send_ButtonData();

        #endregion

    }
}