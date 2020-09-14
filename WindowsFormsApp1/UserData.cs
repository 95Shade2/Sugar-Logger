using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
        class UserData
        {
                /* 1.0
                intArray months;
                intArray days;
                intArray years;
                intArray weekDay;
                intArray sugar;
                intArray units;
                */

                // 2.0
                //key = MM/DD/YYYY
                Dictionary<string, Day> days;
                Dictionary<int, string> dates;
                int total_days;
                string username;
                int user_id;
                
                public UserData(int userID)
                {
                        days = new Dictionary<string, Day>();
                        dates = new Dictionary<int, string>();
                        total_days = 0;
                        username = "";
                        user_id = userID;
                }

                public UserData(int userID, string first_date, Day first_day)
                {
                        days = new Dictionary<string, Day>();
                        dates = new Dictionary<int, string>();
                        total_days = 1;
                        username = "";
                        user_id = userID;

                        dates[0] = first_date;
                        days[first_date] = first_day;
                }

                //getter methods
                public int getTotalDays()
                {
                        return total_days;
                }
                public Dictionary<string, Day> getDays()
                {
                        return days;
                }
                public string getDate(int index)
                {
                        return dates[index];
                }
                public string getLastDate()
                {
                        return dates[total_days-1];       //returns the last date
                }
                public Meal getBreakfast(string date)
                {
                        return days[date].getBreakfast();
                }
                public Meal getLunch(string date)
                {
                        return days[date].getLunch();
                }
                public Meal getSupper(string date)
                {
                        return days[date].getSupper();
                }
                public Meal getBed(string date)
                {
                        return days[date].getBed();
                }
                public Dictionary<int, string> getDates()
                {
                        return dates;
                }
                public string getUsername()
                {
                        return username;
                }
                public int getID()
                {
                        return user_id;
                }


                //setter methods
                public void setUsername(string newName)
                {
                        username = newName;
                }
                public void setBreakfastSugar(string date, int new_sugar)
                {
                        days[date].setBreakfastSugar(new_sugar);
                }
                public void setLunchSugar(string date, int new_sugar)
                {
                        days[date].setLunchSugar(new_sugar);
                }
                public void setSupperSugar(string date, int new_sugar)
                {
                        days[date].setSupperSugar(new_sugar);
                }
                public void setBedSugar(string date, int new_sugar)
                {
                        days[date].setBedSugar(new_sugar);
                }
                public void setBreakfastUnits(string date, int new_sugar)
                {
                        days[date].setBreakfastUnits(new_sugar);
                }
                public void setLunchUnits(string date, int new_sugar)
                {
                        days[date].setLunchUnits(new_sugar);
                }
                public void setSupperUnits(string date, int new_sugar)
                {
                        days[date].setSupperUnits(new_sugar);
                }
                public void setBedLantis(string date, int new_sugar)
                {
                        days[date].setBedLantis(new_sugar);
                }
                public void setBedUnits(string date, int new_sugar)
                {
                        days[date].setBedUnits(new_sugar);
                }

                //adder methods
                public void addDay(string date, Meal breakfast, Meal lunch, Meal supper, Meal bedtime)
                {
                        dates[total_days] = date;

                        Day new_day = new Day(breakfast, lunch, supper, bedtime);
                        days[date] = new_day;

                        total_days++;
                }
                public void addDay(string date)
                {
                        dates[total_days] = date;

                        Day new_day = new Day();
                        days[date] = new_day;

                        total_days++;
                }

                private int Parse_Int(string number)
                {
                        int num = 0;
                        int flag = 1;   //num will be multiplied by this at end to make it a negative or positive number depending on what 'number' is

                        if (number.Length == 0)
                        {
                                return 0;       //no data
                        }

                        if (number[0] == '-')
                        {
                                //could be a negative number
                                if (number.Length > 1)
                                {
                                        //remove the '-' sign at the beginning to see if rest of the string is a number
                                        number = number.Substring(1);
                                        flag = -1;
                                }
                                //not a negative number
                                else
                                {
                                        return 0;
                                }
                        }

                        for (int c = 0; c < number.Length; c++)
                        {
                                int cur_num = number[c] - '0';

                                if (cur_num >= 0 && cur_num <= 9)
                                {
                                        num *= 10;
                                        num += cur_num;
                                }
                        }

                        num *= flag;    //invert if negative, multiply by 1 if positive (flag = 1 or -1 depending on if '-' was found at the start)

                        return num;
                }
                
                private string getIntArrayString(intArray data)
                {
                        string theStr = "";

                        //if the list is empty, then return an empty string
                        if (data.getCount() == 0)
                        {
                                return "";
                        }

                        for (int x = 0; x < data.getCount() - 1; x++)
                        {
                                theStr += data.getData(x) + " ";
                        }

                        //add the last number to the string
                        theStr += data.getData(data.getCount() - 1);

                        return theStr;
                }

                private double getCertainAverage(string meal, string time, int[] numberAmounts, bool notSugar)
                {
                        //int[] sugarAmounts = sugar.getData();
                        int sum = 0;
                        int startIndex = 1;     //not 0 based, this is the starting day to get numbers from for the average
                        int col = 0;
                        int indexBreakLastDay;
                        int daysBack;
                        int incrementBy = 4;
                        double avg;
                        double count = 0;

                        if (notSugar)
                        {
                                incrementBy = 5;
                        }

                        //get the col value depending on the meal selected
                        if (meal == "Meals_Breakfast_RadioButton")
                        {
                                col = 0;
                        }
                        else if (meal == "Meals_Lunch_RadioButton")
                        {
                                col = 1;
                        }
                        else if (meal == "Meals_Sup_RadioButton")
                        {
                                col = 2;
                        }
                        else if (meal == "Meals_Bed_RadioButton")
                        {
                                col = 3;
                        }
                        else    //else if all
                        {
                                incrementBy = 1;
                        }

                        indexBreakLastDay = Convert.ToInt32(numberAmounts.Length / 4) + 1;       //starts at day 1, not 0 based

                        //get the number of days to go back to get the average
                        if (time == "Time_Week_RadioButton")
                        {
                                //if there is at least 7 days, then start taking the averages from there
                                if (indexBreakLastDay >= 7)
                                {
                                        daysBack = 7;
                                }
                                //otherwise just set the daysback equal to the number of days
                                else
                                {
                                        daysBack = indexBreakLastDay;
                                }
                        }
                        else if (time == "Time_Month_RadioButton")
                        {
                                //if there is at least 30 days, then start taking the averages from there
                                if (indexBreakLastDay >= 30)
                                {
                                        daysBack = 30;
                                }
                                //otherwise just set the daysback equal to the number of days
                                else
                                {
                                        daysBack = indexBreakLastDay;
                                }
                        }
                        else if (time == "Time_3Months_RadioButton")
                        {
                                //if there is at least 30 days, then start taking the averages from there
                                if (indexBreakLastDay >= 90)
                                {
                                        daysBack = 90;
                                }
                                //otherwise just set the daysback equal to the number of days
                                else
                                {
                                        daysBack = indexBreakLastDay;
                                }
                        }
                        else if (time == "Time_Year_RadioButton")
                        {
                                //if there is at least 365 days, then start taking the averages from there
                                if (indexBreakLastDay >= 365)
                                {
                                        daysBack = 365;
                                }
                                //otherwise just set the daysback equal to the number of days
                                else
                                {
                                        daysBack = indexBreakLastDay;
                                }
                        }
                        else
                        {
                                daysBack = indexBreakLastDay;   //this is also the number of days total, so we can use it to go back to the dawn of time
                        }

                        //get the ending index of where we want to stop depending on the 'time' selected
                        startIndex = indexBreakLastDay - daysBack;    //lastday - daysback = the starting day to get sugar for average

                        //I dont need this?
                        //startIndex--;   //now startindex is 0 based and is on the day to start getting the sugar for average

                        //get the sugar sum
                        for (int x = startIndex * 4 + col; (x < indexBreakLastDay * 4) && (x < numberAmounts.Length); x += incrementBy)
                        {
                                //if this is for humolog, don't include bedtime extra humolog and don't include lantis
                                if (notSugar && ((x + 1) % 5 == 0 || (x + 1) % 5 == 4))
                                {
                                        continue;
                                }
                                sum += numberAmounts[x];
                                count++;
                        }

                        //no numbers to get average, so 0
                        if (count == 0)
                        {
                                return 0;
                        }

                        avg = sum / count;

                        return avg;
                }
        }
}
