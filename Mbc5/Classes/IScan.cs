using BindingModels;

namespace Mbc5.Classes
{
    public interface IScan
    {
        //public void Scan(string _barcode, string _deptCode, string _custId , string _datetime, string _trackingNumber = "", bool _remake = false, bool _prntToLabeler = false, int _reasoncode = 0, int _remakeQty = 0);
        public void Scan(ScanData data);
        public void ScanRemake();
        public void AddMbEventLog(string jobId, string status, string note, string notificationXML, bool notified);
        public bool ScanCheck(int invno, string login, string type);
        public bool WipCheck(string vDeptCode);
        public bool WipCheck(string vDeptCode, string type);

    }
}
