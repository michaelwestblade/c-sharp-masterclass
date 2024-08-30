
// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;

var validPerson = new Person("John", 1981);
var invalidDog = new Dog("R");
var validator = new Validator();

Console.WriteLine(validator.Validate(validPerson) ? "Person is valid": "Person is not valid");
Console.WriteLine(validator.Validate(invalidDog) ? "Dog is valid": "Dog is not valid");

Console.ReadKey();

public class Dog
{
    [StringLengthValidate(2,10)]
    public string Name { get; set; }
    public Dog(string name) => Name = name;
}

public class Person
{
    [StringLengthValidate(2,10)]
    public string Name { get; }
    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }
    
    public Person(string name) => Name = name;
}

[AttributeUsage(AttributeTargets.Property)]
class StringLengthValidateAttribute : Attribute
{
    public int MinLength { get; }
    public int MaxLength { get; }

    public StringLengthValidateAttribute(int minLength, int maxLength)
    {
        MinLength = minLength;
        MaxLength = maxLength;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class MustBeLargerThanAttribute : Attribute
{
    public int Min { get; }
        
    public MustBeLargerThanAttribute(int minLength)
    {
        Min = minLength;
    }
}

class Validator
{
    public bool Validate(object obj)
    {
        var type = obj.GetType();
        var propertiesToValidate = type.GetProperties().Where(property => Attribute.IsDefined(property, typeof(StringLengthValidateAttribute)));

        foreach (var property in propertiesToValidate)
        {
            object? propertyValue = property.GetValue(obj);
            if (propertyValue is not string)
            {
                throw new InvalidOperationException(
                    $"Attribute {nameof(StringLengthValidateAttribute)} on type {type.FullName} is not a string.");
            }
            
            var value = (string)propertyValue;
            var attribute = (StringLengthValidateAttribute)
                property.GetCustomAttributes(
                    typeof(StringLengthValidateAttribute), true).First();

            if (value.Length < attribute.MinLength || value.Length > attribute.MaxLength)
            {
                Console.WriteLine($"Property {property.Name} must be between {attribute.MinLength} and {attribute.MaxLength}.");
                return false;
            }
        }

        return true;
    }
}