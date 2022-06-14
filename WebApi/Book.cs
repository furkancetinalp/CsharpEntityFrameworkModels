using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi{
    public class Book{
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {set;get;}
        public string Title {set;get;}

        public int GenreId {set;get;}

        public int PageCount {get;set;}
        public DateTime PublishDate {get;set;}
    }

}
