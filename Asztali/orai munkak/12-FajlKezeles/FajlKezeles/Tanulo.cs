namespace FajlKezeles;

class Tanulo
{
    // Nyilvános mezők
    public string Nev { get; set; }
    public int Evfolyam { get; set; }
    public char Csoport { get; set; }
    public bool Estis { get; set; }

    /// <summary>
    /// A megfelelő adatokból elkészíti a példányt
    /// </summary>
    public Tanulo(string nev, int evfolyam, char csoport, bool estis)
    {
        Nev = nev;
        Evfolyam = evfolyam;
        Csoport = csoport;
        Estis = estis;
    }

    /// <summary>
    /// Egyetlen szöveget feladarabolva megpróbál Tanulót készíteni
    /// </summary>
    public Tanulo(string szoveg, string elvalaszto = ";")
    {
        // string "Bence;12;B;false"
        string[] darabok = szoveg.Split(elvalaszto);

        // string[] ["Bence", "12", "B", "false"]
        Nev = darabok[0];
        Evfolyam = int.Parse(darabok[1]);
        Csoport = char.Parse(darabok[2]);
        Estis = bool.Parse(darabok[3]);
    }

    /// <summary>
    /// Írjuk felül az örökölt szöveggé alakító metódust
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{Nev};{Evfolyam};{Csoport};{Estis}";
    }

    /// <summary>
    /// Másolatot készítünk az aktuális példányról.
    /// </summary>
    public Tanulo Clone()
    {
        Tanulo masolat = new(Nev, Evfolyam, Csoport, Estis);

        return masolat;
    }

    /// <summary>
    /// Egy másik tanuló adatait másoljuk magunkba.
    /// </summary>
    public void CopyFrom(Tanulo masik)
    {
        Nev = masik.Nev;
        Evfolyam = masik.Evfolyam;
        Csoport = masik.Csoport;
        Estis = masik.Estis;
    }
}
