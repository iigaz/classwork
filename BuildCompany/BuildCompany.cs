namespace BuildCompany;

public class BuildCompany<T> where T : IBuilder<House, Requirements>
{
    public BuildCompany(T builder)
    {
        Builder = builder;
    }

    private T Builder { get; }
    public List<House> FinishedHouses { get; } = new();

    public void BuildHouseByRequirements(Requirements requirements)
    {
        FinishedHouses.Add(Builder.Build(requirements));
    }

    public House GetDreamHouse(Func<List<House>, List<House>> filter)
    {
        var filtered = filter(FinishedHouses);
        if (filtered.Count == 0)
            throw new Exception("Your dream will remain just a dream. There is no such house.");
        return filtered[0];
    }

    public Dictionary<int, List<House>> GetHouseGroupingByFloor()
    {
        var result = new Dictionary<int, List<House>>();
        foreach (var house in FinishedHouses)
            if (result.ContainsKey(house.FloorCount))
                result[house.FloorCount].Add(house);
            else
                result[house.FloorCount] = new List<House> { house };
        return result;
    }

    public void PayFlat(House house, FlatRequirements flatRequirements, decimal cost)
    {
        var flats = house.Flats.FindAll(flat => (flatRequirements.Floor == -1 || flat.Floor == flatRequirements.Floor)
                                                && flat.Cost < flatRequirements.UpperCost
                                                && flat.IsRich == flatRequirements.IsRich
                                                && flat.RoomCount == flatRequirements.RoomCount);
        if (flats.Count == 0)
            throw new Exception("No flats were found.");
        if (flats.All(flat => flat.IsSold))
            throw new Exception("All flats sold out.");

        var selectedFlat = flats.Find(flat => flat.Cost * (flat.IsRich ? 1.5m : 1) <= cost);
        if (selectedFlat == null)
            throw new Exception("Sorry Link, I can't give credit. Come back when you are a little richer.");
        selectedFlat.IsSold = true;
    }
}