//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NFLCommon
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fumble
    {
        public int Id { get; set; }
        public System.Guid FumblesId { get; set; }
        public System.Guid GameId { get; set; }
        public System.Guid PlayerId { get; set; }
        public int Total { get; set; }
        public int Recovered { get; set; }
        public int TeamRecovered { get; set; }
        public int Yards { get; set; }
        public int Lost { get; set; }
        public string GsisId { get; set; }
    
        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}