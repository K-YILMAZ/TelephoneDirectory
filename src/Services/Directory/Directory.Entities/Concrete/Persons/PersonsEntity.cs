using Directory.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Directory.Entities.Concrete.Persons
{ 
    public class PersonsEntity:IEntity {
        [Key]
        public Guid uuid { get; set; }
        [StringLength(20)]
        public string firstName { get; set; }
        [StringLength(50)]
        public string lastName { get; set; }
        [StringLength(100)]
        public string company { get; set; }
    }
}
