// Hozzáadjuk a forrásfájl a solution explorerhez
// Properties menüponton (F4 vagy jobb katt > tulajdonságok)
// Átállítjuk a "Do Not Copy" lehetőséget Copy Always" vagy "Copy if newer"-re

using FajlKezeles;

var tartalom = File.ReadAllLines("forras.txt");

List<Tanulo> diakok = [];

// feldolgozás
foreach (var sor in tartalom)
{
    Tanulo peldany = new(sor);

    // felvesszük a listába
    diakok.Add(peldany);
}

// példa mondjuk szűrésre
List<string> eredmeny = [];

foreach (var valaki in diakok)
{
    if (valaki.Estis)
    {
        eredmeny.Add(valaki.ToString());
    }
}

// Végül fájlba mentjük az eredményt
File.WriteAllLines("teszt.txt", eredmeny);

// fenti kód LINQ módszerrel

var tanulok = File
    .ReadAllLines("forras.txt")
    .Select(sor => new Tanulo(sor))
    .ToList();

// valamilyen számítás

var kimenet = tanulok
    .Where(diak => diak.Estis)
    .Select(diak => diak.ToString());

// fájlba mentés

File.WriteAllLines("export.txt", kimenet);