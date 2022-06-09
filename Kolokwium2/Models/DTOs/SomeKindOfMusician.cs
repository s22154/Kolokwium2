using System.Collections;
using System.Collections.Generic;

namespace Kolokwium2.Models.DTOs
{
    public class SomeKindOfMusician
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Nickname { get; set; }
        public IEnumerable<SomeKindOfTrack> Tracks { get; set; }
    }
}