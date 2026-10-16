public class Client
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Adresse { get; set; }

    public Client(int Id, string Nom, string Prenom, string Adresse)
    {
        this.Id = Id;
        this.Nom = Nom;
        this.Prenom = Prenom;
        this.Adresse = Adresse;
    }

    public override string ToString() => $"{Id} - {Nom} {Prenom}";
} 
