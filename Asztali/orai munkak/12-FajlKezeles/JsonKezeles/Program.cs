// régebben ezt 3rd party toolokkal oldották meg
// például NewtonSoft.Json könyvtár letöltése NuGetről

// szükséges névterek

using System.Text.Json;

// JSON formátum (JavaScript Object Notation)
// az a szöveges formátum, ahogy JS a példányokat jelöli
// - könnyen olvasható
// - villámgyorsan feldolgozható
// - nyelvfüggetlen szabvány
// - adatcserére tipikusan weben

// C#-ben is megadható literálként három """ között
string jsonAdat =
"""
{
    "név": "Bence",
    "évfolyam": 12,
    "csoport": "C",
    "estis": true,
    "osztályzat": [5,4,5,3,5,2],
    "dícséret": {
        "dátum": "2025-07-01",
        "tantárgy": "programozás"
    }
}
""";
Console.WriteLine(jsonAdat);

// SZERIALIZÁCIÓ (serialization)
// "C#-os változó átalakítása JSON formátumú szöveggé"

// primitívek átalakítása

var szam = 10;
var json = JsonSerializer.Serialize(szam);
Console.WriteLine(json); // 10

var szoveg = "lorem";
json = JsonSerializer.Serialize(szoveg);
Console.WriteLine(json); // "lorem"

var logikai = false;
json = JsonSerializer.Serialize(logikai);
Console.WriteLine(json); // "false"

// gyűjtemények

int[] tomb = [1, 2, 3];
json = JsonSerializer.Serialize(tomb);
Console.WriteLine(json); // [1, 2, 3]

List<int> lista = [1, 2, 3];
json = JsonSerializer.Serialize(lista);
Console.WriteLine(json); // [1, 2, 3]

// osztályokkal mi a helyzet?

var példány = new Szemely
{
    Nev = "Anita",
    Eletkor = 99,
    Felnott = true
};

var jeles = new Osztalyzat() { Szoveg = "jeles", Szamjegy = 5, Szazalek = 80 };
var kozepes = new Osztalyzat() { Szoveg = "közepes", Szamjegy = 3, Szazalek = 50 };

példány.Osztalyzatok.Add(jeles);
példány.Osztalyzatok.Add(kozepes);
példány.Osztalyzatok.Add(kozepes);

json = JsonSerializer.Serialize(példány);
Console.WriteLine(json); // "{"Nev":"Anita","Eletkor":99,"Felnott":true}"

// tördelhető is
var opciók = new JsonSerializerOptions { WriteIndented = true };
json = JsonSerializer.Serialize(példány, opciók);
Console.WriteLine(json);

class Szemely
{
    public string Nev { get; set; }
    public int Eletkor { get; set; }
    public bool Felnott { get; set; }
    public List<Osztalyzat> Osztalyzatok { get; set; } = [];
}

class Osztalyzat
{
    public string Szoveg { get; set; }
    public int Szamjegy { get; set; }
    public int Szazalek { get; set; }
}