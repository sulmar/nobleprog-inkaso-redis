### Connection

| Komenda  | Opis   |
|---|---|
| **AUTH** [password] | Autentykacja do serwera  |
| **PING** [message] | Ping do serwera  |
| **ECHO** message | Wyświetlenie komunikatu |
| **SELECT** index | Zmiana bazy danych |
| **SWAPDB** index index | Zamiana baz danych |
| **QUIT** | Zamknięcie połączenia |
| **INFO** [section] | Wyświetlenie informacji |

### Podstawowe

| Komenda  | Opis   |
|---|---|
| **EXISTS** key  | Sprawdzenie czy klucz istnieje |
| **RENAME** key newkey | Zmiana nazwy klucza |
| **MOVE** key db | Przesunięcie klucza do innej bazy danych |
| **DEL** key  | Usunięcie klucza  |
| **RANDOMKEY** | Pobranie losowego klucza |
| **DUMP** key  | Pobranie serializowanej wartości klucza  |
| **TYPE** key  | Pobranie typu klucza |
| **EXPIRE** key seconds  | Ustawienie czasu wygaśnięcia klucza |
| **EXPIREAT** key timestamp  | Ustawienie daty wygaśnięcia klucza |
| **TTL** key | Pobranie pozostałego czasu do wygaśnięcia klucza w sekundach |
| **PTTL** key | Pobranie pozostałego czasu do wygaśnięcia klucza w milisekundach 
| **PERSIST** key | Wyłączenie wygasania klucza |
| **KEYS** pattern | Pobranie wszystkich nazw kluczy według wzorca |
| **SCAN** cursor [MATCH pattern] [COUNT count] [TYPE type] | Pobranie określonej ilości nazw kluczy na podstawie wzorca lub typu |


