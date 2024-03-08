using System;

internal class Human
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public double Salary { get; set; }

    public Human(string name, int age, string gender, double salary)
    {
        Name = name;
        Age = age;
        Gender = gender;
        Salary = salary;
    }

    public static Human operator +(Human human, double amount)
    {
        human.Salary += amount;
        return human;
    }
    public static Human operator -(Human human, double amount)
    {
        human.Salary -= amount;
        return human;
    }
    public static bool operator ==(Human human1, Human human2)
    {
        return human1.Salary == human2.Salary;
    }
    public static bool operator !=(Human human1, Human human2)
    {
        return !(human1 == human2);
    }
    public static bool operator >(Human human1, Human human2)
    {
        return human1.Salary > human2.Salary;
    }
    public static bool operator <(Human human1, Human human2)
    {
        return human1.Salary < human2.Salary;
    }
}

internal class Builder : Human
{
    public string Specialization { get; set; }

    public Builder(string name, int age, string gender, double salary, string specialization)
        : base(name, age, gender, salary)
    {
        Specialization = specialization;
    }

    public void Build()
    {
        Console.WriteLine($"{Name} is a {Age}-year-old {Gender} {Specialization}, who can build some cool things.");
    }
}

internal class Sailor : Human
{
    public string Ship { get; set; }

    public Sailor(string name, int age, string gender, double salary, string ship)
        : base(name, age, gender, salary)
    {
        Ship = ship;
    }

    public void Sail()
    {
        Console.WriteLine($"{Name} is a {Age}-year-old {Gender} sailor, who sails the {Ship}.");
    }
}

internal class Pilot : Human
{
    public string Plane { get; set; }

    public Pilot(string name, int age, string gender, double salary, string plane)
        : base(name, age, gender, salary)
    {
        Plane = plane;
    }

    public void Fly()
    {
        Console.WriteLine($"{Name} is a {Age}-year-old {Gender} pilot, who flies {Plane}.");
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Builder bob = new Builder("Bob", 35, "male", 50000, "carpenter");
        Sailor alice = new Sailor("Alice", 28, "female", 45000, "The Black Pearl");
        Pilot john = new Pilot("John", 45, "male", 80000, "Boeing 747");
    }
}
