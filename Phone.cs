using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace hw
{


//     Задание 1:
// Создайте пользовательский тип Телефон. Необходимо хранить
// такую информацию:
//  Название телефона
//  Производитель
//  Цена
//  Дата выпуска
    public class Phone
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public int YearProduction { get; set; }



        public Phone(string model, string m, int p, int y){
            if(model != null){
            Model = model;
            }
            else{
                Write("Incorrect name \n");
            }

            if(m != null){
    Manufacturer = m;
            }
            else{
                Write("Incorrect manufacturer \n");
            }

        
            if(p > 0){
            Price = p;
            }
            else{
                Write("Incorrect price \n");
            }

            
            if(y > 1980 && y < 2025){
            YearProduction = y;
            }
            else{
                Write("Incorrect year \n");
            }

            

        }

           public override string ToString()
    {
        return $"{Manufacturer} - {Model} – {Price} - {YearProduction}";
    }

        
    }
}