# Harmonogram dla projektu Teatr

Aplikacja Teatru xyz umożliwiajaca rezerwacje spektakli teatralnych dla klientów 
posiadajacych okresowe bilety do teatru, upoważniające do uczęszczania na jeden 
dowolny spektakl dziennie przez okres trwania biletu. Konto jest aktywne przez 
czas trwania biletu, gdy aktywnośc konta upłynie, blokowana jest możliwość
rezerwowania spektakli do ponownego aktywowania konta.

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
    2. Tabela Performances
    3. Tabela Reservations
    4. Tabela Rooms
#### 2. ORM + operacje na bazie
    1. Dodawanie rekordów do bazy.
    2. Usuwanie rekordów z bazy.
#### 3. Walidacja
    1. Poprawności danych podczas logowania.
    2. Poprawności danych i sile hasła podczas rejestracji.
