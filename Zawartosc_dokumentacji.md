Wymagania funkcjonalne dla platformy e-commerce:
1.  Dodawanie produktów: Sprzedawcy powinni być w stanie dodawać swoje produkty do platformy. Powinni mieć możliwość określenia szczegółów produktu, takich jak nazwa, opis, cena i zdjęcie.
2.  Zarządzanie produktami: Sprzedawcy powinni być w stanie zarządzać swoimi produktami na platformie. Powinni mieć możliwość edycji szczegółów produktu, usuwania produktu lub dodawania nowych produktów.
3.  Przeglądanie produktów: Klienci powinni być w stanie przeglądać dostępne produkty na platformie. Powinni mieć możliwość wyszukiwania produktów według różnych kryteriów, takich jak kategoria, cena czy ocena.
4.  Składanie zamówień: Klienci powinni być w stanie składać zamówienia na produkty na platformie. Powinni mieć możliwość dodawania produktów do koszyka i składania zamówienia, podając szczegóły dostawy i płacąc za zamówienie.
5.  Zarządzanie zamówieniami: Zarówno sprzedawcy, jak i klienci, powinni być w stanie zarządzać zamówieniami. Sprzedawcy powinni mieć możliwość przeglądania złożonych zamówień, aktualizowania statusu zamówienia i komunikowania się z klientami. Klienci powinni mieć możliwość śledzenia statusu swojego zamówienia i komunikowania się ze sprzedawcą.
6.  Obsługa płatności: System powinien obsługiwać płatności za zamówienia. Powinien akceptować różne metody płatności, takie jak karty kredytowe, PayPal czy przelewy bankowe, i zapewniać bezpieczne i niezawodne przetwarzanie płatności. (sandbox operatora np. payu)
7.  Wysyłka: System powinien obsługiwać wysyłkę zamówień. Powinien umożliwiać sprzedawcom dodawanie informacji o wysyłce, takich jak koszt wysyłki, czas dostawy i dostępne metody wysyłki. Klienci powinni mieć możliwość wyboru preferowanej metody wysyłki podczas składania zamówienia.

Wymagania niefunkcjonalne dla platformy e-commerce:
1.  Wydajność: Platforma powinna być w stanie obsłużyć co najmniej 1000 użytkowników jednocześnie bez degradacji wydajności.
2.  Czas odpowiedzi: Czas odpowiedzi na żądania użytkowników nie powinien przekraczać 2 sekund. To zapewnia płynną i satysfakcjonującą interakcję użytkownika z platformą.
3.  Dostępność: Platforma powinna być dostępna w 99.9xx%. To jest kluczowe dla e-commerce, ponieważ klienci mogą chcieć dokonywać zakupów o dowolnej porze dnia czy nocy.
4.  Bezpieczeństwo: Platforma powinna zapewniać bezpieczne i niezawodne przetwarzanie płatności. Powinna również chronić dane osobowe użytkowników zgodnie z obowiązującymi przepisami o ochronie danych.
5.  Skalowalność: Platforma powinna być łatwo skalowalna, aby móc obsługiwać rosnącą liczbę użytkowników i transakcji.
6.  Użyteczność: Interfejs użytkownika powinien być intuicyjny i łatwy w użyciu, zarówno dla klientów, jak i sprzedawców. (baza na danej normie wiekowej, wziąć pod uwagę osoby niedowidzące itp)
7.  Kompatybilność: Platforma powinna być kompatybilna z różnymi przeglądarkami i urządzeniami, aby umożliwić jak największej liczbie użytkowników korzystanie z niej.
8.  Responsywność: Interfejs użytkownika powinien być responsywny, co oznacza, że powinien dobrze wyglądać i działać na różnych rozdzielczościach ekranu, od smartfonów po komputery stacjonarne.

Sposobów i metod testowania, które mogą być użyte do testowania platformy e-commerce:
1.	Testy jednostkowe: Są to testy, które sprawdzają funkcjonalność poszczególnych jednostek kodu, takich jak metody lub klasy. Na przykład, możesz napisać test jednostkowy, który sprawdza, czy metoda dodawania produktu do koszyka działa poprawnie. Testy jednostkowe są zazwyczaj automatyczne i mogą być łatwo zintegrowane z systemem kontroli wersji i CI/CD.
2.	Testy integracyjne: Są to testy, które sprawdzają interakcje między różnymi częściami systemu. Na przykład, możesz napisać test integracyjny, który sprawdza, czy po dodaniu produktu do koszyka, produkt ten jest poprawnie wyświetlany na stronie koszyka. Testy integracyjne są zazwyczaj bardziej złożone niż testy jednostkowe, ale są również bardzo ważne dla zapewnienia poprawnego działania systemu.
3.	Testy obciążeniowe: Są to testy, które sprawdzają wydajność i skalowalność systemu pod dużym obciążeniem. Na przykład, możesz przeprowadzić test obciążeniowy, który symuluje tysiące użytkowników jednocześnie korzystających z platformy, aby sprawdzić, czy system jest w stanie obsłużyć takie obciążenie. Testy obciążeniowe są kluczowe dla zapewnienia, że system jest gotowy na produkcję.
4.	Testy E2E (End-to-End): Są to testy, które sprawdzają działanie całego systemu od początku do końca. Na przykład, możesz przeprowadzić test E2E, który symuluje proces zakupu produktu przez użytkownika, od przeglądania produktów, przez dodawanie produktu do koszyka, składanie zamówienia, aż po potwierdzenie zamówienia. Testy E2E są zazwyczaj przeprowadzane ręcznie, ale mogą być również zautomatyzowane za pomocą narzędzi takich jak Selenium.
5.	Testy bezpieczeństwa (na wdrożonych systemie, NIEOBOWIAZKOWE): Są to testy, które sprawdzają, czy system jest odporny na różne rodzaje ataków, takie jak ataki SQL Injection, Cross-Site Scripting (XSS) czy Cross-Site Request Forgery (CSRF). Testy bezpieczeństwa są niezbędne dla zapewnienia, że dane użytkowników są bezpieczne.

Warstwa logiki biznesowej dla platformy e-commerce może obejmować następujące elementy:
1.	Zarządzanie produktami: Powinny być metody umożliwiające dodawanie nowych produktów, edycję istniejących produktów i usuwanie produktów. Każdy produkt może mieć różne atrybuty, takie jak nazwa, opis, cena, zdjęcie i sprzedawca.
2.	Zarządzanie zamówieniami: Powinny być metody umożliwiające tworzenie nowych zamówień, aktualizację statusu istniejących zamówień i anulowanie zamówień. Każde zamówienie może mieć różne atrybuty, takie jak lista produktów, łączna kwota, adres dostawy i status.
3.	Zarządzanie użytkownikami: Powinny być metody umożliwiające rejestrację nowych użytkowników, logowanie i wylogowywanie, a także aktualizację profilu użytkownika. Każdy użytkownik może mieć różne atrybuty, takie jak nazwa użytkownika, hasło, adres e-mail i adres dostawy.
4.	Obsługa płatności: Powinny być metody umożliwiające przetwarzanie płatności za zamówienia. To może obejmować integrację z zewnętrznym dostawcą usług płatniczych.
5.	Wysyłka: Powinny być metody umożliwiające obsługę wysyłki zamówień. To może obejmować integrację z zewnętrznym dostawcą usług logistycznych.

Warstwa prezentacji dla platformy e-commerce może obejmować następujące elementy:
1.	Strony produktów: Strony te powinny wyświetlać szczegółowe informacje o każdym produkcie, takie jak nazwa, opis, cena i zdjęcie. Powinny również umożliwiać klientom dodawanie produktu do koszyka.
2.	Strona koszyka: Strona ta powinna wyświetlać wszystkie produkty dodane do koszyka przez klienta. Powinna umożliwiać klientom zmianę ilości każdego produktu w koszyku, usuwanie produktów z koszyka i składanie zamówienia.
3.	Strony zamówień: Strony te powinny wyświetlać szczegółowe informacje o każdym zamówieniu, takie jak lista produktów, łączna kwota, status zamówienia i szczegóły dostawy. Powinny również umożliwiać klientom śledzenie statusu swojego zamówienia.
4.	Strony użytkowników: Strony te powinny umożliwiać użytkownikom rejestrację, logowanie i wylogowywanie, a także aktualizację swojego profilu.

Baza danych dla platformy e-commerce może obejmować następujące tabele:
1.	Tabela Sellers: Ta tabela przechowuje informacje o sprzedawcach. Może zawierać kolumny takie jak SellerId, Name, Address.
2.	Tabela Products: Ta tabela przechowuje informacje o produktach. Może zawierać kolumny takie jak ProductId, Name, Price, Description, Image, SellerId. SellerId jest kluczem obcym, który łączy tabelę Products z tabelą Sellers.
3.	Tabela Orders: Ta tabela przechowuje informacje o zamówieniach. Może zawierać kolumny takie jak OrderId, CustomerId, TotalAmount, OrderStatus, ShippingAddress.
4.	Tabela OrderItems: Ta tabela przechowuje informacje o poszczególnych pozycjach w zamówieniach. Może zawierać kolumny takie jak OrderItemId, OrderId, ProductId, Quantity. OrderId i ProductId są kluczami obcymi, które łączą tabelę OrderItems z tabelami Orders i Products.
5.	Tabela Customers: Ta tabela przechowuje informacje o klientach. Może zawierać kolumny takie jak CustomerId, Name, Email, PasswordHash, ShippingAddress.
