﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration1111
{
    class PersonContext : DbContext
    {
        public PersonContext()
        {
            // Метод EnsureCreated() создаст БД при первом использовании
            // Database.EnsureCreated();
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Person> Person { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                 * В строке соединения необходимо указать параметр Database
                 * В AttachDbFilename необходимо указать путь, по которому вы хотите создать БД
                 * Путь должен существовать, а сама БД - нет
                 * Если нужно переименовать БД, измените названия в параметрах Database и AttachDbFilename
                 */
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=Person_1111Migr;AttachDbFilename=E:\Users\Lena\NET\DB\Person_1111Migr.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* TODO 3. Начальная миграция
             * Откройте окно консоли диспетчера пакетов, используя меню
             * Tools \ NuGet Package Manager \ Package Manager Console
             * и выполните команду
             * Add-Migration InitialCreate
             * Будет создана начальная миграция, которая описывает процесс создания БД
             * 
             * Применение миграции произойдёт после выполнения команды
             * Update-Database
             * После создания БД полключитесь к ней и посмотрите, что там творится
             * 
             * Если вы хотите не создавать БД автоматически, а сгенерировать SQL-скрипт для последующей отладки и настройки, вам поможет команда
             * Script-Migration
             */

            // TODO 2.3. Начальные данные, добавляемые при создании БД

            modelBuilder.Entity<Address>().HasData(new Address { Id = 1, Street = "Ивановская", House = 21 });
            modelBuilder.Entity<Address>().HasData(new Address { Id = 2, Street = "Петровская", House = 17 });

            modelBuilder.Entity<Person>().HasData(new { Id = 1, Name = "Иванов Иван Иваныч", BirthYear = 1980, AdressId = 1 });
            modelBuilder.Entity<Person>().HasData(new { Id = 2, Name = "Иванова Катерина Васильевна", BirthYear = 1981, AdressId = 1 });
            modelBuilder.Entity<Person>().HasData(new { Id = 3, Name = "Иванов Виктор", BirthYear = 2000, AdressId = 1 });

            modelBuilder.Entity<Person>().HasData(new { Id = 4, Name = "Петров Петр Петрович", BirthYear = 1985, AdressId = 2 });
            modelBuilder.Entity<Person>().HasData(new { Id = 5, Name = "Петров Павел Петрович", BirthYear = 2007, AdressId = 2 });

            // TODO 4. Использование Fluent API


            /* TODO 4.1. Переименование таблиц
             * 
             * Раскомментируйте блок кода ниже и создайте миграцию
             * Add-Migration <ну как-то её назовите>
             */

            /*
            modelBuilder.Entity<Person>().ToTable("PersonTable");
            modelBuilder.Entity<Address>().ToTable("AdressTable");


            modelBuilder.Entity<Person>().Property(p => p.Name).HasColumnName("PersonName");
            modelBuilder.Entity<Person>().Property(p => p.Name).HasMaxLength(150);
            modelBuilder.Entity<Person>().Property(p => p.Name).IsRequired();
            */

            /*
             * TODO 5.2. Настройка свойств
             * Раскомментируйте блок кода ниже, чтобы настроить новые свойства
             * После этого создайте и примените новую миграцию
             * Подключитесь к БД и проверьте, что там изменилось
             */

            /*
            modelBuilder.Entity<Person>().Ignore(p => p.StupidProperty);

            modelBuilder.Entity<Person>().Property(p => p.SomeStr).HasMaxLength(20);
            modelBuilder.Entity<Person>().Property(p => p.SomeStr).HasDefaultValue("как-то так");

            modelBuilder.Entity<Person>().Property(p => p.Created).HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Person>().Property(p => p.SomeStr2).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.SomeStr2).HasMaxLength(20);
            modelBuilder.Entity<Person>().Property(p => p.SomeStr2).HasDefaultValue("как-то не так");
            */

            base.OnModelCreating(modelBuilder);
        }

    }
}
