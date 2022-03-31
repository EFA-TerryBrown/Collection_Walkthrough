public class Person
{
    public Person() { }
    public Person(string firstName, string lastName, FavoriteColor favoriteColor)
    {
        FirstName = firstName;
        LastName = lastName;
        FavoriteColor = favoriteColor;
    }
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
    public FavoriteColor FavoriteColor { get; set; }
}