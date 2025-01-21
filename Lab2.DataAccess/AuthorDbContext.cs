﻿using Microsoft.EntityFrameworkCore;

namespace Lab2.DataAccess
{
    public class AuthorDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public AuthorDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Acrob\\source\\repos\\Lab4\\Lab2.DataAccess\\AuthorDb.mdf;Integrated Security = True");
        }
    }
}
