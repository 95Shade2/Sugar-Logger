using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
        class Day
        {
                Meal breakfast;
                Meal lunch;
                Meal supper;
                Meal bed;

                public Day()
                {
                        breakfast = new Meal();
                        lunch = new Meal();
                        supper = new Meal();
                        bed = new Meal();
                }

                public Day(Meal breakfast)
                {
                        this.breakfast = breakfast;
                        lunch = new Meal();
                        supper = new Meal();
                        bed = new Meal();
                }

                public Day(Meal breakfast, Meal lunch)
                {
                        this.breakfast = breakfast;
                        this.lunch = lunch;
                        supper = new Meal();
                        bed = new Meal();
                }

                public Day(Meal breakfast, Meal lunch, Meal supper)
                {
                        this.breakfast = breakfast;
                        this.lunch = lunch;
                        this.supper = supper;
                        bed = new Meal();
                }

                public Day(Meal breakfast, Meal lunch, Meal supper, Meal bed)
                {
                        this.breakfast = breakfast;
                        this.lunch = lunch;
                        this.supper = supper;
                        this.bed = bed;
                }

                //getters
                public Meal getBreakfast()
                {
                        return breakfast;
                }

                public Meal getLunch()
                {
                        return lunch;
                }

                public Meal getSupper()
                {
                        return supper;
                }

                public Meal getBed()
                {
                        return bed;
                }

                //setters
                public void setBreakfastSugar(int new_sugar)
                {
                        this.breakfast.setSugar(new_sugar);
                }

                public void setLunchSugar(int new_sugar)
                {
                        this.lunch.setSugar(new_sugar);
                }

                public void setSupperSugar(int new_sugar)
                {
                        this.supper.setSugar(new_sugar);
                }

                public void setBedSugar(int new_sugar)
                {
                        this.bed.setSugar(new_sugar);
                }

                public void setBreakfastUnits(int new_sugar)
                {
                        this.breakfast.setUnits(new_sugar);
                }

                public void setLunchUnits(int new_sugar)
                {
                        this.lunch.setUnits(new_sugar);
                }

                public void setSupperUnits(int new_sugar)
                {
                        this.supper.setUnits(new_sugar);
                }

                public void setBedUnits(int new_sugar)
                {
                        this.bed.setUnits(new_sugar);
                }

                public void setBedLantis(int new_sugar)
                {
                        this.bed.setLantis(new_sugar);
                }

                public void setBreakfast(Meal breakfast)
                {
                        this.breakfast = breakfast;
                }

                public void setBreakfast(int sugar, int units)
                {
                        breakfast.setSugar(sugar);
                        breakfast.setUnits(units);
                }

                public void setLunch(Meal lunch)
                {
                        this.lunch = lunch;
                }

                public void setLunch(int sugar, int units)
                {
                        lunch.setSugar(sugar);
                        lunch.setUnits(units);
                }

                public void setSupper(Meal supper)
                {
                        this.supper = supper;
                }

                public void setSupper(int sugar, int units)
                {
                        supper.setSugar(sugar);
                        supper.setUnits(units);
                }

                public void setBed(Meal bed)
                {
                        this.bed = bed;
                }

                public void setBed(int sugar, int units)
                {
                        bed.setSugar(sugar);
                        bed.setUnits(units);
                }

                public void setBed(int sugar, int units, int lantis)
                {
                        bed.setSugar(sugar);
                        bed.setUnits(units);
                        bed.setLantis(lantis);
                }
        }
}
