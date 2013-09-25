public class GameFunc {
    public static int getX(GameData gd) {
        return gd.x; 
    }

    public static int fib(int n) {
        if (n < 2) {
            return n;
        } else {
            return fib(n-1) + fib(n-2);
        } 
    }
}


