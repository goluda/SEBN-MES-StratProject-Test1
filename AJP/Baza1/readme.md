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