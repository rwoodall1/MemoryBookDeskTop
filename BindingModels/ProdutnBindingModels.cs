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
    public class SpecialCoverDats
    {
        public int l_recv { set; get;}
        public int l_toprod { get; set;}
        public int l_wdr1 { get; set; }
        public int l_wdr2 { get; set; }
        public int l_wdr3 { get; set; }
        public int l_wdr4 { get; set; }
        public int l_wdr5 { get; set; }
        public int l_wdr6 { get; set; }
        public int l_wdr7 { get; set; }
        public int l_wdr8 { get; set; }
        public int l_wdr9 { get; set; }
        public int l_wdr10 { get; set; }
        public int l_wdr11 { get; set; }
        public int l_wdr12 { get; set; }
        public int l_wdr13 { get; set; }
        public int l_wdr14 { get; set; }
        public int l_wdr15 { get; set; }
        public int l_wdr16 { get; set; }
        public int l_wdr17 { get; set; }
        public int l_wdr18 { get; set; }
        public int l_wdr19 { get; set; }
        public int l_wdr20 { get; set; }
        public int l_wdr21 { get; set; }
        public int l_wdr22 { get; set; }
        public int l_wdr23 { get; set; }
        public int l_wdr24 { get; set; }
        public int l_wdr25 { get; set; }
        public int l_wdr26 { get; set; }
        public int l_wdr27 { get; set; }
        public int l_wdr28 { get; set; }
        public int l_wdr29 { get; set; }
        public int l_wdr30 { get; set; }
        public int l_wdr31 { get; set; }
        public int l_wdr32 { get; set; }
        public int l_wdr33 { get; set; }
        public int l_wdr34 { get; set; }
        public int l_wdr35 { get; set; }
        public int l_wdr36 { get; set; }
        public int l_wdr37 { get; set; }
        public int l_wdr38 { get; set; }
        public int l_wdr39 { get; set; }
        public int l_wdr40 { get; set; }
        public int l_wdr41 { get; set; }
        public int l_wdr42 { get; set; }
        public int l_wdr43 { get; set; }
        public int l_wdr44 { get; set; }
        public int l_wdr45 { get; set; }
        public int l_wdr46 { get; set; }
        public int l_wdr47 { get; set; }
        public int l_wdr48 { get; set; }
        public int l_wdr49 { get; set; }
        public int l_wdr50 { get; set; }
    }
    public class SpecialCoverTicket
    {
        public string BarCode { get; set; }
        public string Schcode { get; set; }
        public string PrtVend { get; set; }
        public string Prodno { get; set; }
        public int Invno { get; set; }
        public string Schname { get; set; }
        public string CvrStock { get; set; }
        public string Bind { get; set; }
        public string ContrYear { get; set; }
        public string Colors { get; set; }
        public string Clr1 { get; set; }
        public string Clr2 { get; set; }
        public string Clr3 { get; set; }
        public string Clr4 { get; set; }
        public string SpecCover { get; set; }
        public string ScRecv { get; set; }
        public int ReqstdCpy { get; set; }
        public int NoPages { get; set; }
        public string Desc { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }
        public string Desc4 { get; set; }
        public string CoverDesc { get; set; }
        public bool Scname { get; set; }
        public bool Yr { get; set; }
        public bool IndivName { get; set; }
        public bool Icon { get; set; }
        public bool MK { get; set; }
        public string SchoolColors { get; set; }//cust
        public bool TypeSet { get; set; }
        public bool IndivPic { get; set; }
        public bool Emailed { get; set; }
        public bool Foiling { get; set; }
        public string FoilClr { get; set; }
        public string Mascot { get; set; }
        public int NumToPerso { get; set; }
        public string Front { get; set; }
        public string Spine { get; set; }
        public bool CustSubmtx { get; set; }//covers
        public string SpecInst { get; set; }
        public string Laminated { get; set; }


    }
    public class BinderyLabel
    {
        public string Schname { get; set; }
        public string BarCode { get; set; }
        public string JobNo { get; set; }
        public string Binding { get; set; }
        public int Quantity { get; set; }
        public int LabelTotal { get; set; }
        public int CurrentLabel { get; set; }
    
    }
    public class PtbDat
    {
        public string BookType { set; get; }
        public int LdateToProd { get; set; }
        public int LWdr_1 { get; set; }
        public int LWdr_2 { get; set; }
        public int LWdr_3 { get; set; }
        public int LWdr_4 { get; set; }
        public int LWdr_5 { get; set; }
        public int LWdr_6 { get; set; }
        public int LWdr_7 { get; set; }
        public int LWdr_8 { get; set; }
        public int LWdr_9 { get; set; }
        public int LWdr_10 { get; set; }
        public int LWdr_11 { get; set; }
        public int LWdr_12 { get; set; }
        public int LWdr_13 { get; set; }
        public int LWdr_14 { get; set; }
        public int LWdr_15 { get; set; }
        public int LWdr_16 { get; set; }
        public int LWdr_17 { get; set; }
        public int LWdr_18 { get; set; }
        public int LWdr_19 { get; set; }
        public int LWdr_20 { get; set; }
        public int LWdr_21 { get; set; }
        public int LWdr_22 { get; set; }
        public int LWdr_23 { get; set; }
        public int LWdr_24 { get; set; }
        public int LWdr_25 { get; set; }
        public int LWdr_26 { get; set; }
        public int LWdr_27 { get; set; }
        public int LWdr_28 { get; set; }
        public int LWdr_29 { get; set; }
        public int LWdr_30 { get; set; }
        public int LWdr_31 { get; set; }
        public int LWdr_32 { get; set; }
        public int LWdr_33 { get; set; }
        public int LWdr_34 { get; set; }
        public int LWdr_35 { get; set; }
        public int LWdr_36 { get; set; }
        public int LWdr_37 { get; set; }
        public int LWdr_38 { get; set; }
        public int LWdr_39 { get; set; }
        public int LWdr_40 { get; set; }
        public int LWdr_41 { get; set; }
        public int LWdr_42 { get; set; }
        public int LWdr_43 { get; set; }
        public int LWdr_44 { get; set; }
        public int LWdr_45 { get; set; }
        public int LWdr_46 { get; set; }
        public int LWdr_47 { get; set; }
        public int LWdr_48 { get; set; }
        public int LWdr_49 { get; set; }
        public int LWdr_50 { get; set; }
    }
}