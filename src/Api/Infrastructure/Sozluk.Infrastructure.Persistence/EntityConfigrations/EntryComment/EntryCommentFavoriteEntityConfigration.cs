using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sozluk.Api.Domain.Models;
using Sozluk.Infrastructure.Persistence.Context;
using Sozluk.Infrastructure.Persistence.EntityConfigrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Infrastructure.Persistence.EntityConfigrations.EntryComment;

public class EntryCommentFavoriteEntityConfigration : BaseEntityConfigration<EntryCommentFavorite>
{

    public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
    {
        base.Configure(builder);

        builder.ToTable("entrycommentfavorite", SozlukContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.EntryComment)
             .WithMany(i => i.EntryCommentFavorites)
             .HasForeignKey(i => i.EntryCommentId);

        builder.HasOne(i => i.CreatedUser)
             .WithMany(i => i.EntryCommentFavorites)
             .HasForeignKey(i => i.CreatedById)
             .OnDelete(DeleteBehavior.Restrict);



    }
}
