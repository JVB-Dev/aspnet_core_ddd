using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    /// <summary>
    /// A factory informa as ferramentas sobre como criar seu DbContext, portanto,
    /// as ferramentas ignorarão as outras maneiras de criar o DbContext e usar a fábrica de tempo de design em vez disso.
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            string connString = "Server=localhost;Port=3306;Database=db_aspnet_core_ddd;Uid=root;Pwd=mudar@123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}