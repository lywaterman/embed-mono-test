public class MyPair {
	string key;
	object value;

	public MyPair(string key, object value) {
		this.key = key;
		this.value = value;
	}
}

public class GameFunc {
    public static int getX(GameData gd) {
        return gd.x; 
    }

	public static string printself(string str) {
		Console.WriteLine(str);
		return str;
	}

	public static MyPair[] getPair() {

		return new MyPair[] {new MyPair("a", 1)};
	}

	public static Array getInt() {
		return new int[] {1};
	}

    public static int fib(int n) {
        if (n < 2) {
            return n;
        } else {
            return fib(n-1) + fib(n-2);
        } 
    }
}


