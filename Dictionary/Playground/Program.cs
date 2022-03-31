Console.Clear();
//Dictionaries are TKey, TValue pairs
//declaration                     =    initialization
Dictionary<int, Person> employees = new Dictionary<int, Person>();

//add to dictionary<int,Person>
employees.Add(1, new Person("Bill", "Burr", FavoriteColor.Blue));
employees.Add(2, new Person("Steve", "Harvey", FavoriteColor.Red));
//employees.Add(2, new Person("Katt", "Williams", FavoriteColor.Yellow));
employees.Add(3, new Person("Damon", "Wayons", FavoriteColor.Green));





//This is here so we can see whats goin on....
//sometimes the cpu is just too fast...
Console.ReadKey();
