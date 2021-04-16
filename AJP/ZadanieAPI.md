# Zadanie API 

## Zadanie nr 1.

Przygotowujemy API restowe, które buduje kalkulator i ma zawierać następujące metody:
1. "api/dodaj" - przyjmuje dwie liczby, dodaje i zwraca wynik
2. "api/odejmij" - przyjmuje dwie liczby, odejmuje i zwraca wynik
3. "api/pomnóż" - przyjmuje dwie liczby, mnoży i zwraca wynik
4. "api/podziel" - przyjmuje dwie liczby, mnoży i zwraca wynik

## Zadanie nr 2
Tworzymy nowe metody, które tym razem mają api1, (api1/dodaj, api1/odejmij....) i przyjmują tylko jedną liczbę jako parametr, natomiast w systemie jest zawsze zapamiętywany wynik ostatniej operacji i kolejna operacja jako pierwszy parametr zawsze przyjmuje wynik poprzedniej. Dodatkowo system odkłada w historii wszystkie poprzednie operacje i dodajemy kolejne api:
1. "api1/historia" - zwraca listę wszystkich poprzednich operacji z opisem. na przykład Dodano 2 - wynik 3


## Instalacja nsag command line

```
dotnet tool install --global NSwag.ConsoleCore
```
Po dodaniu pliku wygenerowanego z nswag do projektu blazorowego ważne jest aby dodać referencję do **Newtonsoft.Json**

```
dotnet add package Newtonsoft.Json
```