using System;
using System.Collections.Generic;
using System.Linq;
using Tuna_Session_Builder.Domain;
using Tuna_Session_Builder.Domain.Interfaces;

namespace Tuna_Session_Builder.Business
{
    public class SongService : ISongService
    {
        readonly List<Song> songs = new()
        {
            new Song { Title="Adelita",             Type="Paso doble",          TimeSignature = "2/4",      Information="Starter"},
            new Song { Title="Alma Llanera",        Type="Joropo",              TimeSignature = "6/8",      Information = "" },
            new Song { Title="Aqui esta la Tuna",   Type="Paso doble",          TimeSignature = "2/4",      Information="Starter" },
            new Song { Title="La Aurora",           Type="Vals, Paso doble",    TimeSignature = "2/4", Information = "" },
            new Song { Title="La Bikina",           Type="Joropo",              TimeSignature = "6/8", Information = "" },
            new Song { Title="Cielito Lindo",       Type="Copla",               TimeSignature = "3/4", Information = "" },
            new Song { Title="Clavelitos",          Type="Vals",                TimeSignature = "3/4", Information = "" },
            new Song { Title="Guantanamera",        Type="Son",                 TimeSignature = "4/4", Information = "" },
            new Song { Title="Hoy Estoy Aqui",      Type="Huayno",              TimeSignature = "2/4", Information = "" },
            new Song { Title="Moliendo cafe",       Type="Tropical",            TimeSignature = "4/4", Information = "" },
            new Song { Title="La Paloma",           Type="Tango, Paso doble",   TimeSignature = "4/4", Information = "" },
            new Song { Title="El Parandero",        Type="Paso doble",          TimeSignature = "2/4",      Information="Starter, Finisher" },
            new Song { Title="Piel canela",         Type="Son",                 TimeSignature = "4/4", Information = "" },
            new Song { Title="San Cayetano",        Type="Paso doble",          TimeSignature = "2/4", Information = "Finisher" }
        };

        public void Compare()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> Get()
        {
            return songs.OrderBy(x => x.Title);
        }

        public List<Song> Search(string query)
        {
            return songs.Where(x => x.Title.Contains(query) ||
                                    x.Type.Contains(query) ||
                                    x.Information.Contains(query)).ToList();
        }

        public List<Song> Suggestion(string query)
        {
            return songs.Where(x => !x.Type.Contains(query)).ToList();
        }
    }
}
