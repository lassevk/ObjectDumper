<Query Kind="Program">
  <Reference Relative="..\ObjectDumper\bin\Debug\ObjectDumper.dll">C:\Dev\VS.NET\ObjectDumper\ObjectDumper\bin\Debug\ObjectDumper.dll</Reference>
  <Namespace>ObjectDumper</Namespace>
</Query>

void Main()
{
	try
    {
        throw new InvalidOperationException("Test exception");
    }
    catch (Exception ex)
    {
        ObjectDumperExtensions.Dump(ex, "ex");
    }
}

// Define other methods and classes here
