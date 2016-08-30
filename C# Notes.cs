/* Notes for C# Development */

/*---------------------------*/
// TABLE OF CONTENTS

/* Strings and Arrays - 104
 * For Each Loops - 148
 * Cases - 160
 * Dictionary - 180
 * Classes & Methods - 219
 * Errors - 246
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *
 *
 *
 */

/*---------------------------*/
–––––––––––––––––––––––––––––––
Strings and Arrays
–––––––––––––––––––––––––––––––
/* Reading and Writing to Console */
Console.ReadLine() // returns a string [cin]
Console.WriteLine() // writes to console [cout]

/* Substitution */
Console.WriteLine("{0} {1}", value0, value1);

/* format string */
value.toString("g") // to general number format
    // g: general number 
    // f: fixed notation, default 2 decimal places
    // Percent: divides by 100 and adds "%"
    // X: hexadecimal

/* convert string to integer */
int value = Convert.ToInt32("insert string here");
// use (ushort) for positive indicies, same as UInt16

/* convert string to double */
double number = Convert.toDouble("insert string here");

/* to access each char */
charAtIndex = str[index];

/* length of string */
numOfChars = str.Length;

/* convert string to Array of Integers */
string[] tempArr = Console.ReadLine().Split(' ');       // or .Split(); whitespace is assumed 
int[] intArr = Array.ConvertAll(tempArr,Int32.Parse);

/* convert Array of Integers to string */
string str = String.Join(" ", intArr);

/* reverse array elements */
Array.Reverse(intArr);

/* check if string is empty or null */
string.IsNullOrEmpty(yourStringHere);       // returns boolean

/*---------------------------*/
–––––––––––––––––––––––––––––––
For Each Loops
–––––––––––––––––––––––––––––––
/* range of values */
IEnumerable <int> range = Enumerable.Range(startingPoint,howManyValues); 

// will print each number in array
foreach(int num in array) {
    Console.WriteLine(num);
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Cases
–––––––––––––––––––––––––––––––
/* evaluate multiple outcomes */
// DOES NOT SUPPORT RANGE OF VALUES FOR CASES
switch (grade) {                        // compare grade
case "A":                               // grade == "A"
    Console.WriteLine("you smartie");
    break;                              // have to end each block of code with (break;)
case "B":
    Console.WriteLine("cool");
case "C": case "D":                     // multiple cases with same outcome
    Console.WriteLine("your parents resent you");
    break;
default:                               // default case
    Console.WriteLine("stay in school");
    break;
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Dictionary
–––––––––––––––––––––––––––––––
/* why use instead of Hashtable */
// Dictionary is generic, whereas hashtable is not
// can use any object for key or value

dictionary<string,ushort> = new Dictionary<string,ushort>();        // instantiate

/* add element */
dictionary.Add("first", 1);              // (key, value)

/* check for entry */
// find value for key, quickest
dictionary.TryGetValue("first");         // returns (1)
// e.g.
if(dictionary.TryGetValue("first", out index));     // index == 1
if(dictionary.TryGetValue("second", out index));    // index unchanged

// check values
dictionary.ContainsKey("second");        // returns false
// check keys
dictionary.ContainsValue(1);             // returns true

/* clear all entries */
dictionary.Clear();

/* remove certain value */
dictionary.Remove(key);

/* access at key */
dictionary[key];

/* print out all elements */
foreach (KeyValuePair<string, string> kvp in book) {
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Classes & Methods
–––––––––––––––––––––––––––––––
/* declaring a method */
pubic int PlusOne(int number) {
    int result;
    result = number + 1;
    return result;
}

/* declaring a class */
class myClass : ParentClass {               // 'extends' is replaced by ':'
    private int instanceVariable;           // just like java...

    // constructor
    public myClass(int var)
    :base(int var) {                        // calling super constructor
        // do this after calling parent constructor
    }

    private int function() {
        string = "this is a function";
        return 0;
    }
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Errors
–––––––––––––––––––––––––––––––
/* How to throw an error */

if(condition) {
    throw new System.Exception("error message");
} 
// else do this
code

// e.g.
class Calculator {
    public int power(int n, int p) {
        if(n < 0 || p < 0 ) {
            // Argument Exception is when passed arguement creates error
            throw new System.ArgumentException("n and p should be non-negative");
        }
        int result = Convert.ToInt32(Math.Pow(n,p));
        return result;
    }
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Variables
–––––––––––––––––––––––––––––––
/* all primative data types are represented as objects */
string str = integer.ToString(); // can do this

const       // constant
int         // signed 32 bit
double      // signed 64 bit
string      // string of characters
    // can compare strings with ==
    str1 == str2    // compares string contents
    str1 != str2    // not like Java

/* Arrays */
int[] intArray = {0,1};
// or
int[] intArray;
intArray = new int[2]{0,1};
// Multi-dimension Arrays
int[,] multiArray = { {0,1} , {2,3} };

/* Enumermations */
enum numbers {
    first,      // defaults to 0
    second,     // defaults to 1
    third,      // defaults to 2
    forth       // defaults to 3
} // can also assign numbers instead

/* Exponents */
Math.Pow(n,p); // n^p, n**p


/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
/*---------------------------*/

























