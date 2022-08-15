using System.Data;
using Dapper;

namespace Backend.DataAccessLibrary.Repositories;

public static class CustomSqlMapperExtensions
{
    public static IEnumerable<TEntity> GetAllByContidion<TEntity>(this IDbConnection connection, string condition, IDbTransaction transaction = null, int? commandTimeout = null) where TEntity : class
    {
        var sql = $"select * from OrderPositions where {condition}";
        var entities = connection.Query<TEntity>(sql, param: null, transaction, commandTimeout: null);
        return entities;
    }
}


