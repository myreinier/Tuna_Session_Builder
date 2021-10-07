using System;
using System.Collections.Generic;
using System.Linq;
using Tuna_Session_Builder.Domain;
using Tuna_Session_Builder.Domain.Interfaces;
using Tuna_Session_Builder.Domain.Objects;

namespace Tuna_Session_Builder.Business
{
    public class SongService : ISongService
    {
        private Mockdata Data;

        public SongService(Mockdata data)
        {
            Data = data;
        }

        public void Compare()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> Get()
        {
            return Data.songs.OrderBy(x => x.Title);
        }

        public List<Song> Search(List<Song> songs, string query)
        {
            return songs.Where(x => x.Title.Contains(query) ||
                                    x.Type.Contains(query) ||
                                    x.Information.Contains(query)).ToList();
        }

        public List<Song> Suggestion(List<Song> songs, string query)
        {
            return songs.Where(x => !x.Type.Contains(query)).ToList();
        }
    }
}
