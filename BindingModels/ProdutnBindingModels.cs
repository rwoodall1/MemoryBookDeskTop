using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{
	public class ProdutnSchoolNameSearchModel
	{
		public string Schcode { get; set; }
		public string Schname { get; set; }
		public string Schzip { get; set; }
		public string Schcity { get; set; }
		public string Schstate { get; set; }
		public int Invno { get; set; }
		public string ProdNo { get; set; }
	}
	public class ReceivingCard {
		public string Schcode { get; set; }
		public string Schname { get; set; }
		public string SchEmail { get; set; }
		public string ContEmail { get; set; }
		public string ContFname { get; set; }
		public string ContLname { get; set; }
		public string BContEmail { get; set; }
		public string BContFname { get; set; }
		public string BContLname { get; set; }
		public string Insck { get; set; }
		public int NoCopies { get; set; }
		public int NoPages { get; set; }
		public bool Story { get; set; }
		public bool Supplements { get; set; }
		public bool Peyn { get; set; }
		public bool MLamination { get; set; }
		public bool OurSupp { get; set; }
		public bool Layn { get; set; }
		public bool YirSchool { get; set; }
		public bool SdlStich { get; set; }
		public int TotalSoldOnline { get; set; }
		public decimal TotalDollarsOnline { get; set; }
		public bool HardBack { get; set; }
		public bool CaseBind { get; set; }
		public int FreeBooks { get; set; }
		public bool Foilck { get; set; }
		public bool Spirck { get; set; }
		public bool AllClrck { get; set; }
		public bool Persnlz { get; set; }
		public string ProdNo { get; set; }
		public int Invno { get; set; }
		public bool KitRecvd { get; set; }
		public string CoverType { get; set; }
		public string CoverDesc { get; set; }
		public string Dedayin { get; set; }
		public string Dcdesc1 { get; set; }
		public string DcDesc2 { get; set; }
		public bool Foiling { get; set; }
		public bool Indivpic { get; set; }
		public bool Mk { get; set; }
		public bool Diecut { get; set; }
		public bool Perfbind { get; set; }
		public string Guardte { get; set; }
		public string EstDate { get; set; }

		public string FrontCvr { get; set; }
		public string FrontCvr2 { get; set; }
		public string FrontCvrIn { get; set; }
		public string BackCvrIn { get; set; }
		public string Back { get; set; }
		public string Name { get; set; }
		public string Attn { get; set; }
		public string Add1 { get; set; }
		public string Add2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public decimal Payment { get; set; }
	}
}