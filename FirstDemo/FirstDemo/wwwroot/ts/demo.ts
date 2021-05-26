/*let list: number[] = [1, 2, 3];

for (let i = 0; i < list.length; i++) {
    console.log(list[i]);
}

*/

/*let x: [string, number];
x = ["Saikat", 10];
console.log(x[0].substring(1));
*/

/*enum Color {
    Red,
    Green,
    Blue
}

let c: Color = Color.Red;
console.log(c) //value print korbee 0 theke index start
*/

/*enum Color {
    Red=1,
    Green,
    Blue
}
//1 theke index start
let c: Color = Color.Red;
console.log(c) //value print korbee
*/
/*
enum Color {
    Red = 1,
    Green = 2,
    Blue = 3
}
let colorName: string = Color[2];
console.log(colorName); // 2 number index e kn color ache tar name ta print korbee
*/
/*let notsure: any = 4;
//notsure = false;
//notsure.IfItExists(); // compile time error nai bt run time error dekhabe karon typescript+javascript extension method belong koree . r ifitexists() nam e func create kora nai ba builtin e nai
console.log(notsure.toFixed());  //eta set precision type niye kaj koree 
*/
/* // void datatype
function warnuser(): void {
    console.log("This is warning");
}
warnuser();

*/

// never datatype

// Function returning never must have unreachable end point
/*function error(message: string): never {
    throw new Error(message)
} 
  // Inferred return type is never
function fail() {
    return error("Something failed");
}

let err: string = fail();
console.log(err);

*/
/*
//TypeScript Object

var person = {
    firstname: "Tom",
    lastname: "Hanks"
};

document.getElementById("demo").innerHTML = person.firstname;
document.getElementById("demo1").innerHTML = person.lastname;
*/
//Typescript Type template
/*
var person = {
    firstName: "Tom",
    lastName: "Hanks",
    sayHello: function () { }  //Type template 
}
person.sayHello = function () {
    console.log("hello " + person.firstName)
}
person.sayHello()
*/
//  Objects as function parameters\
/*
var person =
{
    FirstName: "Saikat ",
    LastName:"Tushar"
}

var invokePerson = function (obj: { FirstName: string, LastName: string }) {
    console.log(obj.FirstName);
    console.log(obj.LastName);
}

invokePerson(person);
*/
//Anonymous Object
/*
var invokePerson = function (obj: { FirstName: string, LastName: string }) {
    console.log(obj.FirstName);
    console.log(obj.LastName);
}

invokePerson({ FirstName: "Saikat", LastName: "Das" });

*/

//Type Assertions
/*
let Strname: string;
Strname = "Saikat Das Tushar";
let StrLen: number = (<string>Strname).length;
console.log(StrLen);
*/
//Classes
/*
class Greetings {
    _greet: string;
    constructor(greet: string) {  // ekhane constructor likhe likhte hy
       this._greet = greet;
    }
    Greet(): void {
        console.log(this._greet);
    }
    
}

var obj = new Greetings("Welcome");
obj.Greet();
*/
//class inhertance

/*class Shape {
    Area: any;
    constructor(a: number, b: number) {
        this.Area = a*b;
    }
}

class Rectangle extends Shape {

    disp(): void {
        console.log(this.Area);
    }
}

var rectangle = new Rectangle(12, 13);
rectangle.disp();
*/
//multilevel inheritance
/*
class Root {
    str: string;
}

class Child extends Root { }
class Leaf extends Child { } //indirectly inherits from Root by virtue of inheritance  

var obj = new Leaf();
obj.str = "hello"
console.log(obj.str);
*/
// class inheritance and method overriding 
/*
class ParentClass {
    doPrint(): void {
        console.log("This is from ParentClass");
    }
}
class ChildClass extends ParentClass {
    doPrint(): void {
        super.doPrint();
        console.log("This is From Child Class");

    }
}

var chld = new ChildClass();
chld.doPrint();
*/

//static keyword
/*
class staticmem {
    static num: number;
    static Method(): void {
        console.log(this.num);
    }
}

staticmem.num = 15;
staticmem.Method();
*/
// Data hiding
/*
class Encapsulate {
    public FirstName: string;
    private LastName: string;
    Get(_FirstName: string, _LastName: string): void
    {
        this.FirstName = _FirstName;
        this.LastName = _LastName
    }
    display(): void {
        console.log(this.FirstName + " " + this.LastName);
    }
        
}

var encapsulate = new Encapsulate();
encapsulate.Get("Saikat", "Das");
encapsulate.display();
*/
//interfaces
interface IPerson {
    FirstName: string,
    LastName: string,
    SayHi: () => string
}

var Customer: IPerson = {
    FirstName: "Saikat",
    LastName: "Das",
    SayHi: () => { return "Hello" }
}
console.log(Customer.FirstName);
console.log(Customer.LastName);
console.log(Customer.SayHi());