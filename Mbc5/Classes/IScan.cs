using BindingModels;

namespace Mbc5.Classes
{
    public interface IScan
    {
        //public void Scan(string _barcode, string _deptCode, string _custId , string _datetime, string _trackingNumber = "", bool _remake = false, bool _prntToLabeler = false, int _reasoncode = 0, int _remakeQty = 0);
        bool Scan(ScanData data);
        bool ScanRemake();
        void AddMbEventLog(string jobId, string status, string note, string notificationXML, bool notified);
        bool ScanCheck(int invno, string login, string type);
        bool WipCheck(string vDeptCode);
        bool WipCheck(string vDeptCode, string type);

    }
}
