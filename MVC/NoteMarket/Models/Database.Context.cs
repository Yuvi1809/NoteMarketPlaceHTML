﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NoteMarket.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class projectEntities1 : DbContext
    {
        public projectEntities1()
            : base("name=projectEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<MembersData> MembersDatas { get; set; }
        public virtual DbSet<NoteDetail> NoteDetails { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<ManageAdmin> ManageAdmins { get; set; }
    }
}