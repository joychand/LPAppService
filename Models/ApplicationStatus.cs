using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSiroi.Resource.Models
{
    public class ApplicationStatus
    {
        public int tsno { get; set; }
        public int tsyear { get; set; }
        public string Ackno { get; set; }
        public string status { get; set; }
        public string sro { get; set; }
        public string remarks { get; set; }
    }
    public class ApplicationUploadModel
    {
        public int tsno { get; set; }
        public int tsyear { get; set; }
        public string sro { get; set; }
        public string filePath { get; set; }
    }
}