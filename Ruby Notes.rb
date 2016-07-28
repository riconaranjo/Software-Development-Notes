# * Notes for Ruby / Ruby-on-Rails * #

#---------------------------------#
# TABLE OF CONTENTS

 # Printing Strings - 104
 # Variables - 116
 # Classes & Methods - 159
 # For Each Loops - 206
 # Equality - 220
 # Strings & Arrays - 244
 # Searching in Hash - 

 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 
 # 

#-----------------------------#
–––––––––––––––––––––––––––––––
Printing Strings
–––––––––––––––––––––––––––––––
## puts command
# outputs each argument followed by \n

puts 'Hello World'  # can use "" instead of ''

# puts will unwrap an array; will print each element per line
# to print array on one line, convert to string first

#-----------------------------#
–––––––––––––––––––––––––––––––
Variables
–––––––––––––––––––––––––––––––
## Global Variables
$global_variable = 10       # always begin with '$'

## Instance Variables
@instance_variable = 15     # always begin with '@'
# unitialized variables are set to nil

## Class Variables
@@class_variables = 20      # always begin with '@@'
# must be initialized

## Local Variables
variable = 25               # always begin with lowercase or '_'

## Constants
CONST = 30                  # always begin with uppercase

## Pseudo-variables
__FILE__    # name of current source file
__LINE__    # current line number in source file

## Literals
integers    # _ are ignored: 1234 == 1_234
floats      # like doubles, can use E: 1.2e-6, 1.45E3
strings     # "" allow substitution and backslash notation
            # '' do not allow substitution, or backslash notation
            # substitution: use #{} like \() in Swift
            # can add with '<<' or '+'
array       # elements can be any type
hash        # hashmap, or dictionary
    @hsh = {'red' => 0xf00, 'green' => 0x0f0}
    newHash = Hash.new # initialize hash
    newHash["forKey"] = variable
    newHash.each_key
# for arrays and hashes can use thing.each as a 'for each loop'
    @arr = ['first', 2]
    @arr.each do |i| # for hash use |key, value|
        puts i  # outputs each elems per line
    end

range       # (1..5) is 1 to 5 inclusive; (1...5) not inclusive

#-----------------------------#
–––––––––––––––––––––––––––––––
Classes & Methods
–––––––––––––––––––––––––––––––
## defining a class:
class MyClass

    attr_reader :instance_variable       # allows variable to be read outside class
    attr_writer :instance_variable       # allows variable to be modified from outside
    attr_accessor :instance_variable     # is reader + writer combined 

    ## constructor
    def initialize(variable)
        # initialize instance variables
        @instance_variable = variable
    end

    ## to define a method:
    def myMethod
        code
    end

    ## defining a method with default arguement
    def hi(name = "World")
        puts "Hello #{name}" # will print "Hello World" if no name passed to method
    end

    # you can override operators like this
    def ==(other) # if you override this, you override triple equals (?)
        if other.instance_variable == @instance_variable
            return true
        else
            return false
        end
    end

    def ===(other)
        if other.hash == self.hash
            return true
        else
            return false
        end
    end 
end

# Ruby does not support overloading directly like java

#-----------------------------#
–––––––––––––––––––––––––––––––
For Each Loops
–––––––––––––––––––––––––––––––
## creating a range of values
(n..m)  # from n to m [inclusive]
(n...m) # [exclusive]

(n..m).each do |iterator|
    puts iterator # will print n..m 
end

## creates array from range
(x..y).to_a

#-----------------------------#
–––––––––––––––––––––––––––––––
Equality
–––––––––––––––––––––––––––––––
## Double Equals - generic equality
# compares value or identity
# will do type conversion
1 == 1.0        # true
Integer == 1    # false

## Triple Equals - case equality
# same as Double Equals except for sets:
# is the ~second object within the set of the ~first? 
1 === 1.0       # false
Integer === 1   # true 

## equals? - hash equality
# compares identity [hashcodes]
x = 1
y = 1
x.equal?y       # false
x = y
x.equal?y       # true

#-----------------------------#
–––––––––––––––––––––––––––––––
Strings & Arrays
–––––––––––––––––––––––––––––––
## inputting string
input = gets

## Strip and Chomp
str.strip           # removes leading and trailing whitespace
str.chomp           # removes trailing whitespace
str.chomp"arg"      # removes arguement if found at end
# adding '!' will modify arguement
    # str = str.chomp
    # same as:
    # str.chomp!

## convert string to array of integers
intArray = input.split(" ").map(&:to_i)
    # &:to_i is the same as |x| x.to_i

## reverse array of integers
intArray.reverse

## convert array to string
intString = intArray.join(" ")

#-----------------------------#
–––––––––––––––––––––––––––––––
Searching in Hash
–––––––––––––––––––––––––––––––
# tring to find name in phonebook example:

number = gets.to_i              # number of entries
range = (1..number).to_a        # numbers into array
book = Hash.new                 # intialize array

range.each do                   # add each new entry from STDIN
    input = gets.strip.split" "    
    book[input[0]] = input[1]
end

STDIN.each_line do |query|      # for each new entry
    query.strip!                # remove line endings and things
    case book[query]            # if phone book has entry
    when nil
        puts'Not found'
    else
        puts "#{query}=#{book[query]}"
    end
end

#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#
–––––––––––––––––––––––––––––––
<><><><><><><><><><><><><><>
–––––––––––––––––––––––––––––––
#-----------------------------#



























