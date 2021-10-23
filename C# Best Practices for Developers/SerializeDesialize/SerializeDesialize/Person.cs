using System;
using System.IO;
using System.Runtime.Serialization;

namespace SerializeDeserialize
{
    class DisposableObject : IDisposable
    {
        IDisposable _disposableObject;
        protected bool _disposed;
        private string _name;

        public DisposableObject(string name)
        {
            _name = name;
            _disposableObject = new FileStream(_name, FileMode.Create);
        }

        #region Dispose
        ~DisposableObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            else
                _disposed = true;

            if (disposing)
            {
                _disposableObject.Dispose();
            }

            //free unmanaged
            File.Delete(_name);
        }
        #endregion
    }

    [Serializable]
    public class Person : ISerializable
    {
        public Person()
        {

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }
    }
}