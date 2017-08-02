#include<stdio.h>
#include<stdlib.h>
#include<time.h>
#define MAX_ELEMENT 1000

void TSP(int c[4][4]){
   int i=0, j=0, k=0, min=MAX_ELEMENT, glb=0, ans=0;

   //Find for great lower bound
   for(i=0;i<4;i++){
      for(j=0;j<4;j++){
         if(!(i==j)&&(c[i][j]<min)){
            min=c[i][j];
            if(i==0) k=j;
         }
      }
      glb+=min;
      min=MAX_ELEMENT;
   }
   //Now we branch
   ans+=c[0][k];
   for(i=1;i<4;i++){
      if(i==k) continue;
      else{
         for(j=0;j<4;j++){
            if(j==k) break;
            else{
               if(!(i==j)&&(c[i][j]<min)){
                  min=c[i][j];
               }
            }
         }
         ans+=min;
         min=MAX_ELEMENT;
      }
   }
   printf("ans=%d",ans);
}

void main(){
 
   int c[4][4]={
      0,3,6,7,
      5,0,2,3,
      6,4,0,2,
      3,7,5,0,
   };
   // Cost matrix between cities.
   double START,END;
   START = clock();
   TSP(c);
   END = clock();
   printf("time: %f",(END-START)/CLOCKS_PER_SEC);

}
