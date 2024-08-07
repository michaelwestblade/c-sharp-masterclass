// See https://aka.ms/new-console-template for more information

using DiceRollGame;

var random = new Random();
var die = new Die(random, 6);
var guessingGame = new GuessingGame(die);

GameResult result = guessingGame.Play();

GuessingGame.PrintResult(result);

Console.ReadKey();