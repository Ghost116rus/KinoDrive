﻿using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Persistance.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);

            builder.Property(u => u.Role).HasMaxLength(13);
            builder.Property(u => u.LastName).HasMaxLength(150);
            builder.Property(u => u.FirstName).HasMaxLength(150);
            builder.Property(u => u.NickName).HasMaxLength(150);
            builder.Property(u => u.Email).HasMaxLength(150);
            builder.Property(u => u.Password).HasMaxLength(150);

            builder
                .HasOne(user => user.WorkOffice)
                .WithMany(branchOffice => branchOffice.Managers)
                .HasForeignKey(user => user.BranchOfficeId);

        }
    }
}
