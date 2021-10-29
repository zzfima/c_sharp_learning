using System;

namespace Logic
{
    public abstract class Duck : IDisposable
    {
        private bool _isDisposed;

        public Duck()
        {
            _isDisposed = false;
        }

        public virtual string Quack()
        {
            return "Can Quack";
        }

        public virtual string Swim()
        {
            return "Can Swim";
        }

        public abstract string Dislay();

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Duck()
        {
            Dispose(false);
        }

        protected void Dispose(bool dispose)
        {
            if (_isDisposed)
                return;

            if (dispose)
            {
                Console.WriteLine("Managed resources disposed");
            }
            Console.WriteLine("Unmanaged resources disposed");
            _isDisposed = true;
        }
        #endregion
    }
}