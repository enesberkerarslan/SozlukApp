﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sozluk.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Infrastructure.Persistence.EntityConfigrations.Entry;

public class EntryEntityConfigration :BaseEntityConfigration<Api.Domain.Models.Entry>
{

    public override void Configure(EntityTypeBuilder<Api.Domain.Models.Entry> builder)
    {
        base.Configure(builder);

        builder.ToTable("entry", SozlukContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.CreatedBy)
                      .WithMany(i => i.Entries)
                      .HasForeignKey(i => i.CreatedById)
                      .OnDelete(DeleteBehavior.Restrict);


    }
}
