// See https://aka.ms/new-console-template for more information
using hw;
using static System.Console;
using System;
using System.Linq;

// Для массива телефонов выполните следующие задания,
// используя агрегатные операции из LINQ:
//  Посчитайте количество телефонов
//  Посчитайте количество телефонов с ценой больше 100
//  Посчитайте количество телефонов с ценой в диапазоне от
// 400 до 700
//  Посчитайте количество телефонов конкретного
// производителя
//  Найдите телефон с минимальной ценой
//  Найдите телефон с максимальной ценой
//  Отобразите информацию о самом старом телефоне
//  Отобразите информацию о самом свежем телефоне
//  Найдите среднюю цену телефона
//  Отобразите пять самых дорогих телефонов
//  Отобразите пять самых дешевых телефонов
//  Отобразите три самых старых телефона
//  Отобразите три самых новых телефона
//  Отобразите статистику по количеству телефонов каждого
// производителя. Например: Sony – 3, Samsung – 4, Apple – 5
// и т. д.
//  Отобразите статистику по количеству моделей телефонов.
// Например: IPhone 13 – 12, IPhone 10 – 11, Galaxy S22 – 8
//  Отобразите статистику телефонов по годам. Например: 2021
// – 10, 2022 – 5, 2019 – 3

 Phone[] phones =
            [
                new Phone("iPhone 13", "Apple", 999, 2021),
                new Phone("Galaxy S21", "Samsung", 799, 2021),
                new Phone("Pixel 6", "Google", 599, 2021),
                new Phone("Xperia 5", "Sony", 699, 2020),
                new Phone("Redmi Note 10", "Xiaomi", 199, 2021),
                new Phone("Moto G Power", "Motorola", 249, 2021),
                new Phone("Nokia G10", "Nokia", 149, 2021),
                new Phone("OnePlus 9", "OnePlus", 729, 2021),
                new Phone("Galaxy A12", "Samsung", 179, 2021),
                new Phone("Realme 8", "Realme", 229, 2021),
                new Phone("Huawei P40", "Huawei", 899, 2020)
            ];


            // foreach (var phone in phones)
            // {
            //     WriteLine($"Name: {phone.Name}, Manufacturer: {phone.Manufacturer}, Price: {phone.Price}, Year: {phone.YearProduction}");
            // }

//  Посчитайте количество телефонов

int size = phones.Count();
WriteLine($"количество телефонов: {size} \n");


//  Посчитайте количество телефонов с ценой больше 100
int priceMore100 = (from phone in phones where phone.Price > 100 select phone).Count(); 
WriteLine($"количество телефонов с ценой больше 100: {priceMore100} \n");


//  Посчитайте количество телефонов с ценой в диапазоне от
// 400 до 700
int from400to700 = (from phone in phones where phone.Price > 400 && phone.Price < 700 select phone).Count();
WriteLine($"количество телефонов с ценой больше 400 и меньше 700: {from400to700} \n");


//  Посчитайте количество телефонов конкретного
// производителя
int concreteManufacter = (from phone in phones where phone.Manufacturer == "Apple" select phone).Count();
WriteLine($"количество телефонов от Apple: {concreteManufacter} \n");



//  Найдите телефон с минимальной ценой
var sortedByMinPrice = phones.OrderBy(x => x.Price).First();
WriteLine($"телефон с минимальной ценой: {sortedByMinPrice} \n");


//  Найдите телефон с максимальной ценой
var sortedByMaxPrice = phones.OrderBy(x => x.Price).Last();
WriteLine($"телефон с максимальной ценой: {sortedByMaxPrice} \n");


//  Отобразите информацию о самом старом телефоне
var sortedByYearProduction = phones.OrderBy(x => x.YearProduction).Last();
WriteLine($"самый старый телефон: {sortedByYearProduction} \n");


//  Отобразите информацию о самом свежем телефоне
var theNewestPhone = phones.OrderBy(x => x.YearProduction).First();
WriteLine($"самый новый телефон: {theNewestPhone} \n");


//  Найдите среднюю цену телефона
var middlePrice = phones.Average(x => x.Price);


//  Отобразите пять самых дорогих телефонов
var theMostExpensive = (from phone in phones orderby phone.Price select phone).Take(5);

WriteLine("топ 5 дорогих: \n");
foreach(var phone in theMostExpensive){
WriteLine($" {phone.Model} \n");
}

//  Отобразите пять самых дешевых телефонов
var theCheapest = (from phone in phones orderby phone.Price descending select phone).Take(5);

WriteLine("топ 5 дешевых: \n");
foreach(var phone in theCheapest){
WriteLine($" {phone.Model} \n");
}


//  Отобразите три самых старых телефона
var theOldest = (from phone in phones orderby phone.YearProduction select phone).Take(3);

WriteLine("топ 3 старых: \n");
foreach(var phone in theOldest){
WriteLine($" {phone.Model} \n");
}


//  Отобразите три самых новых телефона
var theNewest = (from phone in phones orderby phone.YearProduction descending select phone).Take(3);

WriteLine("топ 3 новых: \n");
foreach(var phone in theNewest){
WriteLine($" {phone.Model} \n");
}


//  Отобразите статистику по количеству телефонов каждого
// производителя. Например: Sony – 3, Samsung – 4, Apple – 5
// и т. д.

var phoneStatisticsByManufacturer = phones
    .GroupBy(phone => phone.Manufacturer)
    .Select(group => new { Manufacturer = group.Key, Count = group.Count() })
    .OrderByDescending(stat => stat.Count);
    

     WriteLine("Статистика по количеству производителю: \n");
    foreach(var phone in phoneStatisticsByManufacturer){
        WriteLine($"{phone.Manufacturer} - {phone.Count}");
    }



//  Отобразите статистику по количеству моделей телефонов.
// Например: IPhone 13 – 12, IPhone 10 – 11, Galaxy S22 – 8

    var phoneStatisticsByModel = phones
    .GroupBy(phone => phone.Manufacturer)
    .Select(group => new { Model = group.Key, Count = group.Count() })
    .OrderByDescending(stat => stat.Count);
    

    WriteLine("Статистика по количеству моделей: \n");
    foreach(var phone in phoneStatisticsByModel){
        WriteLine($"{phone.Model} - {phone.Count}");
    }



//  Отобразите статистику телефонов по годам. Например: 2021
// – 10, 2022 – 5, 2019 – 3

   var phoneStatisticsByYear = phones
    .GroupBy(phone => phone.Manufacturer)
    .Select(group => new { Year = group.Key, Count = group.Count() })
    .OrderByDescending(stat => stat.Count);
    

     WriteLine("Статистика по годам: \n");
    foreach(var phone in phoneStatisticsByYear){
        WriteLine($"{phone.Year} - {phone.Count}");
    }


