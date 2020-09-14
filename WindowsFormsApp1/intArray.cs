using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
        class intArray
        {
                Dictionary<int, int> data;
                int count;

                public intArray()
                {
                        data = new Dictionary<int, int>();
                        count = 0;
                }

                public intArray(int firstEntry)
                {
                        data = new Dictionary<int, int>();
                        data.Add(0, firstEntry);
                        count = 1;
                }

                //getter methods
                public int getCount()
                {
                        return count;
                }
                public int getData(int index)
                {
                        if (index == -1)
                        {
                                return 0;
                        }
                        return data[index];
                }
                //getData converts into a normal int array and then returns that array
                public int[] getData()
                {
                        int[] oldAry = new int[count];

                        for (int x = 0; x < count; x++)
                        {
                                oldAry[x] = data[x];
                        }

                        return oldAry;
                }
                //getDataRaw returns the dictionary used to store the data;
                public Dictionary<int, int> getDataRaw()
                {
                        return data;
                }

                //setter methods
                public void setData(int index, int value)
                {
                        //data does not have an index 'index'
                        if (index >= data.Count)
                        {
                                data.Add(index, value); //add index with the value wanted
                        }
                        else
                        {
                                data[index] = value;
                        }
                }

                //adder method
                public void add(int value)
                {
                        //if for some reason the length of data is greater than count, then make count the correct value
                        if (data.Count > count)
                        {
                                count = data.Count;
                        }

                        data.Add(count, value);
                        count++;
                }

                //remove elelemt from array
                public void remove(int index)
                {
                        data.Remove(index);
                        count--;
                }
        }
}
