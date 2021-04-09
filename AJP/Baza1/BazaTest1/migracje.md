# Jak używać migracji

1. dodać do projektu pakiet design
```
 dotnet add package Microsoft.EntityFrameworkCore.Design
```
2. Tworzenie nowej migracji
```
dotnet ef migrations add "ludziki"
```
3. Aktualizacja bazy danych i wdorżenie migracji
```
dotnet ef database update    
```