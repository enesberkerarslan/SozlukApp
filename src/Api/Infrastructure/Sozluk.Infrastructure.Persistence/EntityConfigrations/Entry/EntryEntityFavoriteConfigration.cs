﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sozluk.Api.Domain.Models;
using Sozluk.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Infrastructure.Persistence.EntityConfigrations.Entry;

public class EntryEntityFavoriteConfigration : BaseEntityConfigration<EntryFavorite>
{
    public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
    {
        base.Configure(builder);

        builder.ToTable("entryfavorite", SozlukContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.CreatedUser)
                      .WithMany(i => i.EntryFavorites)
                      .HasForeignKey(i => i.CreatedById);

        builder.HasOne(i => i.Entry)
                    .WithMany(i => i.EntryFavorites)
                    .HasForeignKey(i => i.EntryId)
                    .OnDelete(DeleteBehavior.Restrict);
    }

}
