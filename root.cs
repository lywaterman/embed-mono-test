using System;
using Mono.CSharp;

class MyWorld {
	public Evaluator evaluator;

	public MyWorld ()
	{
        Console.WriteLine("sdfsf");
        var settings = new CompilerSettings() {Unsafe = true};
        var printer = new ConsoleReportPrinter ();
		evaluator = new Evaluator (new CompilerContext(settings, printer));
	}

	public bool Run(string code) {
		Console.WriteLine(code);
		return evaluator.Run("var x = 1;");
	}

    public static void Main(string[] args) {
        Console.WriteLine(
                System.Reflection.Assembly.GetExecutingAssembly().ImageRuntimeVersion);
        MyWorld world = new MyWorld();
    }
}

