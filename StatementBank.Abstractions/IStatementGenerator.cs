using StatementBank.Models;

namespace StatementBank.Abstractions
{
    public interface IStatementGenerator
    {
        void GenerateStatement(Account account, DateTime? startDate = null, DateTime? endDate = null);
    }
}