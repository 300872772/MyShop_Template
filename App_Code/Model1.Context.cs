﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class ShopDBEntities4 : DbContext
{
    public ShopDBEntities4()
        : base("name=ShopDBEntities4")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Cart> Carts { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductTypes1> ProductTypes1 { get; set; }
    public virtual DbSet<UserInformation> UserInformations { get; set; }
}
