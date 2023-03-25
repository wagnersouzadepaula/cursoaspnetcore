using Microsoft.EntityFrameworkCore;
using DevIO.UI.Site.Models;

namespace DevIO.UI.Site.Data
{
	public class MeuDBContext : DbContext
	{
		public MeuDBContext(DbContextOptions options) : base (options)
		{

		}
		public DbSet<Aluno> Alunos { get; set; }
	}
}
