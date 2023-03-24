// Спасибо за IsReach, посмеялся.

using BuildCompany;

List<House> GetHouses(List<House> houses)
{
    return houses.FindAll(house => house.FloorCount > 15);
}

var builder = new SimpleBuilder();
var company = new BuildCompany<SimpleBuilder>(builder);

company.BuildHouseByRequirements(new Requirements
{
    FlatCount = 10,
    FloorCount = 5,
    IsRich = true,
    TypeOfHouse = TypeOfHouse.Residential
});
company.BuildHouseByRequirements(new Requirements
{
    FlatCount = 40,
    FloorCount = 20,
    IsRich = false,
    TypeOfHouse = TypeOfHouse.Residential
});
company.BuildHouseByRequirements(new Requirements
{
    FlatCount = 20,
    FloorCount = 2,
    IsRich = false,
    TypeOfHouse = TypeOfHouse.Mall
});
company.BuildHouseByRequirements(new Requirements
{
    FlatCount = 1000,
    FloorCount = 100,
    IsRich = false,
    TypeOfHouse = TypeOfHouse.Office
});

Console.WriteLine("Однажды мальчик пожелал: хочу кирпичный дом....");
Console.WriteLine("На следующий день он открывает глаза и видит:");
var house = company.GetDreamHouse(list => list.FindAll(house => house.ArchType == ArchType.Brick));
Console.WriteLine(house);
Console.WriteLine();

Console.WriteLine("Мальчик обрадовался, но подумал, и пожелал: хочу высокий чтобы был....");
Console.WriteLine("На следующий день он открывает глаза и видит:");
house = company.GetDreamHouse(GetHouses);
Console.WriteLine(house);
Console.WriteLine();

Console.WriteLine("Счастью мальчика не было предела, пока не пришел матанализ и заставил находить этот предел.");
Console.WriteLine("Не захотел мальчик изучать матан, и пожелал: хочу самое высокое здание какое есть....");
Console.WriteLine("На следующий день он открывает глаза и видит:");
var houses = company.GetHouseGroupingByFloor();
house = houses[houses.MaxBy(pair => pair.Key).Key][0];
Console.WriteLine(house);
Console.WriteLine();

Console.WriteLine(
    $"Не было времени думать у мальчика, и он решает купить недорогую 1 комнатную квартиру в этом доме на {house.FloorCount} этаже за свои 100000 рублей.");
Console.WriteLine("Говорят ему в строительной компании:");
company.PayFlat(house, new FlatRequirements
{
    Floor = house.FloorCount,
    IsRich = false,
    RoomCount = 1,
    UpperCost = 110000
}, 100000);
Console.WriteLine("Конечно малой!");
Console.WriteLine(
    "И купил он квартиру. А потом он понял, что добился в этой жизни всего, чего хотел, и его настигла депрессия.");
Console.WriteLine("А что было дальше, мы с вами и не узнаем. Конец.");