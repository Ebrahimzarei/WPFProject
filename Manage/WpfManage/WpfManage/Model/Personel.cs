using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfManage.Model
{
   public  class Personel
    {
        //مشخصات پرسنل
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NCode { get; set; }
        public string NameFather { get; set; }
        public string PersonelNumber { get; set; }
        public string Tellephone { get; set; }
        public string Address { get; set; }
        public string RfidCard { get; set; }
        public string Image { get; set; }
    }
}
