# * Notes for Ruby / Ruby-on-Rails * #

#---------------------------------#
# TABLE OF CONTENTS

 # Printing Strings - 105
 # Variables - 116
 # Classes & Methods - 159
 # For Each Loops - 189
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

#-----------------------------#
–––––––––––––––––––––––––––––––
Variables
–––––––––––––––––––––––––––––––
# Global Variables
$global_variable = 10       # always begin with '$'

# Instance Variables
@instance_variable = 15     # always begin with '@'
# unitialized variables are set to nil

# Class Variables
@@class_variables = 20      # always begin with '@@'
# must be initialized

# Local Variables
variable = 25               # always begin with lowercase or '_'

# Constants
CONST = 30                  # always begin with uppercase

# Pseudo-variables
__FILE__    # name of current source file
__LINE__    # current line number in source file

# Literals
integers    # _ are ignored: 1234 == 1_234
floats      # like doubles, can use E: 1.2e-6, 1.45E3
strings     # "" allow substitution and backslash notation
            # '' do not allow substitution, or backslash notation
            # substitution: use #{} like \() in Swift
            # can add with '<<' or '+'
array       # elements can be any type
hash        # hashmap, or dictionary
    @hsh = colours = {'red' => 0xf00, 'green' => 0x0f0} 
# for arrays and hashes can use thing.each as a 'for each loop'
    @thing = ['first', 2, ]
    @thing.each do |i| # for hash use |key, value|
        puts i  # outputs each elems per line
    end

range       # (1..5) is 1 to 5 inclusive; (1...5) not inclusive

#-----------------------------#
–––––––––––––––––––––––––––––––
Classes & Methods
–––––––––––––––––––––––––––––––
# defining a class:
class myClass

    attr_reader :variable       # allows variable to be read outside class
    attr_writer :variable       # allows variable to be modified from outside
    attr_accessor :variable     # is reader + writer combined 

    # constructor
    def initialize(variable)
        # initialize instance variables
        @instance_variable = variable
    end

    # to define a method:
    def myMethod
        # do something
    end

    # defining a method with default arguement
    def hi (name = "World")
        puts "Hello #{name}" # will print "Hello World" if no name passed to method
    end
end

# Ruby does not support overloading directly like java

#-----------------------------#
–––––––––––––––––––––––––––––––
For Each Loops
–––––––––––––––––––––––––––––––
# range of values
(n..m) # from n to m [inclusive]

(n..m).each do |iterator|
    puts iterator # will print n..m 
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



























