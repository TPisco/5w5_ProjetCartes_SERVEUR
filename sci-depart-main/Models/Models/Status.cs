using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{



    public class Status
    {

        //Id des Status
        public const int POISONX_ID = 1;
        public const int STUNNEDX_ID = 2;
        public const int DAMAGE_DOWNX_ID = 3;


        public int Id { get; set; }

        //La value n'est pas dans le status lui-même
        //public int? Value { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }


        [ValidateNever]
        [JsonIgnore]
        public virtual List<CardStatus> cardStatus{ get; set; }



    }
}
