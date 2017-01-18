using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class Player
    {
        public Guid Id  { get; set; } = Guid.Empty;
        public string FirstName  { get; set; } = string.Empty;
        public string LastName  { get; set; } = string.Empty;
        public Position Position  { get; set; } = Position.NONE;
        public DateTime Birthdate  { get; set; } = new DateTime(1753, 1, 1);
        public string College  { get; set; } = string.Empty;
        public string Fullname  { get; set; } = string.Empty;
        public string GsisId  { get; set; } = string.Empty;
        public string GsisName  { get; set; } = string.Empty;
        public int Height  { get; set; } = 0;
        public int Number  { get; set; } = 0;
        public int ProfileId  { get; set; } = 0;
        public string ProfileUrl  { get; set; } = string.Empty;
        public Status Status  { get; set; } = Status.RET;
        public int Weight  { get; set; } = 0;
        public int YearsPro  { get; set; } = 0;
        public string Team  { get; set; } = string.Empty;
    }
}
