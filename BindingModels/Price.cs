using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingModels
{
    public class Price
    {
        public int Copies { get; set; }
        public string Yr { get; set; }
        public string Type { get; set; }
        public Decimal Pg12 { get; set; }
        public Decimal Pg16 { get; set; }
        public Decimal Pg20 { get; set; }
        public Decimal Pg24 { get; set; }
        public Decimal Pg28 { get; set; }
        public Decimal Pg32 { get; set; }
        public Decimal Pg36 { get; set; }
        public Decimal Pg40 { get; set; }
        public Decimal Pg44 { get; set; }
        public Decimal Pg48 { get; set; }
        public Decimal Pg52 { get; set; }
        public Decimal Pg56 { get; set; }
        public Decimal Pg60 { get; set; }
        public Decimal Pg64 { get; set; }
        public Decimal Pg68 { get; set; }
        public Decimal Pg72 { get; set; }
        public Decimal Pg76 { get; set; }
        public Decimal Pg80 { get; set; }
        public Decimal Pg84 { get; set; }
        public Decimal Pg88 { get; set; }
        public Decimal Pg92 { get; set; }
        public Decimal Pg96 { get; set; }
        public Decimal Pg100 { get; set; }
        public Decimal Pg104 { get; set; }
        public Decimal Pg108 { get; set; }
        public Decimal Pg112 { get; set; }
        public Decimal Pg116 { get; set; }
        public Decimal Pg120 { get; set; }
        public Decimal Pg124 { get; set; }
        public Decimal Pg128 { get; set; }
        public Decimal Pg132 { get; set; }
        public Decimal Pg136 { get; set; }
        public Decimal Pg140 { get; set; }
        public Decimal Pg144 { get; set; }
        public Decimal Pg148 { get; set; }
        public Decimal Pg152 { get; set; }
        public Decimal Pg156 { get; set; }
        public Decimal Pg160 { get; set; }
        public Decimal Pg164 { get; set; }
        public Decimal Pg168 { get; set; }
        public Decimal Pg172 { get; set; }
        public Decimal Pg176 { get; set; }
        public Decimal Pg180 { get; set; }
        public Decimal Pg184 { get; set; }
        public Decimal Pg188 { get; set; }
        public Decimal Pg192 { get; set; }
        public Decimal Pg196 { get; set; }
        public Decimal Pg200 { get; set; }
        public Decimal Pg204 { get; set; }
        public Decimal Pg208 { get; set; }
        public Decimal Pg212 { get; set; }
        public Decimal Pg216 { get; set; }
        public Decimal Pg220 { get; set; }
        public Decimal Pg224 { get; set; }
        public Decimal Pg228 { get; set; }
        public Decimal Pg232 { get; set; }
        public Decimal Pg236 { get; set; }
        public Decimal Pg240 { get; set; }
        public Decimal Pg244 { get; set; }
        public Decimal Pg248 { get; set; }
        public Decimal Pg252 { get; set; }
        public Decimal Pg256 { get; set; }
        public Decimal Pg260 { get; set; }
        public Decimal Pg264 { get; set; }
        public Decimal Pg268 { get; set; }
        public Decimal Pg272 { get; set; }
        public Decimal Pg276 { get; set; }
        public Decimal Pg280 { get; set; }
        public Decimal Pg284 { get; set; }
        public Decimal Pg288 { get; set; }
        public Decimal Pg292 { get; set; }
        public Decimal Pg296 { get; set; }
        public Decimal Pg300 { get; set; }
        public Decimal Pg304 { get; set; }
        public Decimal Pg308 { get; set; }
        public Decimal Pg312 { get; set; }
        public Decimal Pg316 { get; set; }
        public Decimal Pg320 { get; set; }
        public Decimal Pg324 { get; set; }
        public Decimal Pg328 { get; set; }
        public Decimal Pg332 { get; set; }
        public Decimal Pg336 { get; set; }
        public Decimal Pg340 { get; set; }
        public Decimal Pg344 { get; set; }
        public Decimal Pg348 { get; set; }
        public Decimal Pg352 { get; set; }
        public Decimal Pg356 { get; set; }
        public Decimal Pg360 { get; set; }


    }
    public class MeridianPrice
    {
        public int Id { get; set; }
        public string Yr { get; set; }
        public string Type { get; set; }
        public decimal Q2000 { get; set; }
        public decimal Q1000 { get; set; }
        public decimal Q800 { get; set; }
        public decimal Q600 { get; set; }
        public decimal Q400 { get; set; }
        public decimal Q300 { get; set; }
        public decimal Q250 { get; set; }
        public decimal Q200 { get; set; }
        public decimal Q100 { get; set; }
        public decimal Generic { get; set; }
        public decimal GenericCL { get; set; }
        public decimal GenericM { get; set; }
        public decimal Jostens { get; set; }
        public decimal StandardPageCost { get; set; }
        public decimal EightPageCost { get; set; }
        public decimal FourPageCost { get; set; }
        public decimal ZeroPageCost { get; set; }


    }
    public class MeridianOptionPricing
    {
        public int Id { get; set; }
        public string Yr { get; set; }
        public decimal HallPassLF { get; set; }
        public decimal HallPassSF { get; set; }
        public decimal BkMrk { get; set; }
        public decimal VpLF { get; set; }
        public decimal VpSF { get; set; }
        public decimal IdPouch { get; set; }
        public decimal TitlePgSF { get; set; }
        public decimal TitlePgLF { get; set; }
        public decimal DuraGlazeLF { get; set; }
        public decimal DuraGlazeSF { get; set; }
        public decimal WallChart { get; set; }
        public decimal TeachersEdtSF { get; set; }
        public decimal TeachersEdtLF { get; set; }
        public decimal TypeSet { get; set; }
        public decimal ImpGuide { get; set; }
        public decimal JostensFourClr { get; set; }
        public decimal FourClr { get; set; }
        public decimal ThreeClr { get; set; }
        public decimal TwoClr { get; set; }
        public decimal OneClr { get; set; }
        public decimal SpecialCoverPrice1 { get; set; }
        public decimal SpecialCoverPrice2 { get; set; }
        public decimal SpecialCoverPrice3 { get; set; }
        public decimal CharacterResourceLF { get; set; }
        public decimal CharacterResourceSF { get; set; }

    }
    public class JostenPricing
    {
        public int Id { get; set; }
        public string Yr { get; set; }
        public decimal LF0 { get; set; }
        public decimal LF2 { get; set; }
        public decimal LF4 { get; set; }
        public decimal LF6 { get; set; }
        public decimal LF8 { get; set; }
        public decimal LF10 { get; set; }
        public decimal LF12 { get; set; }
        public decimal LF14 { get; set; }
        public decimal LF16 { get; set; }
        public decimal LF18 { get; set; }
        public decimal LF20 { get; set; }
        public decimal LF24 { get; set; }
        public decimal LF26 { get; set; }
        public decimal LF28 { get; set; }
        public decimal LF30 { get; set; }
        public decimal LF32 { get; set; }
        public decimal LF34 { get; set; }
        public decimal LF36 { get; set; }
        public decimal LF38 { get; set; }
        public decimal LF40 { get; set; }
        public decimal LF42 { get; set; }
        public decimal LF44 { get; set; }
        public decimal LF46 { get; set; }
        public decimal LF48 { get; set; }
        public decimal LF50 { get; set; }
        public decimal LF52 { get; set; }
        public decimal LF54 { get; set; }
        public decimal LF56 { get; set; }
        public decimal LF58 { get; set; }
        public decimal LF60 { get; set; }
        public decimal LF62 { get; set; }
        public decimal LF64 { get; set; }
        public decimal LF68 { get; set; }
        public decimal LF70 { get; set; }
        public decimal LF72 { get; set; }
        public decimal LF74 { get; set; }
        public decimal SF0 { get; set; }
        public decimal SF2 { get; set; }
        public decimal SF4 { get; set; }
        public decimal SF6 { get; set; }
        public decimal SF8 { get; set; }
        public decimal SF10 { get; set; }
        public decimal SF12 { get; set; }
        public decimal SF14 { get; set; }
        public decimal SF16 { get; set; }
        public decimal SF18 { get; set; }
        public decimal SF20 { get; set; }
        public decimal SF24 { get; set; }
        public decimal SF26 { get; set; }
        public decimal SF28 { get; set; }
        public decimal SF30 { get; set; }
        public decimal SF32 { get; set; }
        public decimal SF34 { get; set; }
        public decimal SF36 { get; set; }
        public decimal SF38 { get; set; }
        public decimal SF40 { get; set; }
        public decimal SF42 { get; set; }
        public decimal SF44 { get; set; }
        public decimal SF46 { get; set; }
        public decimal SF48 { get; set; }
        public decimal SF50 { get; set; }
        public decimal SF52 { get; set; }
        public decimal SF54 { get; set; }
        public decimal SF56 { get; set; }
        public decimal SF58 { get; set; }
        public decimal SF60 { get; set; }
        public decimal SF62 { get; set; }
        public decimal SF64 { get; set; }
        public decimal SF68 { get; set; }
        public decimal SF70 { get; set; }
        public decimal SF72 { get; set; }
        public decimal SF74 { get; set; }
        public decimal SF78 { get; set; }
        public decimal SF80 { get; set; }
        public decimal SF82 { get; set; }
        public decimal SF84 { get; set; }
        public decimal SF86 { get; set; }
        public decimal SF88 { get; set; }
        public decimal SF90 { get; set; }
        public decimal SF92 { get; set; }
        public decimal SF94 { get; set; }
        public decimal SF96 { get; set; }
        public decimal SF98 { get; set; }
        public decimal SF100 { get; set; }
        public decimal SF102 { get; set; }
        public decimal SF104 { get; set; }
        public decimal SF106 { get; set; }
        public decimal SF108 { get; set; }
        public decimal SF110 { get; set; }
        public decimal SF112 { get; set; }
        public decimal SF114 { get; set; }
        public decimal SF116 { get; set; }
        public decimal SF118 { get; set; }
        public decimal SF120 { get; set; }
        public decimal SF122 { get; set; }
        public decimal SF124 { get; set; }
        public decimal SF126 { get; set; }
        public decimal SF128 { get; set; }
        public decimal SF130 { get; set; }
        public decimal SF132 { get; set; }
        public decimal SF134 { get; set; }
        public decimal SF136 { get; set; }
        public decimal SF138 { get; set; }
        public decimal SF140 { get; set; }
        public decimal SF142 { get; set; }
        public decimal SF144 { get; set; }
        public decimal SF146 { get; set; }
        public decimal SF148 { get; set; }
        public decimal SF150 { get; set; }
        public decimal SF152 { get; set; }

    }
}
