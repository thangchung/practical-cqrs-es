using System;
using Marten.Schema.Identity;
using N8T.Core.Helpers;

namespace N8T.Infrastructure.Marten
{
    public class MartenIdGenerator : IIdGenerator
    {
        public Guid New()
        {
            return CombGuidIdGeneration.NewGuid();
        }
    }
}
