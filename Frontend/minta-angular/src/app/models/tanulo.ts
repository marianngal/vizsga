export interface Tanulo {
    id: number;// Egyedi azonosító (PRIMARY KEY az adatbázisban)
    nev: string;// Tanuló neve
    osztaly: string;// Osztály (pl. '9.A', '10.B')
    pontszam: number;// Valamilyen pontszám (dolgozat, projekt stb.)
}

