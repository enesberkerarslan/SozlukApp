using Sozluk.Api.Domain.Models;
using Sozluk.Api.Infrastructure.Persistence.Repositories;
using Sozluk.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Infrastructure.Persistence.Repositories;

public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
{
    public EntryCommentRepository(SozlukContext dbContext) : base(dbContext)
    {
    }
}