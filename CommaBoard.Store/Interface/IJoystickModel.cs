using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.Store.Interface
{
    public interface IJoystickModel
    {

        string JoystickStatus { get; set; }

        bool JoystickRequired { get; set; }

        int JoystickDelay { get; set; }

        void SaveJoystickSettings();

        void SearchForDevicesButtonPressed();

    }
}
