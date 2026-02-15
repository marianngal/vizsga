// See https://aka.ms/new-console-template for more information

string fajl = "realestates.json";

List<Ad> lista=Ad.LoadFromJSON(fajl);

int db = 0;
double osszeg = 0;
//foreach (var item in lista)
//{
//    if (item.floors==1)
//        {
//        osszeg += item.area;
//        db++;       
//        }
//}

db =lista.Where(x => x.floors == 0).Count();
osszeg = lista.Where(y => y.floors == 0).Sum(x=>x.area);

double atlag = Math.Round(osszeg / db, 2);
Console.WriteLine($"1. feladat: Földszinti ingatlanok átlagos alapterületet: {atlag} m2");

Console.WriteLine(lista.First().DistanceTo(1, 1));