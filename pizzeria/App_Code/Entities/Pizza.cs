public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public double Price { get; set; }
    public string Crust { get; set; }
    public string Sause { get; set; }
    public string Image { get; set; }
    public string Review { get; set; }

    public Pizza(int id, string name, string type, double price, string crust, string sause, string image, string review)
    {
        Id = id;
        Name = name;
        Type = type;
        Price = price;
        Crust = crust;
        Sause = sause;
        Image = image;
        Review = review;
    }

    public Pizza(string name, string type, double price, string crust, string sause, string image, string review)
    {
        Name = name;
        Type = type;
        Price = price;
        Crust = crust;
        Sause = sause;
        Image = image;
        Review = review;
    }

}