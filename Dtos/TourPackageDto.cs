﻿using AutoMapper;
using WorldTour.Common.Mappings;
using WorldTour.Models;

namespace WorldTour.Dtos;

public class TourPackageDto : IMapFrom<TourPackage>
{
    public int Id { get; set; }
    public int ListId { get; set; }
    public string Name { get; set; }
    public int Duration { get; set; }
    public bool InstantConfirmation { get; set; }
    public int Currency { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TourPackage, TourPackageDto>()
            .ForMember(
                d => d.Currency,
                opt => opt.MapFrom(s => (int)s.Currency)
            );
    }
}