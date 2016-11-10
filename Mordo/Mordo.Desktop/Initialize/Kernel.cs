using Ninject;

namespace Mordo.Desktop.Initialize
{
    public class Kernel
    {
        private static StandardKernel _default;
        public static StandardKernel Default
        {
            get
            {
                if (_default == null)
                {
                    var bindings = new Bindings();
                    _default = new StandardKernel(bindings);
                }
                return _default;
            }
        }
    }
}
