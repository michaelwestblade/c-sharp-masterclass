// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using GameDataParser;

var app = new GameDataParserApp();
var logger = new Logger("log.txt");

try
{
    await app.run();
}
catch (Exception e)
{
    logger.log(e);
    Console.WriteLine("App failed to run");
}

Console.ReadKey();