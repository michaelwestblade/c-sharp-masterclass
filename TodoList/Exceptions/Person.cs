namespace Exceptions;

public class Person
{
    public string Name { get; }
    public int YearOfBirth { get; }
    
    public Person(string name, int yearOfBirth)
    {
        if (name == String.Empty || name is null)
        {
            throw new ArgumentException("Invalid name.");
        }

        name = Name;

        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException("The year of birth must be between 1900 and the current year.");
        }
    }
}