import { Component } from '@angular/core';

@Component({
  selector: 'app-szavazat',
  standalone: false,
  templateUrl: './szavazat.html',
  styleUrl: './szavazat.css',
})
export class Szavazat {
  //Kerület
  //Szavazatok száma
  //Vezetéknév
  //Keresztnév
  //Párt(HEP,GYEP,ZEP,TISZ)/független(-)

  keruletInput!: number;
  szavazatInput!: number;
  vezeteknevInput!: string;
  keresztnevInput!: string;
  partInput!: string;

Mentes() {
  let ujSzavazo = new SzavazoElem(
    this.keruletInput + " " +this.szavazatInput + " " +
    this.vezeteknevInput + " " + this.keresztnevInput + " " +
    this.partInput
  );
  this.szavazatok.push(ujSzavazo);
  this.keruletInput=0;
  this.szavazatInput=0;
  this.vezeteknevInput="";
  this.keresztnevInput="";
  this.partInput="";
}

adatok: string = `
5 19 Ablak Antal -
1 120 Alma Dalma GYEP
7 162 Bab Zsuzsanna ZEP
2 59 Barack Barna GYEP
6 73 Birs Helga GYEP
1 154 Bors Botond HEP
5 188 Brokkoli Gyula ZEP
6 29 Ceruza Zsombor -
4 143 Fasirt Ferenc HEP
8 157 Gomba Gitta TISZ
3 13 Halmi Helga -
2 66 Hold Ferenc -
7 34 Hurka Herold HEP
5 288 Joghurt Jakab TISZ
4 77 Kajszi Kolos GYEP
2 187 Kapor Karola ZEP
6 13 Karfiol Ede ZEP
6 187 Kefir Ilona TISZ
7 130 Kupa Huba -
8 98 Languszta Auguszta -
1 34 Lila Lilla -
1 56 Medve Rudolf -
5 67 Meggy Csilla GYEP
3 45 Moly Piroska -
4 221 Monitor Tibor -
8 288 Narancs Edmond GYEP
2 220 Oldalas Olga HEP
3 185 Pacal Kata HEP
1 199 Petrezselyem Petra ZEP
8 77 Pokol Vidor -
8 67 Ragu Ida HEP
3 156 Retek Etelka ZEP
7 129 Sajt Hajnalka TISZ
4 38 Simon Simon -
3 87 Szilva Szilvia GYEP
3 187 Tejes Attila TISZ
2 65 Tejfel Edit TISZ
4 39 Uborka Ubul ZEP
6 288 Vadas Marcell HEP
5 68 Vagdalt Edit HEP`

SzavazoFeltolto(feltoltendoElem: string): SzavazoElem[] {
  let beolvasottAdat: SzavazoElem[] = [];
  const sorok = feltoltendoElem.trim().split("\n");
  for (let i = 0; i < sorok.length; i++) {
    beolvasottAdat.push(new SzavazoElem(sorok[i]));
  }
  return beolvasottAdat;
}

  szavazatok: SzavazoElem[] = this.SzavazoFeltolto(this.adatok);
}

export interface SzavazoAdat {
  kerulet: number;
  szavazat: number;
  vezeteknev: string;
  keresztnev: string;
  part: string;
}

class SzavazoElem implements SzavazoAdat {
  kerulet: number;
  szavazat: number;
  vezeteknev: string;
  keresztnev: string;
  part: string;

  constructor(adat: string) {
    const db = adat.split("\n"
    )[0].split(" ");
    this.kerulet = Number(db[0]);
    this.szavazat = Number(db[1]);
    this.vezeteknev = db[2];
    this.keresztnev = db[3];
    this.part = db[4];
  }  

}
