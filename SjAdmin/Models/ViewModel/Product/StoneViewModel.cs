using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SjAdmin.Models.ViewModel.Product
{
    [Serializable]
   // [DataContract]
    public class StoneViewModel
    {
     //   [DataMember]
        public int StoneId { get; set; }
        public string StoneName { get; set; }

        public bool? IsActive { get; set; }
    }
}