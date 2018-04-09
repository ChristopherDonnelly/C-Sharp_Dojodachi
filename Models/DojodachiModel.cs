using System;

namespace Dojodachi_Project.Models
{
    public class Dojodachi {

        public enum StatusType
        {
            neutral,
            happy,
            sad,
            mad,
            sleepy,
            sick,
            dead
        }
        public int happiness { get; set; }
        public int fullness { get; set; }
        public int energy { get; set; }
        public int meals { get; set; }
        public StatusType status { get; set; }

        public Dojodachi(){
            this.happiness = 20;
            this.fullness = 20;
            this.energy = 50;
            this.meals = 3;
            this.status = StatusType.neutral;
        }

        private bool getChance(int chance){
            return (getRandAmount(1, 100)<=chance);
        }

        private int getRandAmount(int min, int max)
        {
            Random rand = new Random();
            int val = rand.Next(min, max+1);
            return val;
        }

        public int feed(){ 
            int newFullness = 0;

            if(meals > 0){
                if(getChance(25)){
                    this.status = StatusType.sick;
                }else{
                    newFullness = getRandAmount(5, 10);
                    this.fullness = this.fullness + newFullness;
                    Console.WriteLine("Fullness: " + this.fullness);
                    this.status = StatusType.happy;
                }
                this.meals--;
            }
            return newFullness;
        }

        public int play(){
            int newHappiness = 0;

            if(energy >= 5){
                if(getChance(25)){
                    this.status = StatusType.sad;
                }else{
                    newHappiness += getRandAmount(5, 10);
                    this.happiness = this.happiness + newHappiness;
                    Console.WriteLine("Happiness: " + this.happiness);
                    this.status = StatusType.happy;
                }
                this.energy -= 5;
            }
            return newHappiness;
        }

        public int work(){
            int newMeals = 0;

            if(energy >= 5){
                if(getChance(25)){
                    this.status = StatusType.sad;
                }else{
                    this.status = StatusType.happy;
                }
                newMeals += getRandAmount(1, 3);
                this.meals = this.meals + newMeals;
                Console.WriteLine("Meals: " + this.meals);
                this.energy -= 5;
            }
            return newMeals;
        }

        public bool sleep(){
            bool success = true;

            if(getChance(25)){
                this.status = StatusType.sad;
            }else{
                this.status = StatusType.happy;
            }

            this.energy += 15;
            this.fullness -= 5;
            this.happiness -= 5;

            return success;
        }

    }
}