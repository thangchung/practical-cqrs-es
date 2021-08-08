using System;
using System.Collections.Generic;
using N8T.Core.Domain;

namespace MovieShow.Domain
{
    public class Movie : AggregateRoot
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public int DurationInMins { get; private set; }

        public string Language { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public string Country { get; private set; }

        public string Genre { get; private set; }

        public IList<Show> Shows { get; private set; }
    }
}

