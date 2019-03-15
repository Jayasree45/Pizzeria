
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Miniprojrect.Models
{

    using System;
    using System.Collections.Generic;

    public partial class ProjectPizza
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectPizza()
        {

            this.ProjectCategories = new HashSet<ProjectCategory>();

            this.ProjectOrders = new HashSet<ProjectOrder>();

        }


        public int PizzaID { get; set; }

        public string PName { get; set; }

        public string ImageURL { get; set; }

        public string Category { get; set; }

        public Nullable<decimal> Price { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<ProjectCategory> ProjectCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<ProjectOrder> ProjectOrders { get; set; }

    }



    public class jk
    {

        public string input { get; set; }
        public string name { get; set; }

    }

}
