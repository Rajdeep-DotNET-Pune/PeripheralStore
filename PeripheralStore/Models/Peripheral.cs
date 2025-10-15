// Models/Peripheral.cs
using System;
namespace PeripheralStore.Models;

public class Peripheral
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }  // e.g., Keyboard, Mouse, Monitor
    public int QuantityInStock { get; set; }
    public decimal Price { get; set; }
    public DateTime AddedDate { get; set; }
}
