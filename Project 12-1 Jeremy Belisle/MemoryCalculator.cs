using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_14_1_Jeremy_Belisle
{
   
    public class MemoryCalculator : Calculator
    {
        //creating a method to store the memory
        public static decimal MemoryStore(System.Windows.Forms.TextBox txtResult)
        {
            decimal memoryStore = 0;
            memoryStore = decimal.Parse(txtResult.Text);

            return memoryStore;
        }
        //a method to recall the saved memory
        public static decimal MemoryRecall(decimal memoryStore)
        {
            return memoryStore;
        }
        //a method to add to the current memory
        public static decimal MemoryAdd(System.Windows.Forms.TextBox txtResult, decimal memoryStore)
        {
            memoryStore += decimal.Parse(txtResult.Text);
            return memoryStore;
        }

        //a method to clear the memory 
        public static decimal MemoryClear(decimal memoryStore)
        {
            memoryStore = 0;
            return memoryStore;
        }


    }
}
