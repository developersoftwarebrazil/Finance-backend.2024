using Finance.Domain.Entity.Entities.Systems.Expenses;
using Finance.Domain.Interfaces.Repositories.Systems.Expenses;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.System.SystemExpenses
{
    public class RepositorySystemExpense : RepositoryBase<SystemExpense>, IRepositorySystemExpense
    {
        private readonly DbContextOptions<FinanceDbContext> optionosBuilder;
        public RepositorySystemExpense()
        {
            this.optionosBuilder = new DbContextOptions<FinanceDbContext>();
        }

        //Métop par gerar cópia das despesas 
        public async Task<bool> GenerateSystemExpenseCopy()
        {
            var expenseSystemList = new List<SystemExpense>();

            try // se tudo estiver ok cai aqui dentro
            {

                using (var data = new FinanceDbContext(optionosBuilder))
                {
                    //Gerar lista 
                    expenseSystemList = await data.SystemExpenses.Where(s => s.GenerateExpensesCopy).ToListAsync();

                    // Fazer uma verradura para verifica se há algo para ser copiado.
                    foreach (var expense in expenseSystemList)
                    {
                        var actualDate = DateTime.UtcNow;

                        var month = actualDate.Month;
                        var year = actualDate.Year;


                        //faz a consulta no banco
                        var existingExpense = await (
                                                     from e in data.Expenses
                                                     join c in data.CategoryExpenses on e.CategoryExpenseId equals c.Id
                                                     where c.SystemExpenseId == expense.Id && e.Month == month && e.Year == year
                                                     select e.Id
                                                     ).AnyAsync();

                        //Verifica se já existe o item a ser copiado .

                        if (!existingExpense)// se não existir ai ele cria
                        {
                            // Lista todas as despesas para serem copiadas
                            var systemExpenses = await (
                                                        from e in data.Expenses
                                                        join c in data.CategoryExpenses on e.CategoryExpenseId equals c.Id
                                                        where c.SystemExpenseId == expense.Id && e.Month == expense.Month && e.Year == expense.YearCopy
                                                        select e
                                                       ).ToListAsync();

                            //Faz a cópia da despesa 
                            systemExpenses.ForEach(e =>
                            {
                                e.Id = 0;
                                e.Month = month;
                                e.Year = year;
                                e.RegistrationDate = actualDate;
                                e.DueDate = new DateTime(year, month, e.DueDate.Day);
                                e.RegistrationChangeDate = DateTime.MinValue;
                                e.PayedOut = false;
                            });

                            if (systemExpenses.Any())// Se já existe 
                            {
                                data.Expenses.AddRange(systemExpenses);
                                await data.SaveChangesAsync();
                            }
                        }
                    }

                }
            }
            catch (Exception) // Se houver algum erro casi aqui dentro
            {

                return false;
            }
            return true;
        }

        public async Task<IList<SystemExpense>> SystemExpenseUserList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionosBuilder))
            {
                return await (
                            from s in data.SystemExpenses
                            join us in data.UserSystemExpenses on s.Id equals us.SystemExpenseId
                            where us.UserEmail.Equals(userEmail)
                            select s
                    ).AsNoTracking().ToListAsync();
            }
        }
    }
}
