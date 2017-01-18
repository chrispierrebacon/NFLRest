using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class Team
    {
        public Guid TeamId  { get; set; } = Guid.Empty;
        public string Prefix  { get; set; } = string.Empty;
        public string NickName  { get; set; } = string.Empty;
        public string City  { get; set; } = string.Empty;
        public string Conference  { get; set; } = string.Empty;
        public string Division  { get; set; } = string.Empty;
    }

    // By Division Alphabetically
    //public enum Team
    //{
    //    None = -1,
    //    // AFC East
    //    BuffaloBills = 0,
    //    MiamiDolphins = 1,
    //    NewEnglandPatriots = 2, // #Winning
    //    NewYorkJets = 3,

    //    // AFC North
    //    BaltimoreRavens = 4,
    //    CincinatiBengals = 5,
    //    ClevelandBrowns = 6,
    //    PittsburgSteelers = 7,

    //    // AFCSouth
    //    HoustonTexans = 8,
    //    IndianapolisColts = 9,
    //    JacksonvilleJaguars = 10,
    //    TennesseeTitains = 11,

    //    // AFCWest
    //    DenverBroncos = 12, // Denver sucks ass
    //    KansasCityChiefs = 13,
    //    OaklandRaiders = 14,
    //    SanDiegoChargers = 15, // San Diego for now I guess

    //    // NFCEast
    //    DallasCowboys = 16,
    //    NYGiants = 17,
    //    PhiladelphiaEagles = 18,
    //    WashingtonRedskins = 19, // Go Fuck Yourself. Also, YOU LIKE THAT!

    //    // NFCNorth
    //    ChicagoBears = 20,
    //    DetroitLions = 21,
    //    GreenBayPackers = 22,
    //    MinnesotaVikings = 23,

    //    // NFCSouth
    //    AtlantaFalcons = 24,
    //    CarolinaPanthers = 25,
    //    NewOrleansSaints = 26,
    //    TampaBayBuccaneers = 27,

    //    // NFCWest
    //    ArizonaCardinals = 28,
    //    LARams = 29, // LOL
    //    SanFrancisco49ers = 30,
    //    SeattleSeahawks = 31,

    //    // Legacy Teams
    //    StLouisRams = 32,

    //}
}
