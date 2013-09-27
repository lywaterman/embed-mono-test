using System;
using Mono.CSharp;
using System.IO;
using System.Collections;

public class MyPair {
	string key;
	object value;

	public MyPair(string key, object value) {
		this.key = key;
		this.value = value;
	}
}

public class MyHashtable : Hashtable {
	

}

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

	public static MyWorld world;

    public static int root(MyHashtable ht) {
		Console.WriteLine(ht);

		ht.Add("a", 1);
        world = new MyWorld();

        string file_gamedata = File.ReadAllText("game_data.cs");

        string file_gamefunc= File.ReadAllText("GameFunc.cs");

        string file_test_eval= File.ReadAllText("test_eval.cs");

        world.evaluator.Run(file_gamedata);
        world.evaluator.Run(file_gamefunc);
        world.evaluator.Run(file_test_eval);

		MyPair[] aa = new MyPair[] {new MyPair("a", 1), new MyPair("b", 2)};

		return 1;
    }

	public static object call(string str) {
		Console.WriteLine("sdfdsfdsfdsfdsfdsfdsfdsfdsf");
		return world.evaluator.Evaluate(str);
	}	

	public static void println(string str) {
		Console.WriteLine(str);
	}

    public static void Main(string[] args) {
        Console.WriteLine(
                System.Reflection.Assembly.GetExecutingAssembly().ImageRuntimeVersion);
    }
}

