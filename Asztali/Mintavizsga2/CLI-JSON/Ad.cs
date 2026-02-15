using System.Text.Json;

public class Ad
{
    public int id { get; set; }
    public int rooms { get; set; }
    public string latLong { get; set; }
    public int floors { get; set; }
    public int area { get; set; }
    public string description { get; set; }
    public bool freeOfCharge { get; set; }
    public string imageUrl { get; set; }
    public string seller {  get; set; }
    public string category { get; set; }

    //public Seller seller { get; set; }
    //public Category category { get; set; }
    public DateTime createAt { get; set; }

    //public Ad(int id, int rooms, string latLong, int floors, int area, string description, bool freeOfCharge, string imageUrl, Seller seller, Category category, DateTime createAt)
    public Ad(int id, int rooms, string latLong, int floors, int area, string description, bool freeOfCharge, string imageUrl, string seller, string category, DateTime createAt)
    {
        this.id = id;
        this.rooms = rooms;
        this.latLong = latLong;
        this.floors = floors;
        this.area = area;
        this.description = description;
        this.freeOfCharge = freeOfCharge;
        this.imageUrl = imageUrl;
        this.seller = seller;
        this.category = category;
        this.createAt = createAt;
    }

    public Ad(string forras)
    {
        //1;5;47.5410485803319,19.1516419487702;1;165;;0;https://drive.google.com/file/d/1qs5XyJNnnT_meJn_qVJLwASvY1By2bVj;2021-11-17;56;Fazekas Zoltán;+36 1 9929-8217;1;ház
        string[] darabok=forras.Split(';');
        this.id = int.Parse(darabok[0]);
        this.rooms = int.Parse(darabok[1]);
        this.latLong = darabok[2];
        this.floors = int.Parse(darabok[3]);
        this.area = int.Parse(darabok[4]);
        this.description = darabok[5];
        this.freeOfCharge = (int.Parse(darabok[6]) == 1);
        this.imageUrl = darabok[7];
        this.seller = darabok[8];
        this.category = darabok[9];
        this.createAt = Convert.ToDateTime(darabok[10]);
    }


    public double DistanceTo(double lat, double lon)
    {
        var lat_this = Convert.ToDouble(this.latLong.Split(',')[0].Replace('.',','));
        var long_this = Convert.ToDouble(this.latLong.Split(',')[1].Replace('.', ','));
        var dist1 = (lat - lat_this)*(lat-lat_this);
        var dist2 = (lon-long_this)*(lon-long_this);
        return Math.Sqrt(dist1 + dist2);
    }

    public static List<Ad> LoadFromJSON (string fajlnev){
        string tartalom=File.ReadAllText(fajlnev);

        List<Ad> lista = JsonSerializer.Deserialize<List<Ad>>(tartalom);
        return lista;
    }
    public static void SaveToJSON(List<Ad> lista) { 
        string json = JsonSerializer.Serialize(lista);
        File.WriteAllText("export.json", json);
    }
}


