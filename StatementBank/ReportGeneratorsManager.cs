using StatementBank.Abstractions;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace StatementBank
{
    public class ReportGeneratorsManager
    {
        private readonly CompositionContainer? _container;
        [ImportMany]
        private List<Lazy<IStatementGenerator, IStatementGeneratorMetaData>> _statementGenerators = new();
        public IReadOnlyCollection<Lazy<IStatementGenerator, IStatementGeneratorMetaData>> StatementGenerators { get => _statementGenerators.AsReadOnly(); }

        public ReportGeneratorsManager()
        {
            try
            {
                var catalog = new AggregateCatalog();
                var path = ".\\..\\..\\..\\Extensions";
                if (!Directory.Exists(path))
                {
                    path = ".\\Extensions";
                }
                catalog.Catalogs.Add(new DirectoryCatalog(path));

                _container = new CompositionContainer(catalog);
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
        public IStatementGenerator GetGeneratorOfType(string userInput)
        {
            foreach (Lazy<IStatementGenerator, IStatementGeneratorMetaData> generator in StatementGenerators)
            {
                if (userInput.Equals(generator.Metadata.Type, StringComparison.OrdinalIgnoreCase))
                {
                    return generator.Value;
                }
            }
            throw new ArgumentException($"Type of {userInput} not found",nameof(userInput));
        } 
    }
}
