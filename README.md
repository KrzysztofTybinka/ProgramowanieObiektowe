# Harmonogram dla projektu Obiket Sportowy

Aplikacja obiektu sportowego umożliwiajaca rezerwacje stanowisk/kortów/boisk dla klientów 
posiadajacych karnety, upoważniające do uczęszczania do klubu i rezerwacji 
dowolnego stanowiska, kortu lub boiska raz dziennie przez okres trwania karnetu. 
Konto jest aktywne przez czas trwania biletu, gdy ważność karnetu upłynie 
blokowana jest możliwość rezerwacji do ponownego aktywowania karnetu.

## Wizualne: 

#### 1. Okno logowania
    1. Pola do wprowadzenia danych oraz przyciski rejestracji, przypomnienia hasła i logowania.
    2. Komunikat o poprawności wprowadzonych danych.
#### 2. Okno rejestracji
    1. Pola do wprowadzenia danych oraz niezbędne przyciski.
    2. Komunikaty o niepoprawności wprowadzonych danych, lub zbyt słabej sile hasła.
    3. Możliwośc zalogowania się po rejestracji.
#### 3. Okno przypomnienia hasła    
    1. Pole do wprowadzenia adresu e-mail.
    2. Przycisk 'send'.
#### 4. Okno uzytkownika
##### a. Główne okno użytkownika
    1. Przycisk wyloguj wyświetlający message box 
    z zapytaniem "Czy na pewno chcesz się wylogować?".
    2. Przycisk "Mój profil" przenoszący użytkownika do okna profilu.
    3. Lista dostępnych terminów rezerwacji.
    4. Textbox umożliwiający filtrowanie terminów przez wpisywanie odpowiednich fraz kluczowych.
    5. Przycisk szukaj szukający wpisanej frazy w liście terminów.
    6. Przycisk "rezerwuj" umożliwiajacy zarezerwowanie zaznaczonego na liście terminu.
##### b. Okno mój profil
    1. Przycisk "wstecz" przenoszący do głównego okna użytkownika.
    2. Przycisk zmień hasło wyświetlajacy nowe okno z formularzem zmiany hasła.
    3. Tabela z danymi użytkownika.
    4. tabela z listą rezerwacji użytkownika.
    5. Przycisk "odwołaj rezerwacje" umożliwiający odwołanie zaznaczonej rezerwacji.   
#### 5. Okno administratora
##### a. Główne okno administratora
    1. Przycisk wyloguj wyświetlający message box 
    z zapytaniem "Czy na pewno chcesz się wylogować?". 
    2. Lista reezerwacji.
    3. Przycisk "Usuń rezerwację" umożliwiający usunięcie zaznaczonej rezerwacji.
    4. Przycisk "Lista użytkowników" przenoszący do okna z listą użytkowników.
    5. Przycisk "Terminy" przenoszący do okna z lista terminów.
##### b. Okno lista użytkowników
    1. Przycisk "wstecz" przenoszący do głównego okna administratora.
    2. Przycisk "Pobierz listę użytkowników" wyświetlajacy okno
    dialogowe zapisu pliku, który po wybraniu lokalizacji serializuje
    dane o użytkownikach do pliku XML.
    3. Przycisk "Usuń użytkownika" usuwajacy zaznaczonego użytkownika.
##### c. Okno terminy
    1. Przycisk "wstecz" przenoszący do głównego okna administratora.
    2. Lista kategorii.
    3. Przycisk "dodaj kategorię" dodający kategorie.
    4. Przycisk "usuń kategorię" usuwajacy kategorię.
    5. Lista pomieszczeń.
    6. Przycisk "dodaj pomieszczenie" dodający pomieszczenie.
    7. Przycisk "usuń pomieszczenie" usuwajacy pomieszczenie.
    8. Lista terminów.
    9. Przycisk "dodaj termin" dodający termin.
    10. Przycisk "usuń termin" usuwajacy termin.
    

## Techniczne:

#### 1. Baza danych
    1. Tabela Guests
    2. Tabela Categories
    3. Tabela Fields
    4. Tabela ToReserve
    5. tabela Reservations
#### 2. ORM + operacje na bazie
    1. Dodawanie rekordów do bazy.
    2. Usuwanie rekordów z bazy.
#### 3. Walidacja
    1. Poprawności danych podczas logowania.
    2. Poprawności danych i sile hasła podczas rejestracji.
    3. Unikalności loginu i adresu mailowego rejestrującego się użytkownika.
    4. Unikalności wprowadzanych do aplikacji danych dotyczących rezerwacji.
    5. Pilnowanie aby dwie osoby nie mogły zarejestrowac się na ten sam termin.
