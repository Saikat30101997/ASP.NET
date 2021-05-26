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
function error(message) {
    throw new Error(message);
}
// Inferred return type is never
function fail() {
    return error("Something failed");
}
var err = fail();
console.log(err);
//# sourceMappingURL=demo.js.map