using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EscapeOfKinokoForest.Models
{
    [DataContract(Name="ResultData")]
    class ResultData
    {
        [DataMember(Name="name")]
        public string name;

        [DataMember(Name = "span")]
        public TimeSpan span;
    }
}
