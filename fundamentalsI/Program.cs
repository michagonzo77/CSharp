// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

for (int i = 1; i <= 255; i++){
    Console.WriteLine(i);
}

Random rand = new Random();
int sum = 0;
for (int i = 1; i <= 5; i++){
    sum += rand.Next(10,21);
}
Console.WriteLine(sum);


for (int i = 1; i <= 100; i++){
    if (i % 3 == 0 && i % 5 == 0)
    {
        continue;
    } else if (i % 3 == 0 || i % 5 == 0){
        Console.WriteLine(i);
    }
}

for (int i = 1; i <= 100; i++){
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    } else if (i % 3 == 0){
        Console.WriteLine("Fizz");
    } else if (i % 5 == 0){
        Console.WriteLine("Buzz");
    }
}
int ii = 1;
while(ii <= 100)
{
    if (ii % 15 == 0)
    {
        Console.WriteLine("FizzBuzz");
    } else if (ii % 3 == 0){
        Console.WriteLine("Fizz");
    } else if (ii % 5 == 0){
        Console.WriteLine("Buzz");
    }
    ii++;
}