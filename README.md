# E-Commerce
Projekt z przedmiotów:
1. Projektowania Wielowarstwowych Aplikacji Biznesowych
2. Aplikacyjnego Projektu Zespołowego
3. Automatyzacji i Digitalizacji Procesów Biznesowych

# Uruchomienie projektu:
1. Pobrać pakiet projektu z GitHub'a;
2. W Visual Studio, w sekcji Eksplorator rozwiązań, przy ECommerce.Server klikamy PPM na Connected Services w celu utworzenia lokalenj bazy danych z migrowanych plików,
  które są zawarte w pakiecie projektu.
3. Sprawdzenie czy są dodane i zainstalowane pakietu NuGet.
4. W dolnej części VS przechodzimy do Program PowerShell dla deweloperów i wykonujemy następujące polecenia

cd ECommerce

cd Server

dotnet ef database update

5. Po tym wszystkim sprawdzamy czy projekt ECommenrce.Server jest jako startowy i uruchamiamy cały projekt.
