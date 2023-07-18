using StatementBank.Abstractions;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace StatementBank
{
    public class CompositionBuilder
    {
        //[ImportMany]
        //private IEnumerable<Lazy<IStatementGenerator, IStatementGeneratorMetaData>> StatementGenerators;

        private readonly CompositionContainer? _container;
        [ImportMany]
        private List<Lazy<IStatementGenerator, IStatementGeneratorMetaData>> _statementGenerators = new();
        public IReadOnlyCollection<Lazy<IStatementGenerator, IStatementGeneratorMetaData>> StatementGenerators { get => _statementGenerators.AsReadOnly(); }

        public CompositionBuilder()
        {
            try
            {
                var catalog = new AggregateCatalog();
                // catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
                catalog.Catalogs.Add(new DirectoryCatalog("F:\\projects\\softelligence\\demoProjects\\StatementBank\\StatementBank\\Extensions\\Debug\\net6.0\\"));

                _container = new CompositionContainer(catalog);
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
        public IStatementGenerator GetGeneratorByMetaData(string userInput)
        {
            foreach (Lazy<IStatementGenerator, IStatementGeneratorMetaData> generator in StatementGenerators)
            {
                if (userInput.Equals(generator.Metadata.Type, StringComparison.OrdinalIgnoreCase))
                {
                    return generator.Value;
                }
            }
            return null;
        } 
    }
}
