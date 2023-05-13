using System.Collections.Generic;
using System;
using System.Windows.Forms;

public enum Categorias
{
    VIP,
    Medium,
    Standart
}

/// <summary>
/// Класс сущности спектакля
/// </summary>
public class SpectacleModel
{
    /// <summary>
    /// Название спектакля
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Автор спектакля
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Жанр спектакля
    /// </summary>
    public string Genre { get; set; }

    /// <summary>
    /// Дата проведения спектакля
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Категории и цены билетов на спектакль
    /// </summary>
    public Dictionary<Categorias, decimal> Categories { get; set; }

    /// <summary>
    /// Количество свободных мест на спектакль
    /// </summary>
    public int FreePlace { get; set; }
}