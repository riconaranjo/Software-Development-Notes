/* Notes for C# Development */

/*---------------------------*/
// TABLE OF CONTENTS

/* Strings and Arrays - 104
 * For Each Loops - 148
 * Switching Cases - 160
 * Dictionaries - 180
 * Classes & Methods - 218
 * Error Handling & Exceptions - 285
 * Variables - 361
 * Generics - 485
 * Interfaces and Inheritance - 513
 * Delegates and Lambda Functions - 576
 * Access Modifiers - 629
 * Attributes - 656
 * Equality - 673
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
Switching Cases
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
Dictionary<T,T> // <Key,Value>
Dictionary<string,int> dictionary = new Dictionary<string,int>();        // instantiate

/* methods */
// add element
dictionary.Add("first", 1);              // (key, value)

// quickest way find key of value
dictionary.TryGetValue("first");         // returns (1)
// e.g.
if(dictionary.TryGetValue("first", out index));     // index = 1
if(dictionary.TryGetValue("second", out index));    // index unchanged, since not found

// check for key
dictionary.ContainsKey("second");        // returns false
// check for value
dictionary.ContainsValue(1);             // returns true

dictionary.Count();         // total number of entries
dictionary.Clear();         // clears all entries
dictionary.Remove(key);     // remove at key
dictionary[key];            // access at key

/* print out all elements */
foreach (KeyValuePair<string, string> kvp in book) {
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
}

/* convert Type to dictionary */
Dictionary<int, object> thing.ToDictionary(obj => x.0, obj => x);     // x.0 is key, ref x is value

/*---------------------------*/
–––––––––––––––––––––––––––––––
Classes & Methods
–––––––––––––––––––––––––––––––
/* declaring a method */
public int PlusOne(int number) {
    int result;
    result = number + 1;
    return result;
}

/* declaring a class */
    // can inherit multiple interfaces,
    // but only one class
class myClass : ParentClass {               // 'extends' is replaced by ':'

    // can label regions with #region
    #region properties

    private int instanceVariable;           // just like java...
    public int Variable { get; set; }       // creates getter & setter functions
    #endregion

    // constructor
    public myClass(int var)
    :base(int var) {                        // calling super constructor
        // do this after calling parent constructor
    }

    // method
    private int function() {
        string = "this is a function";
        return 0;
    }

    // if you want to override base method (instead of hiding)
    private override void overrideFunction() {
        code
    }

    // making Type sortable in a list, needs to be comparable
    public int CompareTo(myClass other) {
        // implentation must follow this, in order to use .Sort();
        if(this.instanceVariable > other.instanceVariable) {
            return 1;
        }
        else if(this.instanceVariable > other.instanceVariable) {
            return -1;
        }
        return 0;
    }
}

/* partial classes */
// splitting a class into multiple files
// use partial keyword in each file
partial class PartialClass {
    code
}
/* default values for methods */
static void function(int x = 10, int y = null) {
    code
}

/* calling parameters by name */
function(y: 10);    // 'x' will take default value

/*---------------------------*/
–––––––––––––––––––––––––––––––
Error Handling & Exceptions
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

/* getting type of exception */
Exception.GetType().Name;       // returns name of type
Exception.Message;              // returns reason for exception

/* handling Exceptions */
try {
    code
}
catch(FileNotFoundException ex) {
    Console.WriteLine("{0} not found", ex.FileName);
}
catch(Exception ex) { // more general exception last
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}
finally { // guaranteed to execute
    code
}

/* inner exceptions */
// nested exceptions withing try/catch blocks
try {
    try {
        code
    }
    catch (firstException) {
        if(File.Exists("<file path>"))
        throw new FileNotFoundException(<file path> + " not found", firstException);
    }
}
catch(Exception secondException) {  // secondException will contain firstException
    Console.WriteLine("Current Exception = {0}", secondException.GetType().Name);
    if(secondException.InnerException != null) {
        Console.WriteLine("Inner Exception = {0}", secondException.InnerException.GetType().Name);
    }
}

/* custom Exceptions */

[System.Serializable] // this is for moving objects from applications to others
public class MyException : System.Exception {

    public MyException() { }

    public MyException( string message ) : base( message ) { }

    public MyException( string message, System.Exception inner ) : base( message, inner ) { }

    protected MyException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
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
intArray = new int[2]{ 0,1 } ;
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
.Exists(Predicate<T>match);     // like .Contains with condition
    // e.g.
    .Exists(obj => obj.1 == value);
.Find(Predicate<T>match);       // like .Exists, but returns index of first occurrance
.FindAll(Predicate<T>match);    // returns list of results
.FindIndex(Predicate<T>match);  // returns index of first occurrance
.RemoveAll(Predicate<T>match)); // removes all with condition

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

// all objects must be of same object type
Stack<T> stack = new Stack<T>();    // same constructors as List
.Push(T)                            // last in, first out
.Pop()                              // removes and returns last object
.Peek();                            // returns last object, without removing
.Clear();                           // empties stack
.Contains(T);                       // whether it contains value

/* finding all occurrances in list type */
// elem, such that elem is equal to x
count = list.Count(elem => elem == x);

/* Enumermations */
enum Numbers {
    first,      // defaults to 0
    second,     // defaults to 1
    third,      // defaults to 2
    forth       // defaults to 3
}   // can also assign numbers instead
    // each field increments by +1, by default

// methods for enum
.GetValues(typeof(Numbers))      // returns numbers
.GetNames(typeof(Numbers))       // returns value names 

// adding values to enum
Number numEnum = (Number) 15;   // must be explicit casting
// copying number from enum
int num = (int) Number.first;

/* exponents */
Math.Pow(n,p); // n^p, n**p

/* inputting values safely */
int input;
bool success = Int32.TryParse(Console.ReadLine(), out input);
if(success) { code }

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

/* generic classes */

// have to specify type when calling class
// like queue<T>, etc

class GenericClass<T> {
    public function(T t) {
        code
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
Delegates and Lambda Functions
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
    // promotes reusability, modularity
    // allows you to pass functions as function parameters
    // good for using with lambda functions

// in code when calling function that takes a delegate as parameter:
object.MethodCall(variable, delegate(x));
// can use lambda function:
// x, such that @y is greater than 0, returns bool
object.MethodCall(variable, x => element.y > 0);
// same as:
object.MethodCall(variable,true);

/* multicast Delegate */
// holds multiple references to functions
// when invoked, all functions pointed to are also invoked

// creating multicast delegate
public delegate void SampleDelegate();
SampleDelegate d1, d2, d3;
d1 = new SampleDelegate(Method1);
d2 = new SampleDelegate(Method2);
d3 = d1 + d2;       // now d3 points to both d1 and d2
                    // can remove d1 || d2 with (-) operator
d3();   // invokes d1 and d2

// alternate method
d1 = new SampleDelegate(Method1);
d1 += new SampleDelegate(Method2);  // can remove with (-=) operator

// if multiple return values from functions,
// only last function's value is taken

/*---------------------------*/
–––––––––––––––––––––––––––––––
Access Modifiers
–––––––––––––––––––––––––––––––
private
// accessible only to own class

protected
// accessible only to own class and derived classes
// like 'public' to base and derived classes

internal
// accessible only to any classes in the same project

protected internal
// like internal, accessible to any classes within same project
// also to derived classes within same project

public
// no protection, accessible everywhere

/* Types */
// default to internal

/* Type Members */
// default to private

/*---------------------------*/
–––––––––––––––––––––––––––––––
Attributes
–––––––––––––––––––––––––––––––
/* can be used to give information */

// can be simple:
[Attribute]

// or can include message
[Attribute("message here")]

public class RandomClass {
    [Obsolete] // this is the attribute
    public static function() {
    }
}
/*---------------------------*/
–––––––––––––––––––––––––––––––
Equality
–––––––––––––––––––––––––––––––
/* Double Equals */
// when used on objects, will compare references
object == object        // compares references
string == string        // compares contents

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
























