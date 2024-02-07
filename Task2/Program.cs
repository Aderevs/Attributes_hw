namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enrter X:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enrter Y:");
            int y = int.Parse(Console.ReadLine());
            /*Console.WriteLine($"X + Y = {Calculator.Addition(x,y)}");
            Console.WriteLine($"X - Y = {Calculator.Substruction(x,y)}");
            Console.WriteLine($"X * Y = {Calculator.Multiplying(x,y)}");
            Console.WriteLine($"X / Y = {Calculator.Division(x,y)}");*/
            Console.WriteLine($"X + Y = {Calculator.Add(x, y)}");
            Console.WriteLine($"X - Y = {Calculator.Sub(x, y)}");
            Console.WriteLine($"X * Y = {Calculator.Mul(x, y)}");
            Console.WriteLine($"X / Y = {Calculator.Div(x, y)}");

        }
    }
}
