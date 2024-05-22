Potencjalne poprawki do utworzonej przez kolege akcji usuwania użytkowników :)

1. Zwracanym typem powinno być IActionResult, w celu łatwiejszej obsługi możliwych odpowiedzi akcji.
2. Kod powinien być odporny na potencjalne nieodnalezienie użytkownika poprzez sprawdzenie i wysłanie odpowiedzi NotFound.
3. Kod powinien być odporny na możliwe błędy podczas usuwania użytkownika i w ich przypadku powinien zwrócić błąd 500.
4. Kod powinien dodać log wraz z wiadomością z wyjątku, który może wystąpić.
5. Każde pole obiektów powinno zaczynać się z wielkiej litery (zamiast user.login, to user.Login).
