﻿// See https://aka.ms/new-console-template for more information

using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetStats;

try
{
    await new StarWarsPlanetStatsApp(new ApiDataReader()).Run();
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.Message);
}

Console.ReadKey();