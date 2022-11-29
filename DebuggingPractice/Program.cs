// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Challenge 1
// Had to remove quotes from bool value.
bool amProgrammer = true;
// Need either double or float to represent decimal
double Age = 27.9;
List<string> Names = new List<string>();
Names.Add("Monica");
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Hello", "0");
// dictionary expects string,string NOT string, int
MyDictionary.Add("Hi there", "0");
// This is a tricky one! Hint: look up what a char is in C#
// Had to use double quotes instead of single quotes.
string MyName = "MyName";
// Challenge 2
List<int> Numbers = new List<int>() {2,3,6,7,1,5};
for(int i = Numbers.Count - 1; i >= 0; i--)
{
    Console.WriteLine(Numbers[i]);
}
// Challenge 3
List<int> MoreNumbers = new List<int>() {12,7,10,-3,9};
foreach(int i in MoreNumbers)
{
    Console.WriteLine(i);
}
// Challenge 4
List<int> EvenMoreNumbers = new List<int> {3,6,9,12,14};
for (int idx = 0; idx < EvenMoreNumbers.Count; idx++){
    if(EvenMoreNumbers[idx] % 3 == 0)
    {
        EvenMoreNumbers[idx] = 0;
    }
}
foreach(int number in EvenMoreNumbers)
{
    Console.WriteLine(number);
}
// Challenge 5
// What can we learn from this error message?
string MyString = "superduberawesome";
// Can't change specific letter in string this way.
// MyString[7] = "p";
// Challenge 6
// // Hint: some bugs don't come with error messages
Random rand = new Random();
// .next(Int32) is exclusive of the number entered. Must increase to 13.
int randomNum = rand.Next(13);
if(randomNum == 12)
{
    Console.WriteLine("Hello");
}

