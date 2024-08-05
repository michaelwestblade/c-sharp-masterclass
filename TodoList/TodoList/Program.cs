Console.WriteLine("Hello!");

void PrintOptions()
{
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODOs");
    Console.WriteLine("[R]emove a TODOs");
    Console.WriteLine("[E]xit");
}

List<string> todos = new List<string>();
bool shallExit = false;

while (!shallExit)
{
    PrintOptions();

    var userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "E":
        case "e":
            shallExit = true;
            Console.WriteLine("Exit");
            break;
        case "S":
        case "s":
            SeeAllTodos();
            break;
        case "A":
        case "a":
            AddTodo();
            break;
        case "R":
        case "r":
            RemoveTodo();
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
}

Console.ReadKey();

void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet");
        return;
    }
    else
    {
        for (var index = 0; index < todos.Count; index++)
        {
            var todo = todos[index];
            Console.WriteLine($"{index+1}. {todo}");
        }
    }
}

void AddTodo()
{
    bool isValidDescription = false;

    while (!isValidDescription)
    {
        Console.WriteLine("Enter the TODO description: ");
        var description = Console.ReadLine();

        if (description == "")
        {
            Console.WriteLine("The description cannot be empty");
        } 
        else if (todos.Contains(description))
        {
            Console.WriteLine("The description must be unique");
        }
        else
        {
            todos.Add(description);
            isValidDescription = true;
        }
    }
}

void RemoveTodo()
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet");
        return;
    }

    bool isIndexValid = false;

    while (!isIndexValid)
    {
        Console.WriteLine("Select the index of the todo you want to remove");
        SeeAllTodos();

        if (TryToReadIndex(out int index))
        {
            var todoToBeRemoved = todos[index - 1];
            todos.RemoveAt(index - 1);
            isIndexValid = true;
            Console.WriteLine($"Removed TODO: {todoToBeRemoved}");
        }
    }
}

bool TryToReadIndex(out int index)
{
    var userInput = Console.ReadLine();

    if (userInput == "")
    {
        Console.WriteLine("Selected index cannot be empty");
        index = 0;
        return false;
    }

    if (int.TryParse(userInput, out index) && index >= 1 && index <= todos.Count)
    {
        return true;
    }
    
    Console.WriteLine("The given index is not valid");
    return false;
}