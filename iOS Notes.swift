/* Notes for iOS Development */

import UIKit            // standard frameworks for iOS
import Foundation       // standard obj-c library

/*---------------------------*/
// TABLE OF CONTENTS

/* Table Views - 104
 * Timers - 157
 * Regular Expressions - 176
 * Switching Cases - 207
 * Hiding Keyboard - 224
 * Permanent Storage - 282
 * Downloading Web Content - 300
 * Strings - 348
 * Updating Images / Animation - 370
 * Adding Apple Maps & Long Press - 423
 * Moving Buttons - 490
 * Using User Location - 511
 * Identifying Segues - 590
 * Working with Audio - 605
 * Generics & For Each Loops - 619
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
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
TABLE VIEWS
–––––––––––––––––––––––––––––––
/* Storyboard: create Table View in storyboard
 * make current View Controller the data source and delegate
 * 
 * ViewController.swift: make view controller delegate [ unless already sub-class of UITableView ]
 * add UITableViewDelegate */
class ViewController: UIViewController, UITableViewDelegate{}

/* specify amount of cells [rows] in table, add function*/
var list = [things]

func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int{
    return list.count
}

/* Set up values that will be in each cell */

// creates each cell up to cellSize
func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
    
    // create default cell
    let cell = UITableViewCell(style: .Default, reuseIdentifier: "Cell")
    
    // makes each cell numbered from 1...cellSize
    cell.textLabel?.text = String(indexPath.row + 1)
    
    return cell
}

/* adding swipe to delete function */

func tableView(tableView: UITableView, commitEditingStyle editingStyle: UITableViewCellEditingStyle, forRowAtIndexPath indexPath: NSIndexPath) {
    
    // if swipe to left:
    if editingStyle == UITableViewCellEditingStyle.Delete {
        list.removeAtIndex(indexPath.row)
    }
    // reload the tableview
    tableView.reloadData()
    
    // save new version of list
    NSUserDefaults.standardUserDefaults().setObject(list, forKey:"list")
}

/* Updating data in table */

@IBOutlet var table: UITableView!

table.reloadData()

/*---------------------------*/
–––––––––––––––––––––––––––––––
TIMERS
–––––––––––––––––––––––––––––––
/* Define timer: */
var timer = NSTimer()
var currentTime = 0

/* create instance of timer */
let interval = 0.1 // second 
    
timer = NSTimer.scheduledTimerWithTimeInterval(interval, target: self, selector: #selector(ViewController.increaseTime), userInfo: nil, repeats: true)

func increaseTime() {
    currentTime += interval
    // formats to one decimal place
    label.text = String(format: "%0.1f",currentTime)
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
REGULAR EXPRESSIONS
–––––––––––––––––––––––––––––––
/* use following method call to earch for match */

if text.rangeOfString("^-?\\d*(\\.|,)?\\d*$", options: .RegularExpressionSearch) != nil

// example from Temperature converter

// looks for numbers that will match either Int or Double
// decimal place cab be either point or comma
func isOnlyTemp(text:String) -> Bool {

    if text.isEmpty {
        return false
    }
    
    // if match found, works like .matches()
    if text.rangeOfString("^-?\\d*(\\.|,)?\\d*$", options: .RegularExpressionSearch) != nil {
        return true
    }

    return false
}


// to replace string char with other char, use:
let str = ""
str = str.stringByReplacingOccurrencesOfString("char(s) replaced", withString: "replacment")

/*---------------------------*/
–––––––––––––––––––––––––––––––
SWITCHING CASES
–––––––––––––––––––––––––––––––
/* Switch: the conditional parameters */

switch IDtag {
case 0001:
    // do whatever
case 0002:
    // do something else
case 0003:
    // you get the idea
default
    // catch all all other cases
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
HIDING KEYBOARD
–––––––––––––––––––––––––––––––
/* add function in View Controller */

// if keyboard "return" key pressed, make keyboard disappear
func textFieldShouldReturn(textField:UITextField) -> Bool {
    textField.resignFirstResponder();
    return true
}

/* Method 1: hides keyboard screen tapped */

/* first, make View Controller delgate for textfield */

class ViewController: UIViewController ,UITextFieldDelegate {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        self.textField.delegate = self
    }  
}

/* second, override this method within View Controller */   
override func touchesBegan(touches: Set<UITouch>, withEvent event: UIEvent?) {
    self.view.endEditing(true)
}

/* Method 2: Stackoverflow, can be implemented in multiple locations much more easily */

/* in View Controller, add: */

override func viewDidLoad() {
    super.viewDidLoad()
    self.hideKeyboardWhenTappedAround()
}

/* extends new methods for UIViewController, add anywhere */

extension UIViewController {
    
    func hideKeyboardWhenTappedAround() {
        let tap: UITapGestureRecognizer = UITapGestureRecognizer(target: self, action: #selector(UIViewController.dismissKeyboard))
        view.addGestureRecognizer(tap)
    }
    
    // function called when keyboard needs to be dismissed
    func dismissKeyboard() {
        view.endEditing(true)
    }
}

/* call this method for whenever you want keyboard to disappear */

dismissKeyboard()

/*---------------------------*/
–––––––––––––––––––––––––––––––
PERMANENT STORAGE
–––––––––––––––––––––––––––––––
/* saves an value for a specific key */
NSUserDefaults.standardUserDefaults().setObject(value:"a value", forKey: "key")

// e.g. username + password

NSUserDefaults.standardUserDefaults().setObject(value:"Bloggins", forKey: "username")
NSUserDefaults.standardUserDefaults().setObject(value:1234, forKey: "password")

var username = NSUserDefaults.standardUserDefaults().objectForKey("username")
// returns "Bloggins"

var password = NSUserDefaults.standardUserDefaults().objectForKey("username")
// returns 1234

/*---------------------------*/
–––––––––––––––––––––––––––––––
DOWNLOADING WEB CONTENT
–––––––––––––––––––––––––––––––
/* To allow requests from HTTP [as well as HTTPS] add:
 * "App Transport Security Settings" to info.plist 
 * change: "Allow Arbitrary Loads" = YES
 */
 
// define url
let url = NSURL(string: "http://www.apple.com/ca/")!

// Method 1 - Get Content
    
    /* task call analogous to:
     * NSURLSession = Browser
     * sharedSession() = default tab
     * dataTaskWithURL(url) = get the content of the url
     */
let task = NSURLSession.sharedSession().dataTaskWithURL(url) { (data, response, error) in
    // happens after task completes

    // check if data exists
    if let urlContent = data {
        
        // convert data from UTF8 format to String
        let webcontent = NSString(data: urlContent, encoding: NSUTF8StringEncoding)
        
        // make it load data immediately
        dispatch_async(dispatch_get_main_queue(), {
            // put instructions here
            //self.webView.loadHTMLString(String(webcontent!), baseURL: nil)
        })
    }
    else {
        // error
        print("error")
    }
}

task.resume()

// Method 2 - Load Full Screen Website

// define url
let url = NSURL(string: "http://www.apple.com/ca/")!
webView.loadRequest(NSURLRequest(URL: url))

/*---------------------------*/
–––––––––––––––––––––––––––––––
Strings
–––––––––––––––––––––––––––––––
/* replace occurrance of strings */

newString = oldString.stringByReplacingOccurrencesOfString( "String", withString: "OtherString" )

/* drop last character */

newString = oldString.characters.dropLast()

/* seperate string after */

newString = oldString.componentsSeparatedByString("after this")

/* check for suffix/prefix */

// returns boolean
str.hasSuffix()
str.hasPrefix()

/*---------------------------*/
–––––––––––––––––––––––––––––––
Update Images / Animation
–––––––––––––––––––––––––––––––
/* for image view */

// changes image
imageView.image = UIImage(named: "filename.png")

// pair with NSTimer and multiple frames for proper animation

/* method called just before image is displayed */

override func viewDidLayoutSubViews {
    code
}

/* method called as soon as image appears */
override func viewDidAppear {
    code
}

/* set center of image */

imageView.center = CGPointMake(x: CGFloat, y: CGFloat)
// imageView.center.x and .y are useful here

/* change transparency */

imageView.alpha = value

/* change size of image */

// allows for changing size and location of image
imageView.frame = CGRectMake(x: CGFloat, y: CGFloat, width: CGFloat height: CGFloat)
// setting height and width to 0,0 will make it disappear

/* animation */

UIView.animateWithDuration(duration: NSTimeInterval /* '1' is one second */,animations: {
    // modify imageView, or what have you
})

// e.g. move image from left to centre, in (one) second

override func viewDidAppear {

    UIView.animateWithDuration( 1, animations: {
        self.imageView.center = CGPointMake(self.imageView.center.x - 400, self.imageView.center.y)
    })
    // have to use self. because is inside function
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Adding Apple Maps & Long Press
–––––––––––––––––––––––––––––––
/* import frameworks */

import MapKit

/* add MapKit view in storyboard */

/* make class a delegate for MKMapView */

class ViewController: UIViewController, MKMapViewDelegate{}

/* make map scrollable */

override func viewDidLoad() {
    super.viewDidLoad()

    // set up initial location and zoom of map
    let latitude:CLLocationDegrees = 40.7
    let longitude:CLLocationDegrees = 232
    let dLat:CLLocationDegrees = 0.02
    let dLong:CLLocationDegrees = 0.02
    // field of view
    let span:MKCoordinateSpan = MKCoordinateSpanMake(dLat,dLong)
    let location:CLLocationCoordinate2D = CLLocationCoordinate2DMake(latitude,longitude)
    let region:MKCoordinateRegion = MKCoordinateRegionMake(location,span)

    mapView.setRegion(region,animated:false)
}

/* Map Pins with Long Press */

let annotation = MKPointAnnotation()
annotation.coordinate = location // can be any location
annotation.title = "title"
annotation.subtitle = "subtitle"

// adding annotation
mapView.addAnnotation(annotation)

/* ----- Recognizing Long Press ----- */

let uilpgr:UIGestureRecognizer = UILongPressGestureRecognizer(target: self, action: Selector("actionFunction:"))
// "actionFunction:" with semicolon to send uilpgr to function

 uilpgr.minimumPressDuration = 2 // seconds
 mapView.addGestureRecognizer(uilpgr)

 /* create function when long press occurred */

 func actionFunction(gestureRecognizer:UIGestureRecognizer) {
     
     // gets location of long press relative to map
     let touchPoint = gestureRecognizer.locationInView(self.mapView)

     let newCoordinate:CLLocationCoordinate2D = mapView.convertPoint(touchPoint, toCoordinateFromView: self.mapView)

     // map annotation things
     let annotation = MKPointAnnotation()
     annotation.coordinate = location // can be any location
     annotation.title = "title"
     annotation.subtitle = "subtitle"
     mapView.addAnnotation(annotation)
 }

/*---------------------------*/
–––––––––––––––––––––––––––––––
Moving Buttons
–––––––––––––––––––––––––––––––
/* Move Instanteously */

// create IBOutlet of specific constraint
@IBOutlet var constraintCenter: NSLayoutConstraint!

// modify value [ for centred is 0.0 ]
constraintCenter.constant = -400 // [ moves centre to position -400 ]

/* Move with Animation */

UIView.animateWithDuration(0.65, animations: {
    // move a button
    self.ConstraintCenter.constant = -400.0
    // button with constraint
    self.Button.center = CGPointMake(self.Button.center.x-400, self.Button.center.y)
})

/*---------------------------*/
–––––––––––––––––––––––––––––––
Using User Location
–––––––––––––––––––––––––––––––
/* Set-up Frameworks for Location */

// go to "Build Phases/Link Binary With Library"
// add "CoreLocation.framework"

/* Modify "info.plist" */

// add "NSLocationWhenInUseUsageDescription"
// String "reason why you want this"

// add "NSLocationAlwaysUsageDescription"
// String "reason why you want always location"


/* import frameworks for location */

import CoreLocation

/* make class a delegate for CLLocationManager */

class ViewController: UIViewController, CLLocationManagerDelegate{}

/* create CLLocationManager */

letl locationManager = CLLocationManager()

/* set-up CLLocationManager in viewDidLoad() */

locationManager.delegate = self
// less power = less accuracy
locationManager.desiredAccuracy = kCLLocationAccuracyBest
// request for location
locationManager.requestWhenInUseAuthorization() // could be the Always
// start using location
locationManager.startUpdatingLocation()

/* create function to use location */

func locationManager(manager:CLLocationManager!, didUpdateLocations locations:[CLLocation]) {

    // get a location log
    let userLocation:CLLocation = locations[0] // the 0th location

    let latitude = userLocation.coordinate.latitude
    let longitude = userLocation.coordinate.longitude
    let course = userLocation.course
    let speed = userLocation.speed
    let altitude = userLocation.altitude

    let dLat:CLLocationDegrees = 0.02
    let dLong:CLLocationDegrees = 0.02
    // field of view
    let span:MKCoordinateSpan = MKCoordinateSpanMake(dLat,dLong)
    let location:CLLocationCoordinate2D = CLLocationCoordinate2DMake(latitude,longitude)
    let region:MKCoordinateRegion = MKCoordinateRegionMake(location,span)
}

/* getting address from location */

CLGeocoder().reverseGeocodeLocation(location: CLLocation!, completionHandler: { ([AnyObject], NSError! ) -> Void in
    code
})

// e.g.
CLGeocoder().reverseGeocodeLocation(userLocation, completionHandler: { (placemarks, error ) -> Void in
    if error != nil {
        print(error)
    }
    else if placemarks?.count > 0 {
        let place = placemarks![0]
        // place has various instance variables, can see them if:
        print(place)
    }
})

/*---------------------------*/
–––––––––––––––––––––––––––––––
Identifying Segues
–––––––––––––––––––––––––––––––
/* give segue of interest an identifier in Storyboard */

// in View Controller of interest, call on this method

// happens before segue is executed
override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
    if segue.identifier == "ID name" {
        code
    }
}

/*---------------------------*/
–––––––––––––––––––––––––––––––
Working with Audio
–––––––––––––––––––––––––––––––
/* import frameworks */

import AVFoundation

/* add media player */
var player:AVAudioPlayer = AVAudioPlayer()

// in viewDidLoad()
let audioPath = 

/*---------------------------*/
–––––––––––––––––––––––––––––––
Generics & For Each Loops
–––––––––––––––––––––––––––––––
/* creating a function that takes generic inputs */
// have to specify that function takes generics with <T>
func genericFunc<T>(t: T);
// multiple inputs <T,U>
func otherGeneric<T,U>(t: T, u: U)

// e.g. generic array print
func printArray<T>(input: [T]) {
    for element in input {
        print(element)
    }
}
/*---------------------------*/
–––––––––––––––––––––––––––––––
Nil-Coalescing Operator 
–––––––––––––––––––––––––––––––
/* setting a default value if something is false */

let someValue = otherValue ?? defaultValue
// if otherValue != nil, someValue = otherValue
// else someValue = defaultValue

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

























