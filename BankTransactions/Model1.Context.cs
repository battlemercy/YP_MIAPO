﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankTransactions
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gr691_msiEntities : DbContext
    {
        public gr691_msiEntities()
            : base("name=gr691_msiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<Paymaster> Paymaster { get; set; }
        public virtual DbSet<Role> Role { get; set; }
    }
}
