using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper
{
    public class MirResult
    {
        public MirResult() { }
        public MirResult(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Success { get { return Code == 0; } }
    }
    public class ActionResult<T>
    {
        public ActionResult() { }
        public ActionResult(T data)
        {
            this.Code = 0;
            this.Data = data;
        }
        public ActionResult(int code,string message)
        {
            this.Code = code;
            this.Message = message;
        }
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Success { get { return Code == 0; } }
    }
}
