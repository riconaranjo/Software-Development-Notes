/* Notes for xUnit in VS */

/*---------------------------*/
// TABLE OF CONTENTS

/* 
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
 * 
 * 
 *
 *
 *
 */

/*---------------------------*/
–––––––––––––––––––––––––––––––
Setting Up xUnit 
–––––––––––––––––––––––––––––––
/* Adding xUnit to Solution */

// Add reference of System Under Test (SUT) Project
    // to Testing Project

// Right Click in Testing Project
    // go to Manage NuGet Packages
    // add xUnit.net
    // add xUnit.net [Runner: Visual Studio]
    
// #optional: add Resharper test runner:
    // Resharper >> Extension Manager
    // add xUnit.net Test Support...

using Xunit;

/*---------------------------*/
–––––––––––––––––––––––––––––––
Test Types
–––––––––––––––––––––––––––––––
/* Marks a method as a test */
[Fact]

/* Marks a data-driven test */
[Theory]

/*---------------------------*/
–––––––––––––––––––––––––––––––
Asserts
–––––––––––––––––––––––––––––––
/* Numerics */

// compare values to specified decimal precision
Assert.Equal(expected, actual, precision);

/* Strings */

// compare strings, case insenstive
Assert.Equal(expected, actual, ignoreCase: true);
// partial match for string
Assert.Contains(match, actual);
// string starts with
Assert.StartsWith(starts, actual);
// string ends with
Assert.EndsWith(ends, actual);

// #optional: can use RegEx
Assert.Matches(pattern, actual);

/* Booleans and Nulls */

// compare bool
Assert.True(result);
Assert.False(result);
// compare for null
Assert.Null(result);

/* Collections */

// can perfom action against all items
Assert.All(list, action);
// e.g. ensure no items are empty in list
    Assert.All(list, item => Assert.False( string.IsNullOrWhiteSpace(item) ));
// check for instance of item in collection
Assert.Contains(item, list);
// check collection does not contain item
Assert.DoesNotContain(item, list);
// check for at least one instance of partial match
Assert.Contains(list, item => (string)item.Contains(match));

/* Ranges */
// ensure number falls within range
Assert.InRange(actual, min, max);

/* Expected Exception */
// ensure correct exception thrown
Assert.Throws<Exception>( () => methodThrowsException() );
// preserve exception:
Exception ex = Assert.Throws<Exception>( () => methodThrowsException() );
Assert.Equal(exceptionNameExpected, ex.ParamName);

/* Object Types */
// assert object is of correct type
Assert.IsType(typeof(Type), obj);
Assert.IsType<Type>(obj);
// check for derived types
Assert.IsAsssignableFrom(typeof(), obj);
Assert.IsAsssignableFrom<Type>(obj);

/*---------------------------*/
–––––––––––––––––––––––––––––––
Categories
–––––––––––––––––––––––––––––––
/* Organizing tests by categories */
// takes input of name, value pairs
[Trait("Category","Error Checking")]

/*---------------------------*/
–––––––––––––––––––––––––––––––
Test Output
–––––––––––––––––––––––––––––––
/* Test Helper Interface */
using Xunit.Abstractions;

// create output helper in test class
private readonly ITestOutputHelper output;

// create constructor with helper, so xUnit can use it
// xUnit handles output automatically
public TestClass(ITestOutputHelper helper) {
    output = helper;
}

// use just like Console.WriteLine
output.WriteLine("message");

/*---------------------------*/
–––––––––––––––––––––––––––––––
Setup and Clean up
–––––––––––––––––––––––––––––––
/* Setup (individual tests) */

// in Test Class constructor
// this will be called before EACH test
public TestClass(ITestOutputHelper helper) {
    output = helper;
    sut = new Sut();    // system under test
}

/* Clean up (individual tests) */

// Test Class must be child of IDisposible 
public class TestClass : IDisposible {
    // clean up method
    // called after EACH test
    public void Dispose() {
        sut.Delete();   // or other clean up methods
    }
}

/* Setup (test suite) */

// must make Test Class child of IClassFixture<T>
// must create custom class T
public class CustomFixture {
    public Sut sut { get; private set; }
    public CustomFixture() {
        sut = new Sut();
    }
}

public class TestClass : IClassFixture<CustomFixture> {
    private readonly CustomFixture fixture;
    private readonly ITestOutputHelper output;
    // constructor still called before each test,
        // can be used to reset previous test
    public TestClass(ITestOutputHelper helper, CustomFixture fix) {...}
}

/* Clean up (test suite) */

// must make fixture child of IDisposible
public class CustomFixture : IDisposible {
    public Sut sut { get; private set; }
    public CustomFixture() {
        sut = new Sut();
    }
    // clean up method to run after all tests
    public void Dispose() {
        sut.Delete();
    }
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Collection Fixtures
–––––––––––––––––––––––––––––––
/* Creating a Fixture to be used by multiple Test Suites */

// use attributes to assign Test Suite to collection
[Collection("My Collection")]
public class TestClass{}

// create collection definition
[CollectionDefinition("My Collection")]
public class MyCollection : ICollectionFixture<CustomFixture> {}

// fixture will be created only once

/*---------------------------*/
–––––––––––––––––––––––––––––––
Parallel Execution
–––––––––––––––––––––––––––––––
// All tests within different collections will run in parallel

/* All tests in assembly considered same collection (no parallel) */
    // in AssemblyInfo.cs, change to:
    [assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]

/* All tests to run in parallel (unless same collection) */
    // in AssemblyInfo.cs, comment out:
    [assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass)]

/*---------------------------*/
–––––––––––––––––––––––––––––––
Collection Execution Order
–––––––––––––––––––––––––––––––
/* Test Collection Orderer */

// need to create class to order tests
public class CollectionOrderer : ITestCollectionOrderer {
    public IEnumberable<ITestCollection>OrderCollections(IEnumberable<ITestCollection> testCollections) {
        // sort/order tests here
        return testCollections;
    }
}

/* Configure */

// AssemblyInfo.cs:
[assembly: TestCollectionOrderer("AssemblyName.CollectionOrderer","AssemblyName.tests")]

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
























