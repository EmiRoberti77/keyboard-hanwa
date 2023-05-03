using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.Store.Interface
{
    public interface ISettingsParameter
    {
        int Id { get; }

        string Name { get; set; }

        string StringValue { get; set; }

        int IntValue { get; set; }
        
        int TypeId { get; set; }

        string Type { get; set; }

    }
}
