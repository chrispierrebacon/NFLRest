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
    
    public partial class PuntingStat
    {
        public int Id { get; set; }
        public System.Guid PuntingStatsId { get; set; }
        public System.Guid GameId { get; set; }
        public System.Guid PlayerId { get; set; }
        public int Punts { get; set; }
        public int Yards { get; set; }
        public int Average { get; set; }
        public int InsideTwenty { get; set; }
        public int Long { get; set; }
        public string GsisId { get; set; }
    
        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
