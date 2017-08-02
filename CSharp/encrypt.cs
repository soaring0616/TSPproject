using System;
using System.Text;

class Encrypt{
   string cArray;

   public void setArray(){
      System.Random r = new System.Random();
      int a = r.Next(1, 10);
      int b = r.Next(1, 10);
      int x,y,m;
      char c = 'a';
      int i;
      System.Text.StringBuilder s = new System.Text.StringBuilder();
      for( i=0; i<26; i++ ){
          x = c;
          y = x*a+b;
          m = y%26;
          s.Append((char)(m+97));
          c++;
      }
      this.cArray = s.ToString();
   }

   static void Main(){
      for(int i=0; i<16; i++ ){
         Encrypt e = new Encrypt();
         e.setArray();
         System.Console.WriteLine("e: "+e.cArray);
         // 和printIn()的差別是不會新行符號，也就是"\n"
         System.Threading.Thread.Sleep(1000);
      }
   }
}
