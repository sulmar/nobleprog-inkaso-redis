
# Sorted Sets

## Zadanie

Utwórz usługę do analizy rankingu szachowego.
Dane załadować z pliku ranking.txt (na podst. https://pl.wikipedia.org/wiki/Ranking_szachowy)

- Pobierz top N
~~~
GET /chess/ranking/top?count={n}
Accept: application/json
~~~


- Pobierz bottom N
~~~
GET /chess/ranking?bottom/count={n}
Accept: application/json
~~~
