using Mordo.Bluetooth;
using Mordo.Desktop.MessageProcessing;
using Ninject.Modules;

namespace Mordo.Desktop.Initialize
{
    class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommunicator>().To<Communicator>();
            Bind<IMessageProcessor>().To<MessageProcessor>();
            Bind<IMessageBuilder>().To<MessageBuilder>();
        }
    }
}
