using Directory.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Directory.Entities.Concrete.Persons
{ 
    public class PersonsEntity:IEntity {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UUID { get; set; }
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Company { get; set; }
    }
}
