﻿using WorldTour.Dtos;

namespace WorldTour.TourLists.Queries.GetTours;

public class ToursVm
{
    public IList<TourListDto> Lists { get; set; } = new List<TourListDto>();
}