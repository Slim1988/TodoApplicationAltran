//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AltranApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public User()
        {
            this.Todo = new HashSet<Todo>();
        }
    
        public int UserId { get; set; }
        //[Required(ErrorMessage = "User name is required!!")]
        [DisplayName("User")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Password is required!!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    
        public virtual ICollection<Todo> Todo { get; set; }
    }
}
