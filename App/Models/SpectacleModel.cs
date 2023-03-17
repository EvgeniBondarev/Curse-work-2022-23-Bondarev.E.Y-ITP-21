using System.Collections.Generic;
using System;

public enum Categorias
{
    VIP,
    Medium,
    Standar
}

public class SpectacleModel
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public DateTime Date { get; set; }
    public Dictionary<Categorias, decimal> Categories { get; set; }
}