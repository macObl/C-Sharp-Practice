
var secret = 5;
var guess = prompt("Guess a number between 1 - 10");

do{
  guess =prompt("Keep guessing");
  if (secret < guess){
    prompt("You're too high");
  } else if (secret > guess) {
    prompt("You're too low");
  } else document.writeln("Congratulations!");

} while (secret != guess);
