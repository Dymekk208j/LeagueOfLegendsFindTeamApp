﻿using System.Collections.Generic;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public interface IRepository<TEnt, in TPk> where TEnt : class
    {
        IEnumerable<TEnt> GetAll();
        TEnt Get(TPk id);
        bool Add(TEnt entity);
        bool Remove(TEnt entity);
        bool Remove(TPk id);
        bool Update(TEnt entity);
    }
}