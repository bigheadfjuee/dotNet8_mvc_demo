namespace mvc8.Models;

public class HomeModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string JsonArr {get; set;}

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, JsonArr: {JsonArr}";
    }
}

public class HomeModelJ
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<int> JsonArr {get; set;}

    public override string ToString()
    {
      string arr = string.Join(",", JsonArr);
        return $"Name: {Name}, Age: {Age}, JsonArr: {arr}";
    }
}
