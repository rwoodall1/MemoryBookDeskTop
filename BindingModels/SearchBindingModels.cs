using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{
    public class ReturnValues
    {
        public string Schcode { get; set; }
        public string OracleCode { get; set; }
        public int Invno { get; set; }
        public string ProdNo { get; set; }
        public string OrderId { get; set;}

    }
    //cust
    public class EmailSearch
    {
        public string Email { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }
    public class FirstNameSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }

    public class LastNameSearch
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }
    public class ZipCodeSearch
    {
        public string SchZip { get; set; }
        public string SchState { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
    }

    public class InvnoSearch
    {
        public int Invoice { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }

    }
  
    public class SchcodeSearch
    {
        public string Schcode { get; set; }
        public string Schname { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }
    public class JobNoSearch
    {
        public string JobNo { get; set; }
        public string Schcode { get; set; }
        public string Schname { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }
    public class SchnameSearch
    {
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }
    public class OracleCodeSearch
    {
        public string OracleCode { get; set; }
        public string Schcode { get; set; }
        public string Schname { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }
    public class ProdNoSearch
    {
        public string ProdNo { get; set; }
        public int Invoice { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string Contryear { get; set; }
    }
    //Sales
    public class SchcodeSalesSearch
    {
        public string Schcode { get; set; }
        public int Invoice { get; set; }
        public string ProdNo { get; set; }
        public string Schname { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }
    public class SchnameSalesSearch
    {
        public string Schname { get; set; }
        public int Invoice { get; set; }
        public string ProdNo { get; set; }
        public string Schcode { get; set; }
        public string OracleCode { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }
    public class OracleSalesSearch
    {
        public string OracleCode { get; set; }
        public string Schcode { get; set; }
        public string Schname { get; set; }
        public int Invoice { get; set; }
        public string ProdNo { get; set; }
        public string Contryear { get; set; }
        public string SchZip { get; set; }
        public string SchState { get; set; }
    }
    public class SalesJobCode
    {
        public string JobNo { get; set; }
        public string Schcode { get; set; }
        public string Schname { get; set; }
        public int Invoice { get; set; }
		public string ProdNo { get; set; }
		public string Contryear { get; set; }
        
    }
    //Produtn
    public class ProdutnSchcodeSearch
    {
        public string Schcode { get; set; }
        public string Schname { get; set; }
        public int Invoice { get; set; }
        public string ProdNo { get; set; }
       
        
    }
    public class ProdutnSchnameSearch
    {
        public string Schname { get; set; }   
        public string Schcode { get; set; }
        public int Invoice { get; set; }
        public string ProdNo { get; set; }
        public string Contryear { get; set; }

    }
    public class ProdutnOracleCodeSearch
    {
        public string OracleCode { get; set; }
        public string Schcode { get; set; }
        public string Schname { get; set; }
        public int Invoice { get; set; }
        public string ProdNo { get; set; }
        
    }
    public class ProdutnInvnoSearch
    {
        public int Invoice { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string OracleCode { get; set; }
        public string ProdNo { get; set; }
        public string Contryear { get; set; }
        
    }
    //EndSheet
    
 public class EndSheetSchcodeSearch
    {
        public string Schcode { get; set; }
        public string Schname { get; set; }
        public int Invoice { get; set; }
        public string ProdNo { get; set; }
        public string EndSheetNo { get; set; }
        public string Contryear { get; set; }
    }
    public class EndSheetSchNameSearch
    {
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public int Invoice { get; set; }
        public string ProdNo { get; set; }
        public string EndSheetNo { get; set; }
        public string Contryear { get; set; }
    }
    public class EndSheetOracleCodeSearch
    {
        public string OracleCode { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public int Invoice { get; set; }
        public string ProdNo { get; set; }
        public string EndSheetNo { get; set; }
        public string Contryear { get; set; }
    }
    public class EndSheetJobNoSearch
    {
        public string JobNo { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public int Invoice { get; set; }
        public string EndSheetNo { get; set; }
        public string Contryear { get; set; }
    }
    public class EndSheetInvnoSearch
    {
       public int Invoice { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string ProdNo { get; set; }
        public string EndSheetNo { get; set; }
        public string Contryear { get; set; }
    }
    //Bids
    public class BidsSchcodeSearch
    {
        public string Schcode { get; set; }
        public string Schname { get; set; }
        public string Contryear { get; set; }
        public int Id { get; set; }
        public string SchZip { get; set; }
        public string Schstate { get; set; }
    }
    public class BidsSchnameSearch
    {
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string Contryear { get; set; }
        public int Id {get; set;}
        public string SchZip { get; set; }
        public string Schstate { get; set; }


    }
    //Mixbooks
    public class MixBookOrderIdSearch
    {
       public int OrderId { get; set; }
        public string Job { get; set; }
        public string ShipName { get; set; }
                                             
    }
    public class MixBookOrderShipNameSearch
    {
        public string ShipName { get; set; }
        public int OrderId { get; set; }
        public string Job { get; set; }

    }
}