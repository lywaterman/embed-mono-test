
GameData gd = new GameData();

var sw = new Stopwatch();

sw.Start();
//Console.WriteLine(GameFunc.fib(40));
sw.Stop();

TimeSpan ts = sw.Elapsed;

string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
Console.WriteLine("RunTime " + elapsedTime);

var game_object = new GameFunc();

//Console.WriteLine(GameFunc.getX(gd));


