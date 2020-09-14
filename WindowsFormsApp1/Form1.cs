using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Folder stuff
using System.IO;
using System.Collections;

namespace WindowsFormsApp1
{
        public partial class Form1 : Form
        {
                //global form for editing to allow us to be only able to edit one at a time
                EditText editingForm;
                private bool editingFormOpen;
                UserData currentUser;
                int userID;
                int currentDay;
                Dictionary<string, int> labelSugarIndex;
                bool starting;  //whether or not the app is starting. this is to stop some stuff from doing things when not wanting them to

                //for calculating the average at different times
                string mealSelected;
                string timeSelected;

                //these are for helping filling them and stuff
                //index 0 will point to DateOne_Label for example, it makes using these easier by using loops
                Dictionary<int, Label> labelDates;
                Dictionary<int, Label> labelSugar;
                Dictionary<int, Label> labelUnits;

                DateTime today_Date;    //always stores today's date
                string today_key;       //key taken from today's date for data

                //2.0 user data
                Dictionary<string, Day> Data;

                public Form1()
                {
                        today_Date = DateTime.Today;
                        today_key = today_Date.ToString().Substring(0, today_Date.ToString().IndexOf(' '));
                        InitializeComponent();
                }

                private void createFirstUser()
                {
                        //string todaysDate;

                        userID = 0;
                        currentUser = new UserData(userID, today_key, new Day());
                        //Data = new Dictionary<string, Day>();

                        setupToday();
                        //todaysDate = currentUser.getMonth().ToString() + "/" + currentUser.getDay().ToString() + "/" + currentUser.getYear();
                        DateOne_Label.Text = today_key;

                        currentDay = 1; //day 1
                }

                private void createLabelIndex()
                {
                        int index = 0;
                        labelDates = new Dictionary<int, Label>();
                        labelSugar = new Dictionary<int, Label>();
                        labelUnits = new Dictionary<int, Label>();

                        //fill up the Date list
                        labelDates.Add(index, DateOne_Label);
                        index++;
                        labelDates.Add(index, DateTwo_Label);
                        index++;
                        labelDates.Add(index, DateThree_Label);
                        index++;
                        labelDates.Add(index, DateFour_Label);
                        index++;
                        labelDates.Add(index, DateFive_Label);
                        index++;
                        labelDates.Add(index, DateSix_Label);
                        index++;
                        labelDates.Add(index, DateSeven_Label);

                        index = 0;

                        //fill up the sugar list
                        labelSugar.Add(index, SugarBreakOne_Label);
                        index++;
                        labelSugar.Add(index, SugarLunchOne_Label);
                        index++;
                        labelSugar.Add(index, SugarSupOne_Label);
                        index++;
                        labelSugar.Add(index, SugarBedOne_Label);
                        index++;
                        labelSugar.Add(index, SugarBreakTwo_Label);
                        index++;
                        labelSugar.Add(index, SugarLunchTwo_Label);
                        index++;
                        labelSugar.Add(index, SugarSupTwo_Label);
                        index++;
                        labelSugar.Add(index, SugarBedTwo_Label);
                        index++;
                        labelSugar.Add(index, SugarBreakThree_Label);
                        index++;
                        labelSugar.Add(index, SugarLunchThree_Label);
                        index++;
                        labelSugar.Add(index, SugarSupThree_Label);
                        index++;
                        labelSugar.Add(index, SugarBedThree_Label);
                        index++;
                        labelSugar.Add(index, SugarBreakFour_Label);
                        index++;
                        labelSugar.Add(index, SugarLunchFour_Label);
                        index++;
                        labelSugar.Add(index, SugarSupFour_Label);
                        index++;
                        labelSugar.Add(index, SugarBedFour_Label);
                        index++;
                        labelSugar.Add(index, SugarBreakFive_Label);
                        index++;
                        labelSugar.Add(index, SugarLunchFive_Label);
                        index++;
                        labelSugar.Add(index, SugarSupFive_Label);
                        index++;
                        labelSugar.Add(index, SugarBedFive_Label);
                        index++;
                        labelSugar.Add(index, SugarBreakSix_Label);
                        index++;
                        labelSugar.Add(index, SugarLunchSix_Label);
                        index++;
                        labelSugar.Add(index, SugarSupSix_Label);
                        index++;
                        labelSugar.Add(index, SugarBedSix_Label);
                        index++;
                        labelSugar.Add(index, SugarBreakSeven_Label);
                        index++;
                        labelSugar.Add(index, SugarLunchSeven_Label);
                        index++;
                        labelSugar.Add(index, SugarSupSeven_Label);
                        index++;
                        labelSugar.Add(index, SugarBedSeven_Label);

                        index = 0;

                        //fill up the units list
                        labelUnits.Add(index, UnitBreakOne_Label);
                        index++;
                        labelUnits.Add(index, UnitLunchOne_Label);
                        index++;
                        labelUnits.Add(index, UnitSupOne_Label);
                        index++;
                        labelUnits.Add(index, UnitBedOne_Label);
                        index++;
                        labelUnits.Add(index, LanUniOne_Label);
                        index++;
                        labelUnits.Add(index, UnitBreakTwo_Label);
                        index++;
                        labelUnits.Add(index, UnitLunchTwo_Label);
                        index++;
                        labelUnits.Add(index, UnitSupTwo_Label);
                        index++;
                        labelUnits.Add(index, UnitBedTwo_Label);
                        index++;
                        labelUnits.Add(index, LanUniTwo_Label);
                        index++;
                        labelUnits.Add(index, UnitBreakThree_Label);
                        index++;
                        labelUnits.Add(index, UnitLunchThree_Label);
                        index++;
                        labelUnits.Add(index, UnitSupThree_Label);
                        index++;
                        labelUnits.Add(index, UnitBedThree_Label);
                        index++;
                        labelUnits.Add(index, LanUniThree_Label);
                        index++;
                        labelUnits.Add(index, UnitBreakFour_Label);
                        index++;
                        labelUnits.Add(index, UnitLunchFour_Label);
                        index++;
                        labelUnits.Add(index, UnitSupFour_Label);
                        index++;
                        labelUnits.Add(index, UnitBedFour_Label);
                        index++;
                        labelUnits.Add(index, LanUniFour_Label);
                        index++;
                        labelUnits.Add(index, UnitBreakFive_Label);
                        index++;
                        labelUnits.Add(index, UnitLunchFive_Label);
                        index++;
                        labelUnits.Add(index, UnitSupFive_Label);
                        index++;
                        labelUnits.Add(index, UnitBedFive_Label);
                        index++;
                        labelUnits.Add(index, LanUniFive_Label);
                        index++;
                        labelUnits.Add(index, UnitBreakSix_Label);
                        index++;
                        labelUnits.Add(index, UnitLunchSix_Label);
                        index++;
                        labelUnits.Add(index, UnitSupSix_Label);
                        index++;
                        labelUnits.Add(index, UnitBedSix_Label);
                        index++;
                        labelUnits.Add(index, LanUniSix_Label);
                        index++;
                        labelUnits.Add(index, UnitBreakSeven_Label);
                        index++;
                        labelUnits.Add(index, UnitLunchSeven_Label);
                        index++;
                        labelUnits.Add(index, UnitSupSeven_Label);
                        index++;
                        labelUnits.Add(index, UnitBedSeven_Label);
                        index++;
                        labelUnits.Add(index, LanUniSeven_Label);
                }

                private void createSugarIndex()
                {
                        //int startIndex = currentDay * 4;
                        int startIndex = 0;
                        labelSugarIndex = new Dictionary<string, int>();
                        
                        labelSugarIndex.Add(SugarBreakOne_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBreakOne_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarLunchOne_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitLunchOne_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarSupOne_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitSupOne_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBedOne_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBedOne_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(LanUniOne_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBreakTwo_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBreakTwo_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarLunchTwo_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitLunchTwo_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarSupTwo_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitSupTwo_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBedTwo_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBedTwo_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(LanUniTwo_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBreakThree_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBreakThree_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarLunchThree_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitLunchThree_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarSupThree_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitSupThree_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBedThree_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBedThree_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(LanUniThree_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBreakFour_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBreakFour_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarLunchFour_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitLunchFour_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarSupFour_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitSupFour_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBedFour_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBedFour_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(LanUniFour_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBreakFive_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBreakFive_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarLunchFive_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitLunchFive_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarSupFive_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitSupFive_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBedFive_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBedFive_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(LanUniFive_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBreakSix_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBreakSix_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarLunchSix_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitLunchSix_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarSupSix_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitSupSix_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBedSix_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBedSix_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(LanUniSix_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBreakSeven_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBreakSeven_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarLunchSeven_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitLunchSeven_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarSupSeven_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitSupSeven_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(SugarBedSeven_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(UnitBedSeven_Label.Name, startIndex);
                        startIndex++;
                        labelSugarIndex.Add(LanUniSeven_Label.Name, startIndex);
                }

                private UserData getUserFromFile(string filename)
                {
                        return null;
                }

                private void saveUserData()
                {
                        string output = "";
                        FileStream userFile;
                        Byte[] info;
                        Dictionary<string, Day>.KeyCollection date_keys;

                        Dictionary<int, string> dates = new Dictionary<int, string>();
                        dates = currentUser.getDates();

                        //header
                        output += "version=2.0";
                        output += " id=" + userID;
                        output += " username=" + Username_TextBox.Text;
                        output += Environment.NewLine;

                        for (int k = 0; k < dates.Count; k++)
                        {
                                string Cur_Key_Date = dates[k];
                                Dictionary<string, Day> days = currentUser.getDays();

                                output += "D=" + Cur_Key_Date + " ";

                                output += "BF={S=" + days[Cur_Key_Date].getBreakfast().getSugar();
                                output += " U=" + days[Cur_Key_Date].getBreakfast().getUnits();
                                output += " L=" + days[Cur_Key_Date].getBreakfast().getLantis();

                                output += "} LN={S=" + days[Cur_Key_Date].getLunch().getSugar();
                                output += " U=" + days[Cur_Key_Date].getLunch().getUnits();
                                output += " L=" + days[Cur_Key_Date].getLunch().getLantis();

                                output += "} SP={S=" + days[Cur_Key_Date].getSupper().getSugar();
                                output += " U=" + days[Cur_Key_Date].getSupper().getUnits();
                                output += " L=" + days[Cur_Key_Date].getSupper().getLantis();

                                output += "} BT={S=" + days[Cur_Key_Date].getBed().getSugar();
                                output += " U=" + days[Cur_Key_Date].getBed().getUnits();
                                output += " L=" + days[Cur_Key_Date].getBed().getLantis();

                                output += "}" + Environment.NewLine;
                        }

                        info = new UTF8Encoding(true).GetBytes(output);
                        File.Delete("users/user_" + userID.ToString() + ".txt");        //this is becuase the write is like an insert, it literally writes over each bytes with a new one. So if there was more text in the file than we're writing, then the end of the old file would still be there
                        userFile = File.OpenWrite("users/user_" + userID.ToString() + ".txt");
                        userFile.Write(info, 0, info.Length);
                        userFile.Close();

                        return;

                        /*
                        output = "name: " + currentUser.getName() + Environment.NewLine;
                        output += "months: " + currentUser.getMonthString() + Environment.NewLine;
                        output += "days: " + currentUser.getDayString() + Environment.NewLine;
                        output += "years: " + currentUser.getYearString() + Environment.NewLine;
                        output += "weekDays: " + currentUser.getWeekDayString() + Environment.NewLine;
                        output += "sugar: " + currentUser.getSugarString() + Environment.NewLine;
                        output += "units: " + currentUser.getUnitsString() + Environment.NewLine;

                        info = new UTF8Encoding(true).GetBytes(output);
                        File.Delete("users/user_" + userID.ToString() + ".txt");        //this is becuase the write is like an insert, it literally writes over each bytes with a new one. So if there was more text in the file than we're writing, then the end of the old file would still be there
                        userFile = File.OpenWrite("users/user_" + userID.ToString() + ".txt");
                        userFile.Write(info, 0, info.Length);
                        userFile.Close();
                        */
                }

                private UserData openUserData(string userID)
                {
                        //v2.0
                        UserData user = new UserData(Parse_Int(userID));
                        string input = "";
                        FileStream userFile;
                        Byte[] info;
                        int fileSize;
                        Dictionary<int, string> lines = new Dictionary<int, string>();
                        
                        //get the data from file
                        userFile = File.OpenRead("users/user_" + userID + ".txt");
                        fileSize = Convert.ToInt32(userFile.Length);
                        info = new Byte[fileSize];
                        userFile.Read(info, 0, fileSize);
                        userFile.Close();

                        //convert the file data from bytes into a string
                        for (int x = 0; x < fileSize; x++)
                        {
                                input += Convert.ToChar(info[x]).ToString();
                        }

                        while (input.IndexOf(Environment.NewLine) != -1)
                        {
                                lines[lines.Count] = input.Substring(0, input.IndexOf(Environment.NewLine));
                                input = input.Substring(input.IndexOf(Environment.NewLine)+2);
                        }

                        //line 1 = data, every other line is an entry for a day
                        //"name: NAME" means this file is the old format, and needs to be converted
                        //      version         file saved format
                        //      username            custom user's name
                        string data = lines[0];
                        string version;
                        string username;
                        string id;

                        //if this file is the old format
                        if (data.Substring(0, 5) == "name:")
                        {
                                //convert file format from 1.0 to 2.0
                                //return running this function again to process data in new format
                        }
                        else
                        {
                                version = Parse_Ini(data, "version");
                                username = Parse_Ini(data, "username");
                                id = Parse_Ini(data, "id");

                                user.setUsername(username);
                        }

                        for (int l = 1; l < lines.Count; l++)
                        {
                                string line = lines[l];

                                //reached end of file
                                if (line == "")
                                {
                                        break;
                                }

                                /*
                                string date = line.Substring(line.IndexOf("D=") + 2, line.IndexOf(' ') - line.IndexOf("D=") - 2);
                                string breakfast = line.Substring(line.IndexOf("BF={") + 4, line.IndexOf('}') - line.IndexOf("BF={") - 4);
                                string lunch = line.Substring(line.IndexOf("LN={") + 4, line.IndexOf("} SP") - line.IndexOf("LN={") - 4);
                                string supper = line.Substring(line.IndexOf("SP={") + 4, line.IndexOf("} BT") - line.IndexOf("SP={") - 4);
                                string bedtime = line.Substring(line.IndexOf("BT={") + 4, line.Length - line.IndexOf("BT={") - 5);
                                */

                                string date = Parse_Ini(line, "D");
                                string breakfast = Parse_Ini(line, "BF");
                                string lunch = Parse_Ini(line, "LN");
                                string supper = Parse_Ini(line, "SP");
                                string bedtime = Parse_Ini(line, "BT");

                                Meal bratkfast_meal = new Meal(breakfast);
                                Meal lunch_meal = new Meal(lunch);
                                Meal supper_meal = new Meal(supper);
                                Meal bedtime_meal = new Meal(bedtime);

                                user.addDay(date, bratkfast_meal, lunch_meal, supper_meal, bedtime_meal);
                        }

                        return user;

                        /*v1.0
                        string input = "";
                        FileStream userFile;
                        Byte[] info;
                        int fileSize;
                        int index = 0;
                        int startUsername = 6;  //The starting index of the username from the file
                        int startMonths = 8; //the starting index of the actual months after the months title on the line
                        int startDays = 6;  //the starting index of the actual days
                        int startYears = 7;  //the starting index of the years
                        int startWeekDay = 10;  //the starting index of the weekDays
                        int startSugar = 7;  //the starting index of the sugar
                        int startUnits = 7;  //the starting index of the units
                        UserData user = new UserData();
                        string username;
                        string line;
                        string dataAsString;
                        string[] dataAsArray;
                        
                        //get the data from file
                        userFile = File.OpenRead("users/user_" + userID + ".txt");
                        fileSize = Convert.ToInt32(userFile.Length);
                        info = new Byte[fileSize];
                        userFile.Read(info, 0, fileSize);
                        userFile.Close();

                        //convert the file data from bytes into a string
                        for (int x = 0; x < fileSize; x++)
                        {
                                input += Convert.ToChar(info[x]).ToString();
                        }

                        input = removeAll(input, '\r');

                        //get the user's username
                        username = input.Substring(startUsername);
                        index = username.IndexOf("\n");
                        line = username.Substring(index + 1);  //go ahead and get next line here
                        username = username.Remove(index);

                        //add the username to 'user'
                        user.setName(username);

                        //get the months
                        index = line.IndexOf('\n');
                        dataAsString = line.Remove(index);
                        line = line.Substring(index + 1);   //go ahead and get the next line here
                        dataAsString = dataAsString.Substring(startMonths);
                        dataAsArray = dataAsString.Split(' ');

                        //add the months to 'user'
                        for (int x = 0; x < dataAsArray.Length; x++)
                        {
                                user.addMonth(Convert.ToInt32(dataAsArray[x]));
                        }

                        //get the days
                        index = line.IndexOf('\n');
                        dataAsString = line.Remove(index);
                        line = line.Substring(index + 1);   //go ahead and get the next line here
                        dataAsString = dataAsString.Substring(startDays);
                        dataAsArray = dataAsString.Split(' ');

                        //add the days to 'user'
                        for (int x = 0; x < dataAsArray.Length; x++)
                        {
                                user.addDay(Convert.ToInt32(dataAsArray[x]));
                        }

                        //get the years
                        index = line.IndexOf('\n');
                        dataAsString = line.Remove(index);
                        line = line.Substring(index + 1);   //go ahead and get the next line here
                        dataAsString = dataAsString.Substring(startYears);
                        dataAsArray = dataAsString.Split(' ');

                        //add the years to 'user'
                        for (int x = 0; x < dataAsArray.Length; x++)
                        {
                                user.addYear(Convert.ToInt32(dataAsArray[x]));
                        }

                        //get the weekDays
                        index = line.IndexOf('\n');
                        dataAsString = line.Remove(index);
                        line = line.Substring(index + 1);   //go ahead and get the next line here
                        dataAsString = dataAsString.Substring(startWeekDay);
                        dataAsArray = dataAsString.Split(' ');

                        //add the weekDays to 'user'
                        for (int x = 0; x < dataAsArray.Length; x++)
                        {
                                user.addWeekDay(Convert.ToInt32(dataAsArray[x]));
                        }

                        //get the sugar
                        index = line.IndexOf('\n');
                        dataAsString = line.Remove(index);
                        line = line.Substring(index + 1);   //go ahead and get the next line here
                        dataAsString = dataAsString.Substring(startSugar);
                        dataAsArray = dataAsString.Split(' ');

                        //add the sugar to 'user'
                        for (int x = 0; x < dataAsArray.Length; x++)
                        {
                                user.addSugar(Convert.ToInt32(dataAsArray[x]));
                        }

                        //get the units
                        index = line.IndexOf('\n');
                        dataAsString = line.Remove(index);
                        line = line.Substring(index + 1);   //go ahead and get the next line here
                        dataAsString = dataAsString.Substring(startUnits);
                        dataAsArray = dataAsString.Split(' ');

                        //add the units to 'user'
                        for (int x = 0; x < dataAsArray.Length; x++)
                        {
                                user.addUnits(Convert.ToInt32(dataAsArray[x]));
                        }

                        return user;*/
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

                //removes all instances of a char from a string
                private string removeAll(string text, char value)
                {
                        int index;

                        index = text.IndexOf(value);
                        while (index != -1)
                        {
                                //remove the current char from the string
                                text = text.Remove(index, 1);

                                //get index of next char if any
                                index = text.IndexOf(value);
                        }

                        return text;
                }

                private bool Future_Day(object sender)
                {
                        int last_day = currentUser.getTotalDays();

                        Label Label_Object = ((Label)sender);
                        int Label_Index = Get_Index(labelSugar, Label_Object);

                        if (Label_Index == -1)
                        {
                                Label_Index = Get_Index(labelUnits, Label_Object);

                                //the box selected is in the future (units)
                                if (last_day - 1 < Label_Index / 5)
                                {
                                        return true;
                                }
                                //the box selected is today or a previous day
                                else
                                {
                                        return false;
                                }
                        }
                        else
                        {
                                //the box selected is in the future (sugars)
                                if (last_day - 1 < Label_Index / 4)
                                {
                                        return true;
                                }
                                //the box selected is today or a previous day
                                else
                                {
                                        return false;
                                }
                        }
                        
                }

                private int Get_Index(Dictionary<int, Label> dict, Label Obj)
                {
                        for (int i = 0; i < dict.Count; i++)
                        {
                                Label Cur_Label = dict[i];

                                if (Cur_Label.Name == Obj.Name)
                                {
                                        return i;
                                }
                        }

                        return -1;
                }

                private void SugarBreakOne_Label_Click(object sender, EventArgs e)
                {
                        //If the editing form is already open then the user is alreayd editing one, so don't open another
                        //or if the user has not been using this for 7 days, and clicks on a 'future' section
                        if (editingFormOpen || Future_Day(sender))
                        {
                                return;
                        }
                        editingFormOpen = true;

                        //get the text from the one sending it
                        string text = ((Label)sender).Text;
                        editingForm = new EditText();

                        //show the editing text form
                        editingForm.Show();

                        //make it where we can only edit one at a time

                        //put the text in the new form's textbox
                        editingForm.NewText_TextBox.Text = text;
                        editingForm.updatedText = text;
                        editingForm.NewText_TextBox.Select(editingForm.NewText_TextBox.Text.Length, 0);

                        //let the new form know which one to change when confirmed
                        editingForm.textEdited = sender;

                        //Change the background color of the label editing
                        ((Label)sender).BackColor = Color.DarkGreen;
                }

                //label text changed (when the text editor edits a text)
                private void SugarLunchOne_Label_TextChanged(object sender, EventArgs e)
                {
                        //if the app is starting, then do nothing
                        if (starting)
                        {
                                return;
                        }

                        ((Label)sender).BackColor = Color.Transparent;
                        editingForm = new EditText();
                        editingFormOpen = false;
                        //if this was the last part of the text change, then save the user
                        if (((Label)sender).Text != "a")
                        {
                                updateUserData(sender);
                                saveUserData();
                        }
                }

                private string getWeekDay(int index)
                {
                        return "Unknown";
                }

                private void colorLabel(Label theLabel)
                {
                        int sugar;

                        if (theLabel.Text == "")
                        {
                                sugar = 0;
                        }
                        else
                        {
                                sugar = Convert.ToInt32(theLabel.Text);
                        }

                        //sugar is in range
                        if (sugar >= 90 && sugar <= 130)
                        {
                                theLabel.ForeColor = Color.Green;
                        }
                        else
                        {
                                //suger is high
                                if (sugar > 130)
                                {
                                        double bad = 500;
                                        double perc = sugar / bad + 0.25;
                                        int dec = (int)(perc * 255);

                                        int red = dec;
                                        if (red > 255)
                                        {
                                                red = 255;
                                        }

                                        int green = 0;
                                        int blue = 0;
                                        
                                        Color sugar_color = Rgb_Color(red, green, blue);

                                        theLabel.ForeColor = sugar_color;
                                }
                                //sugar is low
                                else
                                {
                                        double good = 90;
                                        double perc = 1.33 - (sugar / good);
                                        int max_blue = 180;
                                        int dec = (int)(perc * max_blue);

                                        int blue = dec;
                                        if (blue > max_blue)
                                        {
                                                blue = max_blue;
                                        }

                                        int green = blue;
                                        int red = 0;

                                        Color sugar_color = Rgb_Color(red, green, blue);

                                        theLabel.ForeColor = sugar_color;
                                }
                        }

                        return;

                        //1.0

                        if (sugar > 130)
                        {
                                if (sugar > 200)
                                {
                                        if (sugar > 300)
                                        {
                                                theLabel.ForeColor = Color.Red;
                                        }
                                        else
                                        {
                                                theLabel.ForeColor = Color.Maroon;
                                        }
                                }
                                else
                                {
                                        theLabel.ForeColor = Color.Brown;
                                }
                        }
                        else if (sugar < 90)
                        {
                                theLabel.ForeColor = Color.DeepSkyBlue;
                        }
                        else
                        {
                                theLabel.ForeColor = Color.Green;
                        }
                }

                private Color Rgb_Color(int red, int green, int blue)
                {
                        int color;

                        color = (red << 16) | (green << 8) | blue;

                        return Color.FromArgb(color);
                }

                private void Clear_Display()
                {
                        bool was_starting = starting;
                        starting = true;

                        //clear each date
                        for (int d = 0; d < labelDates.Count; d++)
                        {
                                labelDates[d].Text = "";
                        }

                        //clear each sugar
                        for (int s = 0; s < labelSugar.Count; s++)
                        {
                                labelSugar[s].Text = "";
                        }

                        //clear each unit
                        for (int u = 0; u < labelUnits.Count; u++)
                        {
                                labelUnits[u].Text = "";
                        }

                        starting = was_starting;
                }

                private void displayUser()
                {
                        bool was_starting = starting;
                        starting = true;

                        Clear_Display();

                        //display the last 7 days on the list
                        int cur_date = 0;
                        int start_user_date = currentDay - 7;
                        int end_user_date = currentDay;

                        //enable or disable the top button
                        if (start_user_date <= 0)
                        {
                                start_user_date = 0;
                                GoBackDay_Button.Enabled = false;
                        }
                        else
                        {
                                GoBackDay_Button.Enabled = true;
                        }

                        //enable or disable the bottom button
                        if (start_user_date + 7 < currentUser.getTotalDays())
                        {
                                GoForwardDay_Button.Enabled = true;
                        }
                        else
                        {
                                GoForwardDay_Button.Enabled = false;
                        }

                        while (start_user_date < currentDay)
                        {
                                //date
                                string date_str = currentUser.getDate(start_user_date);
                                labelDates[cur_date].Text = date_str;
                                
                                int suger_row = cur_date * 4;
                                int unit_row = cur_date * 5;

                                //breafkast
                                //suger
                                string suger_str = currentUser.getBreakfast(date_str).getSugar().ToString();
                                if (suger_str != "-1")  //leave blank if value wasn't set
                                {
                                        labelSugar[suger_row].Text = suger_str;
                                        colorLabel(labelSugar[suger_row]);
                                }
                                //units
                                string units_str = currentUser.getBreakfast(date_str).getUnits().ToString();
                                if (units_str != "-1")  //leave blank if value wasn't set
                                {
                                        labelUnits[unit_row].Text = units_str;
                                }

                                //lunch
                                //suger
                                suger_str = currentUser.getLunch(date_str).getSugar().ToString();
                                if (suger_str != "-1")  //leave blank if value wasn't set
                                {
                                        labelSugar[suger_row + 1].Text = suger_str;
                                        colorLabel(labelSugar[suger_row + 1]);
                                }
                                //units
                                units_str = currentUser.getLunch(date_str).getUnits().ToString();
                                if (units_str != "-1")  //leave blank if value wasn't set
                                {
                                        labelUnits[unit_row + 1].Text = units_str;
                                }

                                //supper
                                //suger
                                suger_str = currentUser.getSupper(date_str).getSugar().ToString();
                                if (suger_str != "-1")  //leave blank if value wasn't set
                                {
                                        labelSugar[suger_row + 2].Text = suger_str;
                                        colorLabel(labelSugar[suger_row + 2]);
                                }
                                //units
                                units_str = currentUser.getSupper(date_str).getUnits().ToString();
                                if (units_str != "-1")  //leave blank if value wasn't set
                                {
                                        labelUnits[unit_row + 2].Text = units_str;
                                }

                                //bedtime
                                //suger
                                suger_str = currentUser.getBed(date_str).getSugar().ToString();
                                if (suger_str != "-1")  //leave blank if value wasn't set
                                {
                                        labelSugar[suger_row + 3].Text = suger_str;
                                        colorLabel(labelSugar[suger_row + 3]);
                                }
                                //units
                                units_str = currentUser.getBed(date_str).getUnits().ToString();
                                if (units_str != "-1")  //leave blank if value wasn't set
                                {
                                        labelUnits[unit_row + 3].Text = units_str;
                                }
                                //lantis
                                units_str = currentUser.getBed(date_str).getLantis().ToString();
                                if (units_str != "-1")  //leave blank if value wasn't set
                                {
                                        labelUnits[unit_row + 4].Text = units_str;
                                }
                                
                                start_user_date++;
                                cur_date++;
                        }

                        Username_TextBox.Text = currentUser.getUsername();
                        Username_TextBox.Select(0, 0);

                        starting = was_starting;
                }

                private void Form1_Load(object sender, EventArgs e)
                {
                        string defaultUser = "users/user_0.txt";
                        string defualtID = "0";
                        string[] userFiles;
                        DateTime now = DateTime.Today;

                        Data = new Dictionary<string, Day>();

                        editingFormOpen = false;
                        createLabelIndex();
                        starting = true;

                        //for calculating averages at different times
                        mealSelected = "All";
                        timeSelected = "All";

                        //if there is a directory for users, 
                        if (Directory.Exists("users"))
                        {
                                //if there is at least one user
                                if (File.Exists(defaultUser))
                                {
                                        //gets the amount of users by counting the number of files under the folder 'user', hasnit used this for anything yet
                                        userFiles = Directory.GetFiles("users");

                                        //make the currentUser the default user from the folder (user_0)
                                        currentUser = openUserData(defualtID);

                                        //make the current day the total number of days
                                        currentDay = currentUser.getTotalDays();
                                        string last_date = currentUser.getLastDate();
                                        string todays_date = now.ToShortDateString();

                                        //get todays date if it's a different day
                                        if (todays_date != last_date)
                                        {
                                                //then add today's date to the date list
                                                setupToday();
                                                currentDay = currentUser.getTotalDays();        //update the current day
                                        }

                                        //setup the display with the sugar and units
                                        displayUser();
                                }

                                //if there is no users at all, create a new one
                                else
                                {
                                        createFirstUser();
                                }
                        }

                        //if there is no directory for users, then make one
                        else
                        {
                                Directory.CreateDirectory("users");

                                createFirstUser();
                                
                        }

                        createSugarIndex();

                        starting = false;

                        updateSugarAverage();
                        updateUnitsAverage();
                        updateLantisAverage();
                }

                private void setupToday()
                {
                        DateTime today_date = DateTime.Today;
                        DateTime cur_date = today_Date;
                        string last_day_saved = currentUser.getLastDate();
                        
                        //go back one day at a time until reaching the last date saved
                        while (cur_date.ToShortDateString() != last_day_saved)
                        {
                                cur_date = cur_date.Add(new TimeSpan(-864000000000)); //go back one day
                        }
                        
                        while (cur_date != today_date)
                        {
                                cur_date = cur_date.Add(new TimeSpan(864000000000)); //go forward one day

                                currentUser.addDay(cur_date.ToShortDateString());
                        }

                        /*      this was for v1.0
                        //gets the current and store it in now
                        DateTime now = DateTime.Today;
                        DateTime test = DateTime.Today;
                        int y = test.Year;
                        int m = test.Month;
                        int days_in_month = DateTime.DaysInMonth(y, m);
                        //test.Subtract(new DateTime(864000000000));       //one day to nanoseconds divided by 100.
                        test = test.Add(new TimeSpan(-864000000000));

                        currentUser.addMonth(now.Month);
                        currentUser.addDay(now.Day);
                        currentUser.addYear(now.Year);
                        currentUser.addWeekDay((int)now.DayOfWeek);
                        */
                }

                private void BreakOne_Table_Paint(object sender, PaintEventArgs e)
                {
                        
                }

                private void BreakOne_Table_Click(object sender, EventArgs e)
                {
                        
                }

                private void TableDate_Table_Paint(object sender, PaintEventArgs e)
                {

                }

                private void tableLayoutPanel25_Paint(object sender, PaintEventArgs e)
                {

                }

                private void label60_Click(object sender, EventArgs e)
                {

                }

                private bool isNaN(string text)
                {
                        for (int i = 0; i < text.Length; i++)
                        {
                                char letter = text[i];  //get the current character
                                int test = letter - '0';        //remove the 

                                if (test > 9)
                                {
                                        return true;
                                }
                        }

                        return false;
                }

                private int String_To_Int(string number)
                {       
                        //the user passed in not a number, so return 0 and let the user know this happened
                        if (isNaN(number))
                        {
                                MessageBox.Show(number + " is not a number");
                                return 0;
                        }
                        else
                        {
                                int num = 0;

                                for (int i = 0; i < number.Length; i++)
                                {
                                        num *= 10;      //push the previous number one tens place over
                                        num += (number[i] - '0');       //add the next number
                                }

                                return num;
                        }
                }
                
                private void updateUserData(object sender)
                {
                        Label Box = ((Label)sender);
                        int index = labelSugarIndex[Box.Name];
                        int row = index / 9;
                        int newAmount;
                        string row_date = labelDates[row].Text;
                        //int startingSugar = (currentDay - 7) * 4;
                        //int startingUnits = (currentDay - 7) * 5;


                        //make sure starting sugar and starting units don't go below 0
                        /*
                        if (startingSugar < 0)
                        {
                                startingSugar = 0;
                        }
                        if (startingUnits < 0)
                        {
                                startingUnits = 0;
                        }

                        if (((Label)sender).Text == "")
                        {
                                newSugar = 0;
                        }
                        else
                        {
                                newSugar = Convert.ToInt32(((Label)sender).Text);
                        }*/

                        newAmount = Parse_Int(Box.Text);

                        //set the sugar for the correspounding sugar
                        if (Box.Name.Contains("Sugar"))
                        {
                                if (Box.Name.Contains("Break"))
                                {
                                        currentUser.setBreakfastSugar(row_date, newAmount);
                                }
                                else if (Box.Name.Contains("Lunch"))
                                {
                                        currentUser.setLunchSugar(row_date, newAmount);
                                }
                                else if (Box.Name.Contains("Sup"))
                                {
                                        currentUser.setSupperSugar(row_date, newAmount);
                                }
                                else
                                {
                                        currentUser.setBedSugar(row_date, newAmount);
                                }

                                updateSugarAverage();
                                colorLabel((Label)sender);
                        }
                        else
                        {
                                if (Box.Name.Contains("Break"))
                                {
                                        currentUser.setBreakfastUnits(row_date, newAmount);
                                        //Data[today_key].getBreakfast().setUnits(newSugar);
                                }
                                else if (Box.Name.Contains("Lunch"))
                                {
                                        currentUser.setLunchUnits(row_date, newAmount);
                                        //Data[today_key].getLunch().setUnits(newSugar);
                                }
                                else if (Box.Name.Contains("Sup"))
                                {
                                        currentUser.setSupperUnits(row_date, newAmount);
                                        //Data[today_key].getSupper().setUnits(newSugar);
                                }
                                else if (Box.Name.Contains("Lan"))
                                {
                                        currentUser.setBedLantis(row_date, newAmount);
                                        //Data[today_key].getBed().setLantis(newSugar);
                                }
                                else
                                {
                                        currentUser.setBedUnits(row_date, newAmount);
                                        //Data[today_key].getBed().setUnits(newSugar);
                                }

                                updateUnitsAverage();
                                updateLantisAverage();
                        }

                        if (Box.Text == "-1")
                        {
                                //change -1 to nothing and do not run the event function
                                starting = true;
                                Box.Text = "";
                                starting = false;
                        }
                        
                        return;
                        /*
                        //edited sugar
                        if (((Label)sender).Name.Contains("Sugar"))
                        {
                                sugarCount = Convert.ToInt32(index / 2.25);

                                //round up if it has .5 (it doesnt round up, always down)
                                if (index % 2.25 == 1)
                                {
                                        sugarCount++;
                                }

                                //if the textbox was empty
                                if (((Label)sender).Text == "")
                                {
                                        //if this was the last sugar from the array in the grid, then that means he or she is erasing the entry
                                        if (currentUser.getSugar().Count() - 1 - startingSugar == sugarCount)
                                        {
                                                currentUser.removeSugar(sugarCount + startingSugar);
                                                starting = true;        //we just want to clear the textbox, so this wil stop other things from happening
                                                ((Label)sender).Text = "";
                                                starting = false;
                                                updateSugarAverage();
                                        }
                                        return;
                                }

                                //if a sugar was changed that was alraedy in the list
                                if (currentUser.getSugar().Count() - startingSugar > sugarCount)
                                {
                                        currentUser.setSugar(sugarCount + startingSugar, newSugar);
                                }
                                else
                                {
                                        //zero out up from last sugar added to the desired sugar to add
                                        for (int x = currentUser.getSugar().Count() - startingSugar; x < sugarCount; x++)
                                        {
                                                currentUser.addSugar(0);
                                        }

                                        //add the new sugar
                                        currentUser.addSugar(newSugar);
                                }
                                colorLabel((Label)sender);
                                //updateSugarAverage(); - changing it to make it update with week correctly
                                updateAverages();
                        }
                        //edited unit
                        else
                        {
                                //take away one cause the array starts at 0 but this formula makes the index start at 1.
                                unitCount = Convert.ToInt32(index / 1.77) - 1;

                                //if the textbox was empty
                                if (((Label)sender).Text == "")
                                {
                                        //if this was the last sugar from the array in the grid, then that means he or she is erasing the entry
                                        if (currentUser.getUnits().Count() - 1 - startingUnits == unitCount)
                                        {
                                                currentUser.removeUnit(unitCount + startingUnits);
                                                starting = true;        //we just want to clear the textbox, so this wil stop other things from happening
                                                ((Label)sender).Text = "";
                                                starting = false;
                                        }
                                        return;
                                }

                                //if a unit was changed that was alraedy in the list
                                if (currentUser.getUnits().Count() - startingUnits > unitCount)
                                {
                                        currentUser.setUnit(unitCount + startingUnits, newSugar);
                                        updateAverages();
                                }
                                else
                                {
                                        //zero out up from last sugar added to the desired sugar to add
                                        for (int x = currentUser.getUnits().Count() - startingUnits; x < unitCount; x++)
                                        {
                                                currentUser.addUnits(0);
                                        }

                                        //add the new sugar
                                        currentUser.addUnits(newSugar);
                                }
                                
                                //if a unit was edited that wasn't lantis, then update the units average
                                if (((unitCount + 1) % 5) != 0)
                                {
                                        //updateUnitsAverage(); - old code, possibly made the average not update correctly when selecting week and changing a unit
                                        updateAverages();
                                }
                        }*/
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

                private void UpdateAverage(string type)
                {
                        double avg = 0;
                        int daysBack = -1;
                        //int indexBreakLastDay = Data.Keys.Count;        //the number of days the user has recorded his or her sugar
                        int indexBreakLastDay = currentUser.getTotalDays();     //the number of days the user has recorded his or her sugar
                        int meal = -1;

                        //get the meal
                        if (mealSelected == "Meals_Breakfast_RadioButton")
                        {
                                meal = 0;
                        }
                        else if (mealSelected == "Meals_Lunch_RadioButton")
                        {
                                meal = 1;
                        }
                        else if (mealSelected == "Meals_Sup_RadioButton")
                        {
                                meal = 2;
                        }
                        else if (mealSelected == "Meals_Bed_RadioButton")
                        {
                                meal = 3;
                        }
                        else    //else if all
                        {
                                meal = -1;
                        }


                        //get the number of days to go back to get the average
                        if (timeSelected == "Time_Week_RadioButton")
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
                        else if (timeSelected == "Time_Month_RadioButton")
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
                        else if (timeSelected == "Time_3Months_RadioButton")
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
                        else if (timeSelected == "Time_Year_RadioButton")
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

                        avg = GetAverage(meal, daysBack, type);

                        if (type == "sugar")
                        {
                                AverageSugar_Label.Text = avg.ToString();
                                colorLabel(AverageSugar_Label);
                        }
                        else if (type == "units")
                        {
                                AverageUnits_Label.Text = avg.ToString();
                        }
                        else
                        {
                                AverageLantis_Label.Text = avg.ToString();
                        }
                }

                private void updateSugarAverage()
                {
                        UpdateAverage("sugar");
                }

                private double GetAverage(int meal, int days, string type)
                {
                        double avg = 0;
                        int count = 0;
                        int total = 0;
                        int int_avg;

                        //days should never be -1
                        if (days == -1)
                        {
                                return 0;
                        }

                        //Dictionary<string, Day>.KeyCollection Data_Keys_Reverse = Data.Keys;    //get the keys for the days
                        //Data_Keys_Reverse.Reverse();    //reverse the keys so we can get the average of the last x days
                        Dictionary<int, string> dates = currentUser.getDates(); //get the list of all stored days

                        for (int d = dates.Count-1; d >= dates.Count - days; d--)
                        {
                                //string cur_date = dates.ElementAt(d);
                                string cur_date = dates[d];

                                //meal = -1 means every meal

                                if (meal == 0 || meal == -1)
                                {
                                        int sugar = -1;

                                        if (type == "sugar")
                                        {
                                                //sugar = Data[cur_date].getBreakfast().getSugar();
                                                sugar = currentUser.getDays()[cur_date].getBreakfast().getSugar();
                                        }
                                        else if (type == "units")
                                        {
                                                //sugar = Data[cur_date].getBreakfast().getUnits();
                                                sugar = currentUser.getDays()[cur_date].getBreakfast().getUnits();
                                        }
                                        else
                                        {
                                                //sugar = Data[cur_date].getBreakfast().getLantis();
                                                sugar = currentUser.getDays()[cur_date].getBreakfast().getLantis();
                                        }

                                        //if the user has input the breakfast for this day, then add it for the average
                                        if (sugar != -1)
                                        {
                                                total += sugar;
                                                count++;
                                        }
                                }

                                if (meal == 1 || meal == -1)
                                {
                                        int sugar = -1;

                                        if (type == "sugar")
                                        {
                                                //sugar = Data[cur_date].getLunch().getSugar();
                                                sugar = currentUser.getDays()[cur_date].getLunch().getSugar();
                                        }
                                        else if (type == "units")
                                        {
                                                //sugar = Data[cur_date].getLunch().getUnits();
                                                sugar = currentUser.getDays()[cur_date].getLunch().getUnits();
                                        }
                                        else
                                        {
                                                //sugar = Data[cur_date].getLunch().getLantis();
                                                sugar = currentUser.getDays()[cur_date].getLunch().getLantis();
                                        }

                                        //if the user has input the breakfast for this day, then add it for the average
                                        if (sugar != -1)
                                        {
                                                total += sugar;
                                                count++;
                                        }
                                }

                                if (meal == 2 || meal == -1)
                                {
                                        int sugar = -1;

                                        if (type == "sugar")
                                        {
                                                //sugar = Data[cur_date].getSupper().getSugar();
                                                sugar = currentUser.getDays()[cur_date].getSupper().getSugar();
                                        }
                                        else if (type == "units")
                                        {
                                                //sugar = Data[cur_date].getSupper().getUnits();
                                                sugar = currentUser.getDays()[cur_date].getSupper().getUnits();
                                        }
                                        else
                                        {
                                                //sugar = Data[cur_date].getSupper().getLantis();
                                                sugar = currentUser.getDays()[cur_date].getSupper().getLantis();
                                        }

                                        //if the user has input the breakfast for this day, then add it for the average
                                        if (sugar != -1)
                                        {
                                                total += sugar;
                                                count++;
                                        }
                                }

                                if (meal == 3 || meal == -1)
                                {
                                        int sugar = -1;

                                        if (type == "sugar")
                                        {
                                                //sugar = Data[cur_date].getBed().getSugar();
                                                sugar = currentUser.getDays()[cur_date].getBed().getSugar();
                                        }
                                        else if (type == "units")
                                        {
                                                //sugar = Data[cur_date].getBed().getUnits();
                                                sugar = currentUser.getDays()[cur_date].getBed().getUnits();

                                                //don't include bedtime's units for the unit's "count" variable ONLY if checking overall units average
                                                //include it in the count if the user is checking bedtime averages
                                                if (sugar != -1 && meal != 3)
                                                {
                                                        count--;
                                                }
                                        }
                                        else
                                        {
                                                //sugar = Data[cur_date].getBed().getLantis();
                                                sugar = currentUser.getDays()[cur_date].getBed().getLantis();
                                        }

                                        //if the user has input the breakfast for this day, then add it for the average
                                        if (sugar != -1)
                                        {
                                                total += sugar;
                                                count++;
                                        }
                                }
                        }

                        if (count > 0)
                        {
                                //compute the average
                                avg = total / count;
                        }

                        //round up the average
                        int_avg = (int)avg;
                        if (avg - int_avg >= 0.5)
                        {
                                int_avg++;
                        }

                        return int_avg;
                }

                private void updateUnitsAverage()
                {
                        UpdateAverage("units");
                }

                private void updateLantisAverage()
                {
                        UpdateAverage("Lantis");
                }

                private void Username_TextBox_TextChanged(object sender, EventArgs e)
                {

                }

                private void updateUsername_Button_Click(object sender, EventArgs e)
                {
                        currentUser.setUsername(Username_TextBox.Text);
                        saveUserData();
                }

                private void Meals_Breakfast_RadioButton_Click(object sender, EventArgs e)
                {
                        mealSelected = ((RadioButton)sender).Name;

                        updateAverages();
                }

                private void updateAverages()
                {
                        updateSugarAverage();
                        updateUnitsAverage();
                        updateLantisAverage();
                }

                private void button1_Click(object sender, EventArgs e)
                {
                        Add_Display_Day(-1);
                }

                private void Add_Display_Day(int amount)
                {
                        currentDay += amount;
                        displayUser();
                }

                private void Time_Week_RadioButton_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void Meals_Breakfast_RadioButton_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void Time_Week_RadioButton_Click(object sender, EventArgs e)
                {
                        timeSelected = ((RadioButton)sender).Name;

                        updateAverages();
                }

                private void Time_Total_RadioButton_Click(object sender, EventArgs e)
                {
                        timeSelected = "All";

                        updateAverages();
                }

                private void Time_Month_RadioButton_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void GoForwardDay_Button_Click(object sender, EventArgs e)
                {
                        Add_Display_Day(1);
                }
        }
}
