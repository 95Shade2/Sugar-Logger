using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
        class Meal
        {
                int sugar;
                int units;
                int lantis;

                //initalizers, -1 represents unset
                public Meal()
                {
                        sugar = -1;
                        units = -1;
                        lantis = -1;
                }

                public Meal(int sugar)
                {
                        this.sugar = sugar;
                }

                public Meal(int sugar, int units)
                {
                        this.sugar = sugar;
                        this.units = units;
                }

                public Meal(int sugar, int units, int lantis)
                {
                        this.sugar = sugar;
                        this.units = units;
                        this.lantis = lantis;
                }

                public Meal(string meal_ini)
                {
                        string suger_str = Parse_Ini(meal_ini, "S");
                        setSugar(Parse_Int(suger_str));

                        string units_str = Parse_Ini(meal_ini, "U");
                        setUnits(Parse_Int(units_str));

                        string lantis_str = Parse_Ini(meal_ini, "L");
                        setLantis(Parse_Int(lantis_str));
                }

                //getters
                public int getSugar()
                {
                        return sugar;
                }

                public int getUnits()
                {
                        return units;
                }

                public int getLantis()
                {
                        return lantis;
                }

                //setters
                public void setSugar(int sugar)
                {
                        this.sugar = sugar;
                }

                public void setUnits(int units)
                {
                        this.units = units;
                }

                public void setLantis(int lantis)
                {
                        this.lantis = lantis;
                }


                //takes an ini string that has key=value pairs, and returns the value connected to the key passed in
                //key={any amount of data or types can be enclosed in curly brackets}
                private string Parse_Ini(string ini_data, string key)
                {
                        int start_index = ini_data.IndexOf(key);

                        //couldn't fine the key value pair
                        if (start_index == -1)
                        {
                                return "";
                        }

                        string value = ini_data.Substring(start_index);  //cutoff everything before the key=value that we are looking for (still has everything that comes after if any)

                        value = value.Substring(value.IndexOf("=") + 1);    //get passed the key to get to the value    value = WANTED_VALUE keyX=valueX ...

                        //if this is not the last pair in the list, then we need to remove the rest of them.
                        //value = everything inside the brackets, works even if the inside values have their own sets of curly brackets
                        if (value.IndexOf("=") != -1)
                        {
                                //test to see if the value is enclosed in curly brackets
                                if (value[0] == '{')
                                {
                                        int depth = 0;
                                        int ending_bracket_index = -1;

                                        for (int d = 0; d < value.Length; d++)
                                        {
                                                if (value[d] == '{')
                                                {
                                                        depth++;
                                                }
                                                else if (value[d] == '}')
                                                {
                                                        depth--;

                                                        if (depth == 0)
                                                        {
                                                                ending_bracket_index = d;
                                                                d = value.Length;
                                                        }
                                                }
                                        }

                                        value = value.Substring(1, ending_bracket_index - 1);
                                }
                                else
                                {
                                        value = value.Substring(0, value.IndexOf("="));         //value = VALUE keyX
                                        value = value.Substring(0, value.LastIndexOf(" "));        //value = VALUE         (removes the key of the next pair, leaving only the value of the key passed in)
                                }
                        }

                        return value;
                }


                private int Parse_Int(string number)
                {
                        int num = 0;
                        int flag = 1;   //num will be multiplied by this at end to make it a negative or positive number depending on what 'number' is

                        if (number.Length == 0)
                        {
                                return -1;       //no data
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
                                //not a negative number, but did start with '-'
                                else
                                {
                                        return -1;
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


        }
}
