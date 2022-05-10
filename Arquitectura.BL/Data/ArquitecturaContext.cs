using Arquitectura.BL.Models;
using System.Data.Entity;

namespace Arquitectura.BL.Data
{
    public class ArquitecturaContext: DbContext
    {
        private static ArquitecturaContext arquitecturaContext = null;
        public ArquitecturaContext() :  base("Connection")
        {

        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<CourseInstructor> CourseInstructor { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<DocumentType> DocumentType{ get; set; }
        public DbSet<Customer> Customer{ get; set; }
        public DbSet<Developer> Developer { get; set; }
        public DbSet<Requirement> Requirement { get; set; }
        public DbSet<Project> Project { get; set; }
        
        public static ArquitecturaContext Create()
        {
            return new ArquitecturaContext();
        }
    }
}
