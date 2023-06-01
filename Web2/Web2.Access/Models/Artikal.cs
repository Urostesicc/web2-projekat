namespace Web2.Models
{
    public class Artikal
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public User Prodavac { get; set; }
        public List<Narudzbina> Narudzine { get; set; }


    }
}
