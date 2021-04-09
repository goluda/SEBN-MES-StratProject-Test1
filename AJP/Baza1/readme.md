# instalacja mariadb w dockerze

Uruchmienie maria db
```
docker compose -f ./comopse.yaml up -d
```

usuniecie
```
docker compose -f ./comopse.yaml down
```


### w folderze BazaTestLudziki
dodajemy pakiet mysql

```
dotnet add package MySql.EntityFrameworkCore
```
Dokumentacja pomocna
- [dokumentacja ef core](https://docs.microsoft.com/pl-pl/ef/core/)
- [dockuemntacja mysql](https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html)

Tworzymy klasę myContext
```c#
public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=test;user=root;password=test");
        }
        public DbSet<ludziki> ludziki { get; set; }


    }
    public class ludziki
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazisko { get; set; }

    }
```