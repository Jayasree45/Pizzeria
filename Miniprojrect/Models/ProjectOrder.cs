
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
    
public partial class ProjectOrder
{

    public int OrderId { get; set; }

    public string OrderStatus { get; set; }

    public Nullable<decimal> TotalPrice { get; set; }

    public Nullable<System.DateTime> DeliveryDateTime { get; set; }

    public Nullable<int> UserId { get; set; }

    public Nullable<int> PizzaID { get; set; }



    public virtual ProjectPizza ProjectPizza { get; set; }

    public virtual ProjectUser ProjectUser { get; set; }

}

}
