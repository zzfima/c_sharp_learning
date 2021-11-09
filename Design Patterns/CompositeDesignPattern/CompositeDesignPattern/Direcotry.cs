namespace CompositeDesignPattern
{
    internal class Direcotry : IFile
    {
        private List<IFile> _files;

        public Direcotry()
        {
            _files = new List<IFile>();
        }

        public void AddFile(IFile file)
        {
            _files.Add(file);
        }

        public string GetName()
        {
            return "dir";
        }

        public int GetSize()
        {
            int size = _files.Sum(s => s.GetSize());
            return size;
        }
    }
}
