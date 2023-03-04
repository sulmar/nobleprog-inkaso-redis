# Hash

## Zadanie 

Utwórz usługę do obsługi plan kont z użyciem REDIS. 


| Symbol | Nazwa                        | Winien | Ma  | 
|--------|------------------------------|--------|-----|
| 010    | Środki trwałe                | 22000  |     |
| 100    | Kasa                         |        |     |
| 130    | Rachunek bieżący             |        |     |
| 310    | Materiały                    | 750    |     |
| ...    | ...                          | ...    | ... |

- Pobranie informacji o koncie
~~~
GET /accounts/{symbol}
Accept: application/json
~~~

- Dodanie operacji
~~~
POST /accounts/{symbol}/operations
Content-Type: application/json
{"amount": 100, "description": "Zakupiono maszynę"}
~~~

- Operacja 1. Wpłacono 1200 zł z kasy na rachunek bieżący (Raport kasowy)
- Operacja 2. Zakupiono materiały ze środków z rachunku bieżącego netto 750 zł
- Operacja 3. Zakupiono maszynę o wartości netto 9000 zł 
- Operacja 4. Zakupiono maszynę o wartości netto 13000 zł