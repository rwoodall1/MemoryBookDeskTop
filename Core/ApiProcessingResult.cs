using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Core {
    
    public class ApiProcessingResult {
      public  ApiProcessingResult() { }
        public bool CallFailed { get; set; } = false;
        public bool IsError { get; set; } = false;
        public List<ApiProcessingError> Errors { get; set; } = new List<ApiProcessingError>();
        public string Tag { get; set; }
    }

    public class ApiProcessingResult<TReturnedData> : ApiProcessingResult {
        public ApiProcessingResult() { }
        public TReturnedData Data { get; set; }
    }

 
}
