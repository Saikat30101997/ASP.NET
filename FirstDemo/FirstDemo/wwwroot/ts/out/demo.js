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
/*
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
*/
// simple interface inheritance
/*
interface Person {
    age: number;
}

interface Musician extends Person {
    instrument: string,
    Display(): void;

}

var Rahim: Musician = {
    age: 26,
    instrument: "Guiter",
    Display() {
        console.log(this.age + " " + this.instrument);
    }
}

Rahim.Display();
*/
//multiple inheritance
//interface IFirst {
//    v1: number;
//}
//interface Isecond {
//    v2: number;
//    Display(): void;
//}
//class Third implements IFirst, Isecond {
//    v1: number;
//    v2: number;
//    Display() {
//        console.log(this.v1 + " " + this.v2);
//    }
//}
//var mytask: Third = new Third();
//mytask.v1 = 12;
//mytask.v2 = 23;
//mytask.Display();
//interface Task {
//    name: String; //property
//    run(arg: any): void; //method
//}
//class MyTask implements Task {
//    name: String;
//    constructor(name: String) {
//        this.name = name;
//    }
//    run(arg: any): void {
//        console.log(`running: ${this.name}, arg: ${arg}`);
//    }
//}
//let myTask: Task = new MyTask('someTask');
//myTask.run("test");
//interface LabeledValue {
//    label: string;
//} 
// function printLabel(labeledObj: LabeledValue) {
//    console.log(labeledObj.label);
//}
//let myObj = { size: 10, label: "Size 10 Object" };
//printLabel(myObj);
//interface Labeledvalue {
//    label: string;
//}
//function printlable(labeledobj: Labeledvalue) {
//    console.log(labeledobj.label);
//}
//var Iobj = { label: "Saikat Das Tushar" };
//printlable(Iobj);
//devskill inheritance
//class Animal {
//    move(distanceInMeters: number = 0) {
//        console.log(`Animal moved ${distanceInMeters}m.`);
//    }
//}
//class Dog extends Animal {
//    bark() {
//        console.log("Woof! Woof!");
//    }
//}
//const dog = new Dog();
//dog.bark();
//dog.move(10);
//dog.bark();
//Accessability
//Private
//class Animal {
//    private name: string;
//    constructor(theName: string) {
//        this.name = theName;
//        console.log(this.name);
//    }
//}
//class Rhino extends Animal {
//    constructor() {
//        super("Rhino");
//    }
//}
//class Employee {
//private name: string;
//    constructor(theName: string) {
//        this.name = theName;
//    }
//}
//let Rhinoname = new Rhino();
//Protected accessbility
//class Person {
//    protected name: string;
//    constructor(name: string) {
//        this.name = name;
//    }
//}
//class student extends Person {
//    private Department: string;
//    constructor(name: string, Department: string) {
//        super(name);
//        this.Department = Department;
//    }
//    public Display(): void {
//        console.log(`here name is ${this.name} and Department ${this.Department}`);
//    }
//}
//var Saikat = new student("Saikat Das", "CSE");
//Saikat.Display();
//indexer property
//interface StringArray {
//    [index: number]: string; // index hobe number r value hobe string
//}
//let myArray: StringArray;
//myArray = ["Bob", "Fred"];
//let myStr: string = myArray[0];
//console.log(myStr);
//let x: [number, string];
//x = [10, "Hello"];
//x.push(11);
//console.log(x);
//Readonly er kaj jokhn declare korbo tokhn r constructor diye assign kora jabe pore r assign koraa jabe na
var Octopus = /** @class */ (function () {
    function Octopus(theName) {
        this.numberOfLegs = 8;
        this.name = theName;
    }
    return Octopus;
}());
var dad = new Octopus("Man with the 8 strong legs");
//dad.name = "Man with the 3-piece suit"; // error! name is readonly.
//# sourceMappingURL=demo.js.map