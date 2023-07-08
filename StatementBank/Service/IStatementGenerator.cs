using StatementBank.Model;

namespace StatementBank.Service
{
    public interface IStatementGenerator
    {
        void GenerateStatement(Account account, DateTime? startDate = null, DateTime? endDate = null);
    }
}