using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly Person_Repository _pRepo = new Person_Repository();
    public void Run()
    {
        SeedData();
        RunApplication();
    }
    private void RunApplication()
    {

        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to the Person Database");
            System.Console.WriteLine("Please Make A Selection\n" +
            "1.  Add Person to Database\n" +
            "2.  View All People in Database\n" +
            "3.  View All People by First Names\n" +
            "4.  View Person Details by ID\n" +
            "5.  Update Person Data\n" +
            "6.  Delete Person Data\n" +
            "7.  Get All People That Like the Same Color\n" +
            "50. Close Application\n");

            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddPersonToDatabase();
                    break;
                case "2":
                    ViewAllPeopleInDatabase();
                    break;
                case "3":
                    ViewAllPeopleByFirstNames();
                    break;
                case "4":
                    ViewPersonDetailsByID();
                    break;
                case "5":
                    UpdatePersonData();
                    break;
                case "6":
                    DeletePersonData();
                    break;
                case "7":
                    GetAllPeopleThatLiketheSameColor();
                    break;
                case "50":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection.");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }
    private void GetAllPeopleThatLiketheSameColor()
    {
        Console.Clear();
        System.Console.WriteLine("Please select a color\n" +
        "1. Red\n" +
        "2. Blue\n" +
        "3. Green\n" +
        "4. Purple\n" +
        "5. Yellow\n" +
        "6. Orange\n" +
        "7. Brown\n" +
        "8. Black\n" +
        "9. White\n");

        var userInput = int.Parse(Console.ReadLine());
        var conversion = (FavoriteColor)userInput;

        var people = _pRepo.GetPeopleThatLikeTheSameColor(conversion);
        if (people.Count > 0)
        {
            Console.Clear();
            System.Console.WriteLine("We Like the same color:");
            foreach (var person in people)
            {
                DisplayPersonDetails(person);
            }
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine($"Sorry no one likes {conversion}");
        }

        PressAnyKeyToContinue();
    }
    private bool CloseApplication()
    {
        Console.Clear();
        PressAnyKeyToContinue();
        return false;
    }
    private void DeletePersonData()
    {
        Console.Clear();
        DisplayPersonForSelection();
        System.Console.WriteLine("Please enter a valid person ID:");
        var userInput = int.Parse(Console.ReadLine());

        if (_pRepo.DeletePersonData(userInput))
        {
            System.Console.WriteLine("Person was Successfully Deleted!");
        }
        else
        {
            System.Console.WriteLine("Person was not Deleted!");
        }
        PressAnyKeyToContinue();
    }
    private void DisplayPersonForSelection()
    {
        foreach (Person person in _pRepo.GetAllPeople())
        {
            System.Console.WriteLine($"PersonID: {person.ID} \nPersonName: {person.FullName}\n----------------------------------\n");
        }
    }
    private void UpdatePersonData()
    {
        Console.Clear();
        DisplayPersonForSelection();
        System.Console.WriteLine("Please enter a valid person ID:");
        var userInputPersonID = int.Parse(Console.ReadLine());

        var selectedPerson = _pRepo.GetPersonByID(userInputPersonID);
        if (selectedPerson != null)
        {
            Console.Clear();
            var person = new Person();

            System.Console.WriteLine("Please Enter a First Name.");
            person.FirstName = Console.ReadLine();
            System.Console.WriteLine("Please Enter a Last Name.");
            person.LastName = Console.ReadLine();
            System.Console.WriteLine("Whats your Favorite Color? \n" +
            "1. Red\n" +
            "2. Blue\n" +
            "3. Green\n" +
            "4. Purple\n" +
            "5. Yellow\n" +
            "6. Orange\n" +
            "7. Brown\n" +
            "8. Black\n" +
            "9. White\n");

            var userInput = int.Parse(Console.ReadLine());
            var conversion = (FavoriteColor)userInput;
            person.FavoriteColor = conversion;

            if (_pRepo.UpdatePersonData(selectedPerson.ID, person))
            {
                System.Console.WriteLine("Success");
            }
            else
            {
                System.Console.WriteLine($"Sorry the person with the ID: {userInput} Doesn't Exist!");
            }
        }
    }
    private void ViewPersonDetailsByID()
    {
        Console.Clear();
        DisplayPersonForSelection();
        System.Console.WriteLine("Please enter a valid person ID:");
        var userInput = int.Parse(Console.ReadLine());

        var person = _pRepo.GetPersonByID(userInput);
        if (person != null)
        {
            Console.Clear();
            DisplayPersonDetails(person);
        }

        PressAnyKeyToContinue();
    }
    private void DisplayPersonDetails(Person person)
    {
        System.Console.WriteLine($"PersonID: {person.ID}\n" +
        $"PersonName: {person.FullName}\n" +
        $"FavoriteColor: {person.FavoriteColor}\n" +
        "-----------------------------------------------------\n");
    }
    private void ViewAllPeopleByFirstNames()
    {
        Console.Clear();
        var people = _pRepo.GetPAllPeopleOnlyFirstNames();
        foreach (var person in people)
        {
            System.Console.WriteLine(person.FirstName);
        }
        PressAnyKeyToContinue();
    }
    private void ViewAllPeopleInDatabase()
    {
        Console.Clear();
        var people = _pRepo.GetAllPeople();
        foreach (var person in people)
        {
            DisplayPersonDetails(person);
        }

        PressAnyKeyToContinue();
    }
    private void AddPersonToDatabase()
    {
        Console.Clear();
        var person = new Person();

        System.Console.WriteLine("Please Enter a First Name.");
        person.FirstName = Console.ReadLine();
        System.Console.WriteLine("Please Enter a Last Name.");
        person.LastName = Console.ReadLine();
        System.Console.WriteLine("Whats your Favorite Color? \n" +
        "1. Red\n" +
        "2. Blue\n" +
        "3. Green\n" +
        "4. Purple\n" +
        "5. Yellow\n" +
        "6. Orange\n" +
        "7. Brown\n" +
        "8. Black\n" +
        "9. White\n");

        var userInput = int.Parse(Console.ReadLine());
        var conversion = (FavoriteColor)userInput;
        person.FavoriteColor = conversion;

        if (_pRepo.AddPersonToDB(person))
        {
            System.Console.WriteLine("Success");
        }
        else
        {
            System.Console.WriteLine("Failure");
        }
        PressAnyKeyToContinue();
    }
    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key to Continue");
        Console.ReadKey();
    }
    private void SeedData()
    {
        Person tom = new Person("Tom", "Smith", FavoriteColor.Red);
        Person jack = new Person("Jack", "Dempsey", FavoriteColor.Blue);
        Person mike = new Person("Mike", "Tyson", FavoriteColor.Black);
        Person greg = new Person("Greg", "Gillis", FavoriteColor.Green);
        Person kim = new Person("Kim", "Gillis", FavoriteColor.Black);
        Person darryl = new Person("Darryl", "Gillis", FavoriteColor.Blue);
        Person tina = new Person("Tina", "Gillis", FavoriteColor.Blue);

        List<Person> people = new List<Person> { tom, jack, mike, greg, kim, darryl, tina };

        _pRepo.AddMultiplePeople(people);
    }
}

