using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfManage.Setting
{
     [ProtoContract]
 public   class Setting
    {
        [ProtoMember(1)]
        public string DataSource { get; set; }
        [ProtoMember(2)]
        public string Instance { get; set; }
        [ProtoMember(3)]
        public string UserId { get; set; }
        [ProtoMember(4)]
        public string Password { get; set; }
        [ProtoMember(5)]
        public string InitialCatalog { get; set; }

    }
}
