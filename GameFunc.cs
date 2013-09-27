public class GameFunc {
    public static int getX(GameData gd) {
        return gd.x; 
    }

	public static string printself(string str) {
		Console.WriteLine(str);
		return str;
	}

    public static int fib(int n) {
        if (n < 2) {
            return n;
        } else {
            return fib(n-1) + fib(n-2);
        } 
    }
}


