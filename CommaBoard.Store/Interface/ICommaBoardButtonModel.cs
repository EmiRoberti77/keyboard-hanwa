
using System.Threading.Tasks;

namespace CommaBoard.Store.Interface
{
    public interface ICommaBoardButtonModel
    {
        bool DataSent { get; set; }

        void HandleButtonPress(ICommaBoardButton button );

    }
}