using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna_Session_Builder.Domain;
using Tuna_Session_Builder.Domain.Objects;
using Xunit;

namespace Tuna_Session_Builder.Business.Test.SongServiceTests
{
    public class GetTest
    {
        private readonly List<Song> data = new()
        {
            new Song { Title = "ATest", Id = 1 },
            new Song { Title = "BTest", Id = 2 }
        };

        public readonly SongService songService = new(new Mockdata());
        
        [Fact]
        public void Should()
        {
            // Act

            // Assert

        }
    }
}
