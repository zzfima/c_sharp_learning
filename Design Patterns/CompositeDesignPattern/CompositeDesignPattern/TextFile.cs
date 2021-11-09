namespace CompositeDesignPattern
{
    internal class TextFile : IFile
    {
        int _size;

        public TextFile(int size)
        {
            this._size = size;
        }

        public string GetName()
        {
            return "txt";
        }

        public int GetSize()
        {
            return _size;
        }
    }
}
