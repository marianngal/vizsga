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
    public DateTime createAt { get; set; }
    public int sellerId { get; set; }
    public string sellerName { get; set; }
    public string sellerPhone { get; set; }
    public int categoryId { get; set; }
    public string categoryName { get; set; }

    //public Seller seller { get; set; }
    //public Category category { get; set; }


    //public Ad(int id, int rooms, string latLong, int floors, int area, string description, bool freeOfCharge, string imageUrl, Seller seller, Category category, DateTime createAt)
    public Ad(int id, int rooms, string latLong, int floors, int area, string description, bool freeOfCharge, string imageUrl, 
        DateTime createAt, int sellerId, string sellerName, string sellerPhone, int categoryId, string categoryName)
    {
        this.id = id;
        this.rooms = rooms;
        this.latLong = latLong;
        this.floors = floors;
        this.area = area;
        this.description = description;
        this.freeOfCharge = freeOfCharge;
        this.imageUrl = imageUrl;
        this.createAt = createAt;
        this.sellerId = sellerId;
        this.sellerName = sellerName;
        this.sellerPhone = sellerPhone;
        this.categoryId = categoryId;
        this.categoryName = categoryName;
    }

    public Ad(string forras)
    {
        //id;
        //rooms;
        //latlong;
        //floors;
        //area;
        //description;
        //freeOfCharge;
        //imageUrl;
        //createAt;
        //sellerId;
        //sellerName;
        //sellerPhone;
        //categoryId;
        //categoryName
       
        string[] darabok = forras.Split(';');
        this.id = int.Parse(darabok[0]);
        this.rooms = int.Parse(darabok[1]);
        this.latLong = darabok[2];
        this.floors = int.Parse(darabok[3]);
        this.area = int.Parse(darabok[4]);
        this.description = darabok[5];
        this.freeOfCharge = (int.Parse(darabok[6]) == 1);
        this.imageUrl = darabok[7];
        this.createAt = Convert.ToDateTime(darabok[8]);
        this.sellerId = int.Parse(darabok[9]);
        this.sellerName = darabok[10];
        this.sellerPhone = darabok[11];
        this.categoryId = int.Parse(darabok[12]);
        this.categoryName = darabok[13];
    }


    public double DistanceTo(double lat, double lon)
    {
        var lat_this = Convert.ToDouble(this.latLong.Split(',')[0].Replace('.', ','));
        var long_this = Convert.ToDouble(this.latLong.Split(',')[1].Replace('.', ','));
        var dist1 = (lat - lat_this) * (lat - lat_this);
        var dist2 = (lon - long_this) * (lon - long_this);
        return Math.Sqrt(dist1 + dist2);
    }

    public static List<Ad> LoadFromJSON(string fajlnev)
    {
        string tartalom = File.ReadAllText(fajlnev);

        List<Ad> lista = JsonSerializer.Deserialize<List<Ad>>(tartalom);
        return lista;
    }
    public static void SaveToJSON(List<Ad> lista)
    {
        string json = JsonSerializer.Serialize(lista);
        File.WriteAllText("export.json", json);
    }
}


