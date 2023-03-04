# Geo

## Zadanie 
Utwórz rozwiązanie, które umożliwi wyszukiwanie najbliższych hoteli na podst. 
https://api.turystyka.gov.pl/registers/open/cwoh?city=Warszawa&size=10


- Wyszukaj hotele od podanego położenia w zadanym promieniu w km
~~~
GET /hotels/near?lat={lat}&lng={lng}&range={range}
Accept: application/json
~~~

Oczekiwany wynik:

| name       | street    | lat        | lng         | distance  |
|------------|-----------|------------|-------------|-----------|
|            |           |            |             |           |
|            | ...       | ...        | ...         | ...       |
