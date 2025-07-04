//An Action in C# is a delegate type used to represent a method that returns void and can take zero or more parameters.
Action sayHello = () => Console.WriteLine("Hello");
sayHello();  // prints "Hello"

Action<int> printNumber = x => Console.WriteLine(x);
printNumber(42);  // prints "42"