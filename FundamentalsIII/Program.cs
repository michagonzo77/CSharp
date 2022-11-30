// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Given a List of strings, iterate through the List and print out all the values. 
// Bonus: How many different ways can you find to print out the contents of a List? 
// (There are at least 3! Check Google!)
static void PrintList(List<string> MyList)
{
    for (int i = 0; i < MyList.Count; i++){
        Console.WriteLine(MyList[i]);
    }
}
List<string> NamesList = new List<string>() {"Julie", "Harold", "James", "Monica"};
PrintList(NamesList);

// 2. Print Sum

// Given a List of integers, calculate and print the sum of the values.

static int SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    for (int i = 0; i < IntList.Count; i++){
        sum += IntList[i];
    }
    return sum;
}
List<int> ListInt = new List<int>() {-4,-11,1,-3,2,-5,3,12,4,5,6};
int[] ArrayInt = {-4,-11,1,-3,2,-5,3,12,4,5,6};

Console.WriteLine(SumOfNumbers(ListInt));


// 3. Find Max

// Given a List of integers, find and return the largest value in the List.

static int FindMax(List<int> IntList)
{
    int max = 0;
    for (int i = 0; i < IntList.Count; i++){
        if (IntList[i] > max){
            max = IntList[i];
        }
    }
    return max;
}

Console.WriteLine(FindMax(ListInt));

// 4. Square the Values

// Given a List of integers, return the List with all the values squared. (Hint: use your PrintList method to check that it worked!)

static List<int> SquareValues(List<int> IntList)
{
    for (int i = 0; i < IntList.Count; i++){
        IntList[i] *= IntList[i];
    }
    return IntList;
}

SquareValues(ListInt);

foreach(int value in ListInt)
{
    Console.WriteLine(value);
}


// 5. Replace Negative Numbers with 0

// Given an array of integers, return the array with all values below 0 replaced with 0.

static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++){
        if (IntArray[i] < 0){
            IntArray[i] = 0;
        }
    }
    return IntArray;
}

NonNegatives(ArrayInt);

foreach(int value in ArrayInt)
{
    Console.WriteLine(value);
}

// 6. Print Dictionary

// Given a dictionary, print the contents of the said dictionary.
Random rand = new Random();
string[] fourNames = {"Tim", "Martin", "Nikki", "Sara"};
List<string> iceCream = new List<string>(5);
iceCream.Add("Chocolate");
iceCream.Add("Vanilla");
iceCream.Add("Strawberry");
iceCream.Add("Cookie Dough");
iceCream.Add("Rocky Road");
Dictionary<string,string> favoriteIceCream = new Dictionary<string,string>();
for(int i = 0; i < fourNames.Length; i++){
    favoriteIceCream.Add(fourNames[i],iceCream[rand.Next(0,4)]);
}
static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach(KeyValuePair<string,string> entry in MyDictionary)
    {
        Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
}

PrintDictionary(favoriteIceCream);

// 7. Find Key

// Given a search term, return true or false whether the given term is a key in a dictionary.

static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    if (MyDictionary.ContainsKey(SearchTerm)){
        return true;
    } else return false;
}

Console.WriteLine(FindKey(favoriteIceCream, "Tim"));
Console.WriteLine(FindKey(favoriteIceCream, "Timmy"));

// 8. Generate a Dictionary

// Given a List of names and a List of integers, 
// create a dictionary where the key is a name from the List of names 
// and the value is a number from the List of numbers. 
// Assume that the two Lists will be of the same length. 
// Don't forget to print your results to make sure it worked.

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
List<string> NamesList = new List<string>() {"Julie", "Harold", "James", "Monica"};
List<int> NameInt = new List<int>() {6, 12, 7, 10};

static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string,int> newDict = new Dictionary<string,int>();
    for(int i = 0; i < Names.Count; i++){
        newDict.Add(Names[i],Numbers[i]);
    }
    return newDict;
}

Dictionary<string,int> finalDict = GenerateDictionary(NamesList,NameInt);

foreach(KeyValuePair<string,int> entry in finalDict)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}