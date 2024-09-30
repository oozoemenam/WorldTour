using WorldTour.Enums;

namespace WorldTour.Models;

public class TourPackage
{
    public int Id { get; set; }
    public int ListId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string WhatToExpect { get; set; } = string.Empty;
    public string MapLocation { get; set; } = string.Empty;
    public float Price { get; set; }
    public int Duration { get; set; }
    public bool InstantConfirmation { get; set; }
    public Currency Currency { get; set; }
    public TourList? TourList { get; set; }
}