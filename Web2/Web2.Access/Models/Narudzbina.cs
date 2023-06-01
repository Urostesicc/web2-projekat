namespace Web2.Models
{
    public enum StatusArtikla { Dostupan=0, Rezervisan=1, ZaPostarinu=2,Prodat=3, Vracen=4}
    public class Narudzbina
    {
        public long Id { get; set; }
        Artikal Artikal { get; set; }
        public User Kupac { get; set; }
        public StatusArtikla StatusArtikla { get; set; }
        public string Adresa { get; set; }
        public int Kolicina { get; set; }
        public DateTime DatumNarucivanja { get; set; }
        public DateTime DatumDolaskaArtikla { get; set; }
    }
}
