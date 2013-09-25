using System;
using Mono.CSharp;
using System.IO;

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

    public static void root() {

        MyWorld world = new MyWorld();

        string file_gamedata = File.ReadAllText("game_data.cs");

        string file_gamefunc= File.ReadAllText("GameFunc.cs");

        string file_test_eval= File.ReadAllText("test_eval.cs");

        world.evaluator.Run(file_gamedata);
        world.evaluator.Run(file_gamefunc);
        world.evaluator.Run(file_test_eval);
    }

    public static void Main(string[] args) {
        Console.WriteLine(
                System.Reflection.Assembly.GetExecutingAssembly().ImageRuntimeVersion);
        MyWorld world = new MyWorld();
    }
}

