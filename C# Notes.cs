/* Notes for C# Development */

/*---------------------------*/
// TABLE OF CONTENTS

/* Strings and Arrays - 104
 * For Each Loops - 148
 * Cases - 160
 * Dictionaries - 180
 * Classes & Methods - 219
 * Error Handling - 250
 * Variables - 273
 * Generics - 371
 * Interfaces and Inheritance - 388
 * Delegates - 451
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
Dictionaries
–––––––––––––––––––––––––––––––
/* why Dictionary is better than Hashtable */
// Dictionary is generic, whereas hashtable is not
// can use any object for key or value

dictionary<string,int> = new Dictionary<string,int>();        // instantiate

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
    public int Variable { get; set; }       // creates getter & setter functions

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

// can inherit multiple interfaces,
// but only one class

/*---------------------------*/
–––––––––––––––––––––––––––––––
Error Handling
–––––––––––––––––––––––––––––––
/* how to throw an error */
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
int[] intArray = { 0,1 };
// or
int[] intArray;
intArray = new int[2]{ 0,1 ;
// Multi-dimension Arrays
int[,] multiArray = { {0,1} , {2,3} };
// Accessing ith element
ith = intArray[i];

/* Lists<T> */
using Systems.Collections.Generic

// properties
.Capacity           // total capacity without resizing
.Count              // elements contained
.Item[Int32]        // gets or sets element at index

// all elements must be of same object type
List<T> list = new List<T>();   // empty list
new List(IEnumerable<T>);       // list with values copied from collection
new List(Int32);                // empty of given capacity
list = {1,2,3}                  // if T == int

/* ArrayList */
using Systems.Collections

// properties
.Capacity           // total capacity without resizing
.Count              // elements contained
.Item[Int32]        // gets or sets element at index
// a few more obscure ones on msdn

ArrayList aList = new ArrayList();   // same constructors as List
aList = { 1,'2',obj3 }               // can be multiple types of objects

// Methods for Lists, ArrayList
.Clear()                // removes all values
.Add(obj)               // appends to end
.Contains(obj)          // whether elems is within list
.Insert(index,obj)      // inserts at index
.RemoveAt(index)        // removes elems at specified index
.Reverse()              // reverses all elems

/* Queue<T> */
using Systems.Collections.Generic

// properties
.Count          // number of elements

// all objects must be of same object type
Queue<T> q = new Queue<T>();        // same constructors as List
.Enqueue("first value");            // first in, first out
.Dequeue();                         // removes and returns first value
.Peek();                            // returns first object, without removing
.Clear();                           // empties queue
.Contains(T);                       // whether it contains value


/* Stack<T> */
using Systems.Collections.Generic

// properties
.Count          // number of elements

Stack<T> stack = new Stack<T>();    // same constructors as List
.Push(T)                            // last in, first out
.Pop()                              // removes and returns last object
.Peek();                            // returns last object, without removing
.Clear();                           // empties stack
.Contains(T);                       // whether it contains value

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
Generics
–––––––––––––––––––––––––––––––
/* printing generic array */

// specify function of generic type with <T>
public genericFunc<T>(ref T var);

// e.g.
public printArray<T>(IEnumerable<T> array) {
    // arrays are IEnumerable with System.Collections.Generics
    foreach(element in array) {
        Console.WriteLine(element);
    }
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Interfaces and Inheritance
–––––––––––––––––––––––––––––––
/* creating an Interface */
interface IName {
    // all methods must be abstract
    // abstract keyword is inferred for all methods
    void Method();
}

/* creating an Abstract Class */ 
abstract class AbstractClass {
    // some methods can be abstract
    abstract void AbstractMethod();
    void PrintHello() {
        Console.WriteLine("Hello");
    }
}

/* implementing interfaces and abstract methods */
    // can implement multiple Interfaces
    // can only implement one class (inlcuding abstract class)

    // must implent ALL abstract methods

/* multiple Class inheritance */
// Interfaces
interface IA {
    void AMethod();
}
interface IB {
    void BMethod();
}

// super Classes
class superA : IA {
    public void AMethod() {
        // code here
    }
}

class superB : IB {
    public void AMethod() {
        // code here
    }
}

// class with "multiple super classes"
class subClass : IA, IB {

    A a = new A();
    B b = new B();

    // this way code doesn't have to be rewritten
    public void AMethod() {
        a.AMethod();
    }
    public void BMethod() {
        b.BMethod();
    }
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Delegates
–––––––––––––––––––––––––––––––
// holds reference to a function

/* creating a Delegate  */
public delegate void PrintDelegate(string message);

// in main function
public static void Main() {
    // a delegate is a type safe function pointer
    PrintDelegate del = new PrintDelegate(FunctionName);
    del("this gets printed")
}

public static void FunctionName(string str) {
    Console.WriteLine(str);
}

/* Delegate usage */
// allows you to change which function is used in a certain place

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

























