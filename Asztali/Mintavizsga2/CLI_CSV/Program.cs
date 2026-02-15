// See https://aka.ms/new-console-template for more information
using System.Text.Json;

List<Ad> lista=File
    .ReadAllLines("realestates.csv")
    .Skip(1)
    .Select(sor=>new Ad(sor))
    .ToList();

Console.WriteLine(lista.Count);
string json_szoveg=JsonSerializer.Serialize(lista);

File.WriteAllText("export.json", json_szoveg);

//szűrt adatok:
List<Ad> szurt_lista=lista.Where(x=>x.area>100).ToList();
string json_szurt = JsonSerializer.Serialize(szurt_lista);

File.WriteAllText("export_szurt.json", json_szurt);

