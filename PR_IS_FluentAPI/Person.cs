using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration1111
{
    /*
     * TODO 0. Мета роботи - вивчення технології Entity Framework Core Fluent API та міграцій
     * https://docs.microsoft.com/ef/core/modeling/
     * та виконання міграцій
     * https://docs.microsoft.com/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
     *
     * Перед виконанням роботи потрібно встановити пакети NuGet:
     * 
     * Install-Package Microsoft.EntityFrameworkCore -Version 6.0.0
     * Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.0
     * Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.0
     *
     * При виконанні цієї роботи ми жодного разу не запускатимемо програму
     * У звіті треба буде відобразити не лише підсумковий код,
     * а й процес виконання міграцій (зміна коду моделі класів та контексту, створення та виконання міграцій),
     * а також зміни, що відбулися в БД
     */

    /*
     * TODO 1. Створення моделі класів
     * Поки що це звичайні класи, скопійовані з попередньої програми (Code First)
     * з невеликими змінами
     * З цієї причини, краще згенерувати нову БД, а не використовувати ту, яка створена на попередній ЛР
     *
     * Зверніть увагу, що частина коду закоментована
     * Поки що так і залиште
     * Він буде розкоментований для зміни структури БД
     */

    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int? House { get; set; }

        public virtual List<Person> Persons1 { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }

        /* 
         * TODO 5. Изменение структуры БД
         * TODO 5.1. Добавляем новые свойства
         * Раскомментируйте блок кода ниже, чтобы добавить новые свойства в модель классов
         */

        /*
        public string StupidProperty { get; set; } // это свойство не будет отображаться на БД
        public string SomeStr { get; set; } // новое свойство, его пока нет в БД
        public string SomeStr2 { get; set; } // новое свойство, его пока нет в БД
        public DateTime Created { get; set; } // тоже новое свойство
        */

        public virtual Address Adress { get; set; }
    }

}
