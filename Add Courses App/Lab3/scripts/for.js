
var minimum = prompt("Enter a minimum value","");
var maximum = prompt("Enter a maximum value","");
var increase = Number(prompt("Enter the minimum value increase",""));

for(var i = minimum; i < maximum; i += increase){
      console.log(i);
      i++
  document.writeln("The value is" + i + "<br>")
}
