public enum Gender
{
    Male,
    Female,
    Other
}

abstract class User
{
    public string type;
    public string name;
    public Gender gender;
    public int age;

    public User(string type, string name, Gender gender, int age)
    {
        this.type = type;
        this.name = name;
        this.gender = gender;
        this.age = age;
    }

    public abstract string GetUserName();
    public abstract string GetUserType();
    public abstract int GetAge();
    public abstract Gender GetGender();
}

class Admin : User
{
    public Admin(string name, Gender gender, int age) : base("Admin", name, gender, age);
}

class Moderator : User
{
    public Moderator(string name, Gender gender, int age) : base("Moderator", name, gender, age);
}

