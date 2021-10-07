using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna_Session_Builder.Domain.Interfaces
{
    public interface ISongService
    {
        /// <summary>
        /// Get the List of songs with all information and sort them by title
        /// </summary>
        /// <returns>Sorted List of Songs</returns>
        public IEnumerable<Song> Get();

        /// <summary>
        /// Searches for a song by Title, Type or Information
        /// </summary>
        /// <returns>List of Songs with query</returns>
        public List<Song> Search(List<Song> songs, string query);

        /// <summary>
        /// Compares songs in list and determines if consecutive songs should not be next to each other
        /// </summary>
        public void Compare();
    }
}
