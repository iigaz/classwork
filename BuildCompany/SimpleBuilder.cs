namespace BuildCompany;

public class SimpleBuilder : IBuilder<House, Requirements>
{
    public House Build(Requirements parameter)
    {
        var house = new House
        {
            ArchType = parameter.TypeOfHouse switch
            {
                TypeOfHouse.Office => ArchType.VentFacade,
                TypeOfHouse.Residential => parameter.IsRich ? ArchType.Brick : ArchType.Panel,
                TypeOfHouse.Mall => ArchType.Block,
                _ => ArchType.VentFacade
            },
            FloorCount = parameter.FloorCount,
            HouseId = Guid.NewGuid()
        };
        house.Flats.AddRange(GenerateFlatsTotallyNotRandom(parameter));
        return house;
    }

    private static IEnumerable<Flat> GenerateFlatsTotallyNotRandom(Requirements requirements)
    {
        var random = new Random();
        var result = new List<Flat>();
        for (var i = 0; i < requirements.FlatCount; i++)
            result.Add(new Flat
            {
                FlatNumber = i,
                Floor = random.Next(1, requirements.FloorCount + 1),
                Cost = random.Next(10, 200000),
                IsRich = requirements.IsRich,
                IsSold = false,
                RoomCount = random.Next(1, requirements.IsRich ? 8 : 4)
            });
        return result;
    }
}