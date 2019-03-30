using System.IO;

namespace Gihan.Helpers.Exception
{
    public interface IByEventThrower<T>
    {
        event ErrorEventHandler<T> ExceptionThrowed;
    }


    public class ByEventThrower<T> : IByEventThrower<T>
    {
        private T Owner { get; set; }

        private event ErrorEventHandler<T> InnerExceptionThrowed;
        public event ErrorEventHandler<T> ExceptionThrowed
        {
            add => InnerExceptionThrowed += value;
            remove => InnerExceptionThrowed -= value;
        }

        public ByEventThrower(T owner) => Owner = owner;

        public void Throw(System.Exception err)
        {
            var errArgs = new ErrorEventArgs(err);
            InnerExceptionThrowed?.Invoke(Owner, errArgs);
        }
    }
}
