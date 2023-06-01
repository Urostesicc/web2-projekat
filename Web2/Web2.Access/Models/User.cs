namespace Web2.Models
{
    public enum Tip { Administrator=0, Prodavac=1, Kupac=2 }
    public class User
    {
        public long Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public bool Verifikovan { get; set; }
        public Tip TipKorisnika { get; set; }
        public List<Artikal> Artikli { get; set; }
        public List<Narudzbina> Narudzine { get; set; }

    }
}
