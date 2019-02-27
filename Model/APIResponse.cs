using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class APIResponse
    {
        public object DATA { get; set; }

        public List<ERRORS> ERROR { get; set; }

        public ResponseStatus STATUS { get; set; }
    }


    public class ERRORS
    {
        public string CODE { get; set; }

        public string MESSAGE { get; set; }

        public string DESCIPTION { get; set; }
    }

    public enum ResponseStatus
    {
        SUCCESS = 1,
        FAIL = 0
    }
}