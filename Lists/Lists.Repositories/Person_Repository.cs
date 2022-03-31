public class Person_Repository
{
    //we need a 'fake database' so, we will use a list
    private readonly List<Person> _personDB = new List<Person>();
    private int _count = 0;
    //C
    public bool AddPersonToDB(Person person)
    {
        if (person != null)
        {
            _count++;
            person.ID = _count;
            _personDB.Add(person);
            return true;
        }
        return false;
    }
    //C
    public bool AddMultiplePeople(List<Person> people)
    {
        if (people != null)
        {
            foreach (var person in people)
            {
                _count++;
                person.ID = _count;
            }
            _personDB.AddRange(people);
            return true;
        }
        return false;
    }
    //R
    public List<Person> GetAllPeople()
    {
        return _personDB;
    }
    //R
    public Person GetPersonByID(int id)
    {
        var person = _personDB.SingleOrDefault(p => p.ID == id);
        return person;
    }
    //R
    public List<PersonFirstNameDetails> GetPAllPeopleOnlyFirstNames()
    {
        var peopleFirstNames = _personDB.Select(p => new PersonFirstNameDetails
        {
            FirstName = p.FirstName
        }).ToList();
        return peopleFirstNames;
    }
    //R
    public List<Person> GetPeopleThatLikeTheSameColor(FavoriteColor color)
    {
        var people = _personDB.Where(p => p.FavoriteColor == color).ToList();
        return people;
    }
    //U
    public bool UpdatePersonData(int id, Person newPersonData)
    {
        var oldPersonData = GetPersonByID(id);
        if (oldPersonData != null)
        {
            oldPersonData.FirstName = newPersonData.FirstName;
            oldPersonData.LastName = newPersonData.LastName;
            oldPersonData.FavoriteColor = newPersonData.FavoriteColor;
            return true;
        }
        return false;
    }
    //D
    public bool DeletePersonData(int id)
    {
        var personToBeDeleted = _personDB.FirstOrDefault(p => p.ID == id);
        return _personDB.Remove(personToBeDeleted);
    }
}
