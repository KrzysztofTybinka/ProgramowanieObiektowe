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
#### 4. Główne okno uzytkownika
    
#### 5. Główne okno administratora

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
