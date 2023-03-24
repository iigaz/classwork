namespace BuildCompany;

public class Flat
{
    public int Floor { get; set; }
    public decimal Cost { get; set; }
    public bool IsSold { get; set; }
    public int RoomCount { get; set; }
    public bool IsRich { get; set; }
    public int FlatNumber { get; set; } // Этого не было в требованиях, но оно подразумевается там.
}