using System.Collections.Generic;
using System;
using System.Windows.Forms;

public enum Categorias
{
    VIP,
    Medium,
    Standart
}

public class SpectacleModel
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public DateTime Date { get; set; }
    public Dictionary<Categorias, decimal> Categories { get; set; }
    public int FreePlace { get; set; }
}