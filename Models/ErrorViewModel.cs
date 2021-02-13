using System;
using E_LinealesCS;

namespace Lab1_ED1__backup_.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        E_LinealesCS.ListCS<int> list = new E_LinealesCS.ListCS<int>();
        list.Add(1)
    }
}
