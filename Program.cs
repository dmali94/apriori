using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apriori_sch
{
     
    class Program
    {

        class items
        {
            public string[] item=new string[1000];

            public int counts;
            public int ct;            ///////////count of any latters
            
        }
       static items[] list = new items[10000];
       static items[] cpylist = new items[10000];
       static items[] ans = new items[10000];

       static int ctotal = 0;
       static int c = 0;                                          /////count of transection
       static int start = 0;

      static void scan_1th(int supmin)   /////for creat scan 1th from transatcion....
       {
           int count = 0;
           
           for (int i = 0; i < c; i++)
           {
               for (int j = 0; j < cpylist[i].counts; j++)
               {
                   string key = cpylist[i].item[j];
                   for (int k = 0; k < c; k++)
                   {
                       for (int h = 0; h < cpylist[k].counts; h++)
                       {
                           if (key == cpylist[k].item[h]&&cpylist[k].item[h]!="")
                           {
                               count++;
                               cpylist[k].item[h]="";
                           }
                       }
                   }
                   if (count >= supmin)
                   {
                       ans[ctotal] = new items();
                       ans[ctotal].item[0] = key;
                       ans[ctotal++].counts = count;
                       count = 0;
                   }
               }
           }
       }
       static void Main(string[] args)
        {

            int min;
                       //////////////////////////////////////////////////////////// create transaction form input data;
            string a = Console.ReadLine();
            min =Convert.ToInt32( Console.ReadLine());

            string[] st = a.Split('-');        ////transaction   with , 
            for (int i = 0; i < st.Length; i++)
            {
                string[] tran = st[i].Split(',');        //// transaction without ,  
                //list[c].count = tran.Length;
               // cpylist[c].count = tran.Length;
                list[c] = new items();
                cpylist[c] = new items();
                for (int j = 0; j < tran.Length; j++)
                {
                    
                    list[c].item[j] = tran[j];
                    cpylist[c].item[j] = tran[j];
                    
                }
                list[c].counts = tran.Length;
                cpylist[c].counts = tran.Length;
                c++;                                    /////count of transection
            }
            /////////////////////////
            scan_1th(min);
            
        }
    }
}
