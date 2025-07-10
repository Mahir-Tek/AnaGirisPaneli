namespace AnaGirisPaneli.Models
{
    public class Kullanici
    {
        public int Id { get; set; } //Primary Key
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password {  get; set; }
        public string KMail { get; set; }
    }
}
