using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuestionDbContextDapper dbContextDapper;

        public QuestionRepository(QuestionDbContextDapper dbContextDapper)
        {
            this.dbContextDapper=dbContextDapper;
        }
        /*Todo: obtener el userCreatorId del token de autenticacion*/
        public async Task<Guid> CreateAsync(Question entity, CancellationToken cancellationToken = default)
        {
            var task = await Task.Run(async () =>
            {
                string sql = @"INSERT INTO dbo.Question (UserCreatorId, CreationTime, State, Description, RowOrder, Tags) 
                                OUTPUT inserted.Id
                                VALUES (@UserCreatorId, @CreationTime, @State, @Description, @RowOrder, @Tags);";
                using var con = dbContextDapper.CreateConnection();
                var result = await con.ExecuteScalarAsync<Guid>(sql, 
                    new {@UserCreatorId = Guid.NewGuid(), @CreationTime = DateTime.UtcNow, @State = true, 
                        @Description = entity.Description, @RowOrder = entity.RowOrder, @Tags = entity.Tags});
                return result;
            }, cancellationToken);
            return task;
        }

        public async Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var task = await Task.Run(async () =>
            {
                string sql = @"UPDATE dbo.Question SET State = 0 WHERE Id = @QuestionId";
                using var con = dbContextDapper.CreateConnection();
                var result = await con.ExecuteAsync(sql, new { @QuestionId = Id });
                return result > 0;
            }, cancellationToken);
            return task;
        }
        //Todo: crear un DTO para mostrar los
        public async Task<IEnumerable<Question>> GetAllAsync(object? param = null, CancellationToken cancellationToken = default)
        {
            var task = await Task.Run(async () =>
            {
                string query = "SELECT TOP 300 Id, UserCreatorId, CreationTime, State, Description, RowOrder, Tags FROM Question WHERE State = @IsActive ORDER BY CreationTime DESC;";
                using var con = dbContextDapper.CreateConnection();
                var result = await con.QueryAsync<Question>(query, param);
                return result;
            }, cancellationToken);

            return task;
        }

        public async Task<Question> GetEntityByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var task = await Task.Run(async () =>
            {
                string query = "SELECT Id, UserCreatorId, CreationTime, State, Description, RowOrder, Tags FROM Question WHERE Id = @QuestionId;";
                using var con = dbContextDapper.CreateConnection();
                var result = await con.QueryFirstOrDefaultAsync<Question>(query, new { @QuestionId = Id });
                return result;
            }, cancellationToken);

            return task;

            //var id = new Question();
            //return Task.FromResult(id);
        }

        public async Task<bool> UpdateAsync(Question entity, Guid Id, CancellationToken cancellationToken = default)
        {
            var task = await Task.Run(async () =>
            {
                string sql = @"UPDATE dbo.Question SET Description = @Description, RowOrder = @RowOrder, Tags = @Tags WHERE Id = @QuestionId";
                using var con = dbContextDapper.CreateConnection();
                var result = await con.ExecuteAsync(sql, new
                {
                    @QuestionId = Id,
                    entity.Description,
                    entity.RowOrder,
                    entity.Tags
                });
                return result > 0;
            }, cancellationToken);
            return task;
        }
    }
}
