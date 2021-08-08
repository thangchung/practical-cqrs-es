using System;
using N8T.Core.Domain;

namespace MovieShow.Domain
{
    public class Show : AggregateRoot
    {
        public DateOnly CreatedOn { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }
    }
}


