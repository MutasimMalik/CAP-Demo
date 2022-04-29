using DotNetCore.CAP;

namespace CapDemo
{
    public class DemoReceiver : ICapSubscribe
    {
        [CapSubscribe("DemoMessage")]
        public void Handle(DateTime dateTime)
        {

        }
    }
}
