using System.Text.Json;

// primitívek

var json = """20""";
var szam = JsonSerializer.Deserialize<int>(json);
Console.WriteLine(szam * szam); // 400

json = """true""";
var logikai = JsonSerializer.Deserialize<bool>(json); // true
if (logikai)
{
    Console.WriteLine("igaz");
}
else
{
    Console.WriteLine("hamis");
}

json = """null""";
var ures = JsonSerializer.Deserialize<object>(json);
if (ures is null)
{
    Console.WriteLine("Null volt");
}
else
{
    Console.WriteLine("Volt értéke");
}

// gyűjtemények
json = 
"""
[
    "alma", 
    "banán", 
    "citrom"
]
""";

var tomb = JsonSerializer.Deserialize<string[]>(json);
for (int i = 0; i < tomb.Length; i++)
{
    Console.WriteLine(tomb[i]);
}

json = """[10, 20, 30]""";

var lista = JsonSerializer.Deserialize<List<int>>(json);
foreach (var item in lista)
{
    Console.WriteLine(item);
}

// Osztályok

json =
"""
{
    "Nev" : "Bence",
    "Kor" : 60,
    "Stb" : "...",
    "Zenek" : [
        { "Megnevezes" : "pop" },
        { "Megnevezes" : "rock" },
        { "Megnevezes" : "punk" }
    ]
}
""";

var valaki = JsonSerializer.Deserialize<Szemely>(json);

Console.WriteLine(valaki.Nev);
Console.WriteLine(valaki.Kor);

foreach (var item in valaki.Zenek)
{
    Console.WriteLine(item.Megnevezes);
}

class Szemely
{
    public string Nev { get; set; }
    public int Kor { get; set; }
    public string Stb { get; set; }
    public List<Stilus> Zenek { get; set; }
}

class Stilus
{
    public string Megnevezes { get; set; }
}