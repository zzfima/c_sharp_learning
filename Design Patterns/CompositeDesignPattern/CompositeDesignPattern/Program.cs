using CompositeDesignPattern;

IFile file1 = new TextFile(10);

IFile file11 = new TextFile(11);

IFile file12 = new TextFile(12);

IFile file21 = new TextFile(13);

Direcotry root = new Direcotry();
Direcotry sub1 = new Direcotry();
Direcotry sub2 = new Direcotry();

root.AddFile(file1);
root.AddFile(sub1);
root.AddFile(sub2);

sub1.AddFile(file12);
sub1.AddFile(file11);

sub2.AddFile(file21);

Console.WriteLine(root.GetSize());