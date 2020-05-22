namespace BusinessObjects
{
    public interface IPatient
    {
        string Adress { get; set; }
        int Age { get; set; }
        string Gender { get; set; }
        int Height { get; set; }
        int Id { get; }
        string Name { get; set; }
        string Region { get; set; }
        bool Status { get; set; }
        int Weight { get; set; }
    }
}