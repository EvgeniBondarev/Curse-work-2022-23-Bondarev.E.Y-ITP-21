﻿using System;

/// <summary>
/// Класс сущности билета
/// </summary>
public class TicketModel
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public Categorias Category { get; set; }
    public decimal Price { get; set; }
}
