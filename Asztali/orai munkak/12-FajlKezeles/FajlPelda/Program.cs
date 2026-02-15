using System.Text;
using System.Text.Json;

// fájl beolvasása
string jsonUserData = File.ReadAllText("userData.json", Encoding.UTF8);

// konvertálás példánnyá
User user = JsonSerializer.Deserialize<User>(jsonUserData);

// tesztelésként
Console.WriteLine(user.firstName);
Console.WriteLine(user.lastName);

// végzünk vele valamilyen "feladatot"
user.email = "teszt@modosit.as";
user.id = 1000;

// opcionális beállítások
var tordelt = new JsonSerializerOptions { WriteIndented = true };

// visszaalakítjuk
string jsonOutput = JsonSerializer.Serialize(user, tordelt);

// fájlba mentjük
File.WriteAllText("testExport.json", jsonOutput, Encoding.UTF8);
