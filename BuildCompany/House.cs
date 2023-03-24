namespace BuildCompany;

public class House
{
    public List<Flat> Flats { get; } = new();
    public ArchType ArchType { get; set; }
    public Guid HouseId { get; set; }
    public int FloorCount { get; set; }

    public override string ToString()
    {
        return $@"{ArchType switch
        { ArchType.Block => "блочный",
            ArchType.Brick => "кирпичный",
            ArchType.Panel => "панельный",
            ArchType.VentFacade => "вентфасадный",
            _ => "обычный"
        }} дом #{HouseId}, этажей: {FloorCount}, квартир: {Flats.Count}.";
    }
}