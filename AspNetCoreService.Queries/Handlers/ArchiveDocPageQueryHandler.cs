using System;
using System.Threading.Tasks;
using DemoCodes.AspNetCoreService.Models;
using DemoCodes.AspNetCoreService.Data.Infrastructure;
using DemoCodes.AspNetCoreService.Data.QueryObjects;
using DemoCodes.AspNetCoreService.Data.Dapper;
using System.Linq;

namespace DemoCodes.AspNetCoreService.Queries.Handlers
{
  public class ArchiveDocPageQueryHandler
    : IQueryHandler<ArchiveDocPageQuery, ArchiveDocumentPage>
  {
    private IConnectionFactory connectionFactory;
    private IQueryObjectBuilderFactory queryObjectBuilderFactory;

    public ArchiveDocPageQueryHandler(
      IConnectionFactory connectionFactory,
      IQueryObjectBuilderFactory queryObjectBuilderFactory)
    {
      this.connectionFactory = connectionFactory
        ?? throw new ArgumentNullException(nameof(connectionFactory));
      this.queryObjectBuilderFactory = queryObjectBuilderFactory
        ?? throw new ArgumentNullException(nameof(queryObjectBuilderFactory));
    }

    public async Task<ArchiveDocumentPage> HandleAsync(ArchiveDocPageQuery query)
    {
      using (var connection = connectionFactory.Create(Constants.ArchiveDbName))
      {
        ArchiveDocument[] docList =
          (await connection.QueryAsync<ArchiveDocument>(BuildQueryObject(query)))
          .ToArray();
        return new ArchiveDocumentPage(
          new PageInfo(query.PageNumber, docList.Length > (int)query.PageSize),
          docList.Take(docList.Length - 1));
      }
    }

    private QueryObject BuildQueryObject(ArchiveDocPageQuery query)
    {
      var builder = queryObjectBuilderFactory.Create<ISelectDocListPage>()
        .ForDeclarant(query.DeclarantId)
        .AtCustomsWhithType((ushort)query.FromCustomsType)
        .CreatedAfter(query.FromCreationDate ?? DateTime.MinValue.Date)
        .EndDateNotEarlier(MapEndDate(query.WhithExpired))
        .LastUsageNotEarlier(MapLastUsageDate(query.LastUsageDaysElapsed))
        .NewerDocsFirst(query.NewerFirst)
        .GetPage(query.PageNumber, query.PageSize + 1);
      return builder.Build();
    }

    private DateTime MapEndDate(bool whithExpired)
    {
      return whithExpired
        ? DateTime.Today.AddYears(-1 * Constants.MaxExpirationYears)
        : DateTime.Today.AddDays(-1 * Constants.MaxExpirationDays);
    }

    private DateTime MapLastUsageDate(uint? lastUsageDays)
    {
      return lastUsageDays == null
        ? DateTime.Today.AddYears(-1 * Constants.MaxLastUsageYears)
        : DateTime.Today.AddDays(-1 * (int)lastUsageDays);
    }
  }
}
