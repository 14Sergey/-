#include <stdio.h>
#include <conio.h>
#include <graphics.h>
#include <stdlib.h>
int pr, sini=15,orandg=14,rekord=0;
int nachalo[16];
void dvig(int key)
{
      setcolor(COLOR(255,128,0));
      switch(key)
      {
                 case 1: rectangle(414,195,586,235); outtextxy(415,200,"ПРОДОЛЖИТЬ"); break;
                 case 2: rectangle(414,245,586,285); outtextxy(415,250,"НОВАЯ ИГРА"); break;
                 case 3: rectangle(414,295,586,335); outtextxy(440,300,"РЕКОРДЫ"); break;
                 case 4: rectangle(414,345,586,385); outtextxy(450,350,"ПОМОЩЬ"); break;
                 case 5: rectangle(414,395,586,435); outtextxy(458,400,"ВЫХОД"); break;
      }
}
void dvig1(int key)
{
      setcolor(COLOR(255,128,0));
      switch(key)
      {
                 case 1: rectangle(40,59,260,95); outtextxy(65,62,"продолжить"); break;
                 case 2: rectangle(40,99,260,135); outtextxy(100,102,"заново"); break;
                 case 3: rectangle(40,139,260,175); outtextxy(95,142,"рекорды"); break;
                 case 4: rectangle(40,179,260,215); outtextxy(100,182,"помощь"); break;
                 case 5: rectangle(40,219,260,255); outtextxy(45,222,"главное меню"); break;
      }
}
void dvig2(int key)
{
      setcolor(COLOR(255,128,0));
      switch(key)
      {
                 case 1: rectangle(380,350,460,390); outtextxy(405,355,"ДА"); break; 
                 case 2: rectangle(540,350,620,390); outtextxy(556,355,"НЕТ"); break;
      }
}
void pole()
{
     setfillstyle (1,7);
     bar(31,31,970,670);
     setcolor(COLOR(0,0,0));
     rectangle(330,205,670,545);
     setfillstyle (1,COLOR(102,102,102));
     floodfill(420,300,(COLOR(0,0,0)));
     setcolor(COLOR(0,0,0));     
     line(415,205,415,545);
     line(500,205,500,545);
     line(585,205,585,545);
     line(330,290,670,290);
     line(330,375,670,375);
     line(330,460,670,460);
     setcolor(COLOR(0,0,255));
     setbkcolor(7);
     settextstyle(0,0,70);
     outtextxy(32,31,"Esc: меню");
}
void pom()
{
      setfillstyle (1,7);
      bar(31,31,970,670);
      setcolor(COLOR(0,0,255));
      outtextxy(440,50,"ПОМОЩЬ");
      settextstyle(0,0,200);
      outtextxy(315,650, "Для продолжения нажмите любую клавишу...");
      setcolor(COLOR(0,0,0));
      rectangle(700,160,940,400);
      setfillstyle (1,COLOR(102,102,102));
      floodfill(750,200,(COLOR(0,0,0)));
      setcolor(COLOR(0,0,0));     
      line(700,220,940,220);
      line(700,280,940,280);
      line(700,340,940,340);
      line(760,160,760,400);
      line(820,160,820,400);
      line(880,160,880,400);
      setcolor(COLOR(255,128,0));
      rectangle(821,341,879,399);
      setcolor(COLOR(255,51,0));
      settextstyle(0,0,20);
      outtextxy(680,60,"Победа!");
      setfillstyle(1,COLOR(0,0,255));
      floodfill(930,390,(COLOR(0,0,0)));
      setcolor(COLOR(0,0,255));
      settextstyle(0,0,70);
      setbkcolor(COLOR(102,102,102));
      outtextxy(722,175,"1");
      outtextxy(782,175,"2");
      outtextxy(842,175,"3");
      outtextxy(902,175,"4");
      outtextxy(722,235,"5");
      outtextxy(782,235,"6");
      outtextxy(842,235,"7");
      outtextxy(902,235,"8");
      outtextxy(722,295,"9");
      outtextxy(773,295,"10");
      outtextxy(833,295,"11");
      outtextxy(893,295,"12");
      outtextxy(713,355,"13");
      outtextxy(773,355,"14");
      setcolor(COLOR(255,128,0));
      outtextxy(833,355,"15");
      setbkcolor(7);
      setcolor(COLOR(0,0,0));
      settextstyle(0,0,70);
      outtextxy(70,100,"На поле будут перемешаны цифры.");
      outtextxy(36,140,"С помощью клавиш со стрелками");
      outtextxy(36,180,"(вправо, влево) можно менять активную");
      outtextxy(36,220,"(оранжевую) клетку вокруг пустой");
      outtextxy(36,260,"(синей) клетки по часовой стрелке и");
      outtextxy(36,300,"против часовой стрелки соответственно.");
      outtextxy(36,340,"Клавиша Enter поменяет местами активную");
      outtextxy(36,380,"и пустую клетки. Чтобы выиграть, надо");
      outtextxy(36,420,"расставить все числа по порядку и в конце ");
      outtextxy(36,460,"оставить пустую клетку. И сделать это за ");
      outtextxy(36,500,"как можно меньшее количество ходов.");
      outtextxy(36,540,"Лучший счёт будет записан в таблицу рекордов.");
      getch();
}
void record(int file[10],int n)
{
      int i=0,th,st=0,str=0,v,p;
      setfillstyle (1,7);
      setcolor(COLOR(0,0,255));
      bar(31,31,970,670);
      settextstyle(0,0,70);
      outtextxy(440,50,"РЕКОРДЫ");
      for(i=0;i<10;i++)
      {
                      setcolor(COLOR(0,0,255));
                      if(file[i]==-1)
                      {
                           outtextxy(472,100+str*40,"нет");
                           str++;
                           continue;
                      }
                      if(file[i]==rekord && n==1)
                      {
                           setcolor(COLOR(255,128,0));
                           n=0;
                      }
                      th=file[i];
                      while(th=th/10)
                                 st++;
                      p=st; 
                      th=file[i];
                      for(st;st>=0;st--)
                      {
                                 v=th%10;
                                 th=th/10;
                                 if(v==0) outtextxy(490+st*18-p*9,100+str*40,"0"); 
                                 if(v==1) outtextxy(490+st*18-p*9,100+str*40,"1");
                                 if(v==2) outtextxy(490+st*18-p*9,100+str*40,"2");
                                 if(v==3) outtextxy(490+st*18-p*9,100+str*40,"3");
                                 if(v==4) outtextxy(490+st*18-p*9,100+str*40,"4");
                                 if(v==5) outtextxy(490+st*18-p*9,100+str*40,"5");
                                 if(v==6) outtextxy(490+st*18-p*9,100+str*40,"6");
                                 if(v==7) outtextxy(490+st*18-p*9,100+str*40,"7");
                                 if(v==8) outtextxy(490+st*18-p*9,100+str*40,"8");
                                 if(v==9) outtextxy(490+st*18-p*9,100+str*40,"9");         
                      }
                      st=0;
                      str++;
      }
      setcolor(COLOR(0,0,255));
      settextstyle(0,0,200);
      outtextxy(315,650, "Для продолжения нажмите любую клавишу...");
      getch(); 
}
void udal_pr()
{
     FILE *f;
     while(1)
            if((f=fopen("save.txt", "wt"))!=NULL)
                                    break;
     fclose(f);  
}
int victory(int file[10])
{
     int i,vic=0,th,rekord1;
     for(i=0;i<16;i++)
     {
                       if(nachalo[i]==i+1)
                           vic++;
                       else
                           break;
     }
     if(vic==16)
     {
                          setbkcolor(7);
                          setcolor(COLOR(255,51,0));
                          settextstyle(0,0,21);
                          outtextxy(370,75,"Победа!");
                          settextstyle(0,0,200);
                          outtextxy(315,650, "Для продолжения нажмите клавишу Enter...");
                          while(1)
                                 if(getch()==13)
                                                break; 
                          rekord1=rekord;
                          for(i=0; i<10; i++)
                          {
                                   if(file[i]>rekord1 || file[i]==-1)
                                   {
                                                 for(i;i<10;i++)
                                                 {
                                                                th=file[i];
                                                                file[i]=rekord1;
                                                                rekord1=th;
                                                 }
                                   }
                                   else
                                       if(rekord1==file[i])
                                                      break;
                          }
                          record(file,1);
                          rekord=0;
                          sini=15;
                          orandg=14;
                          udal_pr();
                          return 1;
     }
     return 0;
}
void dvig_pole(int sini0,int orandg0)
{
     int i,k,str=-1,st,x=331,y=206,p;
     settextstyle(0,0,70);
     while(sini0>-1)
     {
                sini0=sini0-4;
                str++;
     }
     if(sini0==-1) st=3;
     if(sini0==-2) st=2;
     if(sini0==-3) st=1;
     if(sini0==-4) st=0;
     setfillstyle (1,COLOR(102,102,102));
     floodfill(x+st*85,y+str*85,(COLOR(0,0,0)));
     str=-1;
     while(orandg0>-1)
     {
                orandg0=orandg0-4;
                str++;
     }
     if(orandg0==-1) st=3;
     if(orandg0==-2) st=2;
     if(orandg0==-3) st=1;
     if(orandg0==-4) st=0;
     setfillstyle(1,COLOR(102,102,102));
     floodfill(x+st*85,y+str*85,(COLOR(0,0,0)));
     str=-1;
     sini0=sini;
     while(sini0>-1)
     {
                sini0=sini0-4;
                str++;
     }
     if(sini0==-1) st=3;
     if(sini0==-2) st=2;
     if(sini0==-3) st=1;
     if(sini0==-4) st=0;
     setfillstyle(1,COLOR(0,0,255));
     floodfill(x+st*85,y+str*85,(COLOR(0,0,0)));
     str=-1;
     orandg0=orandg;
     while(orandg0>-1)
     {
                orandg0=orandg0-4;
                str++;
     }
     if(orandg0==-1) st=3;
     if(orandg0==-2) st=2;
     if(orandg0==-3) st=1;
     if(orandg0==-4) st=0;
     setcolor(COLOR(255,128,0));
     rectangle(x+st*85,y+str*85,x+st*85+83,y+str*85+83);
     x=364; y=233;
     setbkcolor(COLOR(102,102,102));     
     for(i=0;i<16;i++)
     {
                 setcolor(COLOR(0,0,255));
                 if(i==orandg)
                            setcolor(COLOR(255,128,0));  
                 str=-1;
                 k=i;
                 p=0;
                 while(k>-1)
                 {
                            k=k-4;
                            str++;
                 }
                 if(k==-1) st=3;
                 if(k==-2) st=2;
                 if(k==-3) st=1;
                 if(k==-4) st=0;
                 if(nachalo[i]>9) p=7;
                 if(nachalo[i]==1)
                               outtextxy(x+st*85-p,y+str*85,"1");
                 if(nachalo[i]==2)
                               outtextxy(x+st*85-p,y+str*85,"2");
                 if(nachalo[i]==3)
                               outtextxy(x+st*85-p,y+str*85,"3");
                 if(nachalo[i]==4)
                               outtextxy(x+st*85-p,y+str*85,"4");
                 if(nachalo[i]==5)
                               outtextxy(x+st*85-p,y+str*85,"5");
                 if(nachalo[i]==6)
                               outtextxy(x+st*85-p,y+str*85,"6");
                 if(nachalo[i]==7)
                               outtextxy(x+st*85-p,y+str*85,"7");
                 if(nachalo[i]==8)
                               outtextxy(x+st*85-p,y+str*85,"8");
                 if(nachalo[i]==9)
                               outtextxy(x+st*85-p,y+str*85,"9");
                 if(nachalo[i]==10)
                               outtextxy(x+st*85-p,y+str*85,"10");
                 if(nachalo[i]==11)
                               outtextxy(x+st*85-p,y+str*85,"11");
                 if(nachalo[i]==12)
                               outtextxy(x+st*85-p,y+str*85,"12");
                 if(nachalo[i]==13)
                               outtextxy(x+st*85-p,y+str*85,"13");
                 if(nachalo[i]==14)
                               outtextxy(x+st*85-p,y+str*85,"14");
                 if(nachalo[i]==15)
                               outtextxy(x+st*85-p,y+str*85,"15");
     } 
}
void schet()
{
     int th=0,r=rekord,x,y,v;
     setcolor(COLOR(0,0,0));
     setbkcolor(7);
     outtextxy(450,50,"Счёт:");
     while(r=r/10)
            th++; 
     r=rekord;
     for(th;th>=0;th--)
     {
            v=r%10;
            r=r/10;
            if(v==0) outtextxy(540+th*18,50,"0"); 
            if(v==1) outtextxy(540+th*18,50,"1");
            if(v==2) outtextxy(540+th*18,50,"2");
            if(v==3) outtextxy(540+th*18,50,"3");
            if(v==4) outtextxy(540+th*18,50,"4");
            if(v==5) outtextxy(540+th*18,50,"5");
            if(v==6) outtextxy(540+th*18,50,"6");
            if(v==7) outtextxy(540+th*18,50,"7");
            if(v==8) outtextxy(540+th*18,50,"8");
            if(v==9) outtextxy(540+th*18,50,"9");         
     }  
}
int da_net(int v)
{
     int k,key=1;
     setfillstyle (1,7);
     bar(300,275,700,425);
     setcolor(COLOR(0,0,255));
     rectangle(300,275,700,425);
     settextstyle(0,0,200);
     if(v==1)
     {
             outtextxy(330,300,"Вы точно хотите начать игру заново?");
             outtextxy(370,320,"Текущая игра будет утеряна!");
     }
     if(v==2)
     {
             outtextxy(320,300,"Вы точно хотите выйти в главное меню?");
             outtextxy(360,320,"Текущая игра будет сохранена.");
     }
     if(v==3)
     {
             outtextxy(330,300,"Вы точно хотите начать новую игру?");
             outtextxy(350,320,"Сохранённая игра будет утеряна!");
     }
     settextstyle(0,0,70);
     while(1)
     {
             setcolor(COLOR(0,0,255));
             outtextxy(405,355,"ДА");
             rectangle(380,350,460,390);
             outtextxy(556,355,"НЕТ");
             rectangle(540,350,620,390);
             dvig2(key);
             k=getch();
             switch(k)
             {
                     case 77: key++; if(key>2) key=2; break;
                     case 75: key--; if(key<1) key=1; break;
                     case 13: switch(key)
                              {
                                         case 1: return 1; break;
                                         case 2: return 2; break;
                              }
             }
     }
}
int menu(int key)
{
        int k,n;
        while(1)
        {
                setcolor(COLOR(0,0,255));        
                outtextxy(65,62,"продолжить"); 
                rectangle(40,59,260,95); 
                outtextxy(100,102,"заново");
                rectangle(40,99,260,135);  
                outtextxy(95,142,"рекорды"); 
                rectangle(40,139,260,175); 
                outtextxy(100,182,"помощь");
                rectangle(40,179,260,215);
                outtextxy(45,222,"главное меню");
                rectangle(40,219,260,255);
                dvig1(key);
                k=getch();
                switch(k)
                {
                   case 80: key++; if(key>5) key=5; break;
                   case 72: key--; if(key<1) key=1; break; 
                   case 13: switch(key)
                            {
                                     case 1: setfillstyle (1,7);bar(31,57,261,256); return 1; break;
                                     case 2: n=da_net(1);
                                             if(n==1)
                                                     return 2;
                                             else
                                                     return 5; 
                                             break;
                                     case 3: return 3; break;
                                     case 4: return 4; break; 
                                     case 5: n=da_net(2); 
                                             if(n==1)
                                                     return 0;
                                             else
                                                     return 6; 
                                             break;
                            } break;
                }
        }
}
void save()
{
     FILE *f;
     int i;
     if((f=fopen("save.txt", "wt+"))!=NULL)
     {
        for(i=0;i<16;i++)
                         fprintf(f,"%d ",nachalo[i]);
        fprintf(f,"\n%d\n%d\n%d",rekord,sini,orandg);
     }
     else
     {
         bar(301,276,700,425);
         setcolor(COLOR(0,0,255));        
         settextstyle(0,0,200);
         outtextxy(480,300,"Ошибка!");
         outtextxy(390,320,"Игра не будет сохранена!");
         outtextxy(390,340,"Нажмите любую клавишу...");
         getch();
     }
     fclose(f);
}
void igra(int file[10])
{     
     int i,p,j,reh=0,rehenie,sini0=15,orandg0=14,n1=1,n,k,sav,key=1; 
     srand(time(NULL));
     if(pr==0)
     {
              for(i=0;i<16;i++)
                               nachalo[i]=16;
              rekord=0;
              sini=15;
              orandg=14;
              while(1)
              {                
                for(i=0;i<15;i++)
                {
                                 p=(rand()%15)+1;
                                 j=0;
                                 while(j<=i)
                                 {
                                          if(p==nachalo[j])
                                          {
                                                           p=0;
                                                           break;
                                          }
                                          j++;
                                 }
                                 if(p==0)
                                          i--;
                                 else
                                          nachalo[i]=p;
                }
                rehenie=0;
                for(i=0; i<15; i++)
                {
                         for(j=i+1; j<16; j++)
                         {
                                    if(nachalo[i]>nachalo[j])
                                            reh++;
                         } 
                         rehenie=rehenie+reh;
                         reh=0;
                }
                if(rehenie%2==0)
                                break;
              }
     /*for(i=0;i<8;i++)
                                 nachalo[i]=i+1;
     nachalo[8]=10;
     nachalo[9]=11;
     nachalo[10]=12;
     nachalo[11]=15;
     nachalo[12]=9;
     nachalo[13]=13;
     nachalo[14]=14;
     nachalo[15]=16;*/
     /*for(i=0;i<16;i++)
                                 nachalo[i]=i+1;*/
     }
     pole();     
     while(n1)
     {
              dvig_pole(sini0,orandg0);
              schet();
              if(victory(file))
                           break;
              k=getch();
              orandg0=orandg;
              switch(k)
              {
                       case 77: if(orandg+1==sini && orandg-3>-1)
                                {
                                                  orandg=orandg-3;
                                                  break;
                                }
                                if(orandg-1==sini && orandg+3<16)
                                {
                                                  orandg=orandg+3;
                                                  break;
                                }
                                if(orandg+4==sini && orandg+5<16)
                                {
                                                  if(sini==7 || sini==11 || sini==15) break;
                                                  orandg=orandg+5;
                                                  break;
                                }
                                if(orandg-4==sini && orandg-5>-1)
                                {
                                                  if(sini==0 || sini==4 || sini==8) break;
                                                  orandg=orandg-5;
                                                  break;
                                }
                                break;
                       case 75: if(orandg+1==sini && orandg+5<16)
                                {
                                                  orandg=orandg+5;
                                                  break;
                                }
                                if(orandg-1==sini && orandg-5>-1)
                                {
                                                  orandg=orandg-5;
                                                  break;
                                }
                                if(orandg+4==sini && orandg+3<16)
                                {
                                                  if(sini==4 || sini==8 || sini==12) break;
                                                  orandg=orandg+3;
                                                  break;
                                }
                                if(orandg-4==sini && orandg-3>-1)
                                {
                                                  if(sini==3 || sini==7 || sini==11) break;
                                                  orandg=orandg-3;
                                                  break;
                                }
                                break;
                       case 13: sini0=sini; 
                                sav=sini;
                                sini=orandg;
                                orandg=sav;
                                sav=nachalo[sini];
                                nachalo[sini]=nachalo[orandg];
                                nachalo[orandg]=sav;
                                rekord++;                                
                                break;
                       case 27: while(1)
                                {                                         
                                     n=menu(key);
                                     if(n==2) 
                                     {
                                              pr=0;
                                              igra(file);
                                              n1=0;
                                              break;
                                     }
                                     if(n==3 || n==4 || n==5 || n==6)
                                     {
                                             if(n==3)
                                             { 
                                                      record(file,n);
                                                      key=3;
                                             } 
                                             if(n==4)
                                             {
                                                      pom(); 
                                                      key=4;
                                             }
                                             if(n==5) key=2;
                                             if(n==6) key=5;
                                             pole(); 
                                             dvig_pole(sini0,orandg0);
                                             schet();
                                             continue;
                                     }
                                     if(n==0) 
                                     {
                                              save();
                                              n1=0;
                                     }
                                     break;
                                }
                                key=1;
                                break;
              }              
     }
}
void save_rekord(int file[10])
{
     FILE *f;
     int i;
     if((f=fopen("rekord.txt", "wt+"))!=NULL)  
        for(i=0;i<10;i++)
        {
                         if(file[i]==-1)
                                        fprintf(f, "-\n");
                         else
                                        fprintf(f, "%d\n", file[i]); 
        }                        
     else
     {
        setcolor(COLOR(0,0,255));
        settextstyle(0,0,200);
        bar(31,31,970,670);
        outtextxy(100,340,"Ошибка! Изменения в таблице рекордов не сохранятся. Нажмите любую клавишу...");
        getch();
     }
     fclose(f);
}
int open(int v)
{
    FILE *f;
    int i,j=0,th=0;
    char str[38],s;
    if((f=fopen("save.txt", "rt+"))==NULL)
        if((f=fopen("save.txt", "at+"))==NULL)
        {
            bar(31,31,970,670);
            outtextxy(150,340,"Ошибка! Данные сохранённой игры не удалось загрузить. Нажмите любую клавишу...");
            getch();
            fclose(f);
            return 0;     
        }
    if(fgetc(f)!=EOF && v==2)
    {
            fseek(f,0,SEEK_SET);       
            fgets(str,50,f);
            for(i=0;i<38;i++)
            {
                      if(str[i]!=' ')
                      {
                                   if(str[i-1]!=' ' && i!=0)   
                                                  th=th*10+(str[i]-'0');
                                   else
                                                  th=str[i]-'0';
                      }
                      else
                      {
                                   nachalo[j]=th;
                                   j++;
                                   th=0;
                      }             
            }
            nachalo[j]=th;
            th=0;
            while((s=fgetc(f))!='\n')
                      th=th*10+(s-'0');
            rekord=th;
            th=0;
            while((s=fgetc(f))!='\n')
                      th=th*10+(s-'0');
            sini=th;
            th=0;
            while((s=fgetc(f))!=EOF)
                      th=th*10+(s-'0');
            orandg=th;
            fclose(f);
            return 1;
    }            
    if(fgetc(f)==EOF && v==1)
    {
                   fclose(f);  
                   return 0;
    }
    else
    {
                   fclose(f);
                   return 1;
    }  
    fclose(f);
    return 0;
}
main()
{
      FILE *f;
      int n=1,th=0,key,key1,k,i=0,file[10]={-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
      char s,s0='-';
      initwindow(1000,700);
      setbkcolor(7);
      setfillstyle (1,7);
      bar(0,0,1000,700);
      setcolor(COLOR(0,0,255));
      rectangle(30,30,970,670);
      settextstyle(0,0,21);
      outtextxy(330,200, "ПЯТНАШКИ");
      settextstyle(0,0,200);
      outtextxy(315,320, "Для продолжения нажмите любую клавишу...");
      outtextxy(475,650, "2017            Автор: Шевчук Сергей Владимирович");
      getch();
      if((f=fopen("rekord.txt", "rt+"))==NULL)
        if((f=fopen("rekord.txt", "at+"))==NULL)
        {
            bar(31,31,970,670);
            outtextxy(200,340,"Ошибка! Данные игры не удалось загрузить. Нажмите любую клавишу...");
            getch();
            n=0;     
        }
      if(n!=0)
      {              
              while((s=fgetc(f))!=EOF)
              {
                           
                           if(s!='\n' && s!='-')
                                      th=th*10+s-'0';
                           else 
                           {                                      
                                      if(s0!='-' && s0!='\n')
                                      {
                                          file[i]=th;
                                          th=0;
                                          i++;
                                      }           
                                      if(s=='-')
                                      {
                                                file[i]=-1;
                                                i++;
                                      }          
                           }
                           s0=s;
              }
              pr=open(1);
              if(pr)
              {
                      key=1;
                      key1=1;
              }
              else
              {
                      key=2;
                      key1=2;
              }         
      }
      fclose(f);
      while(n)
      {     
        setbkcolor(7);
        setfillstyle (1,7);
        bar(31,31,970,670);
        setcolor(COLOR(0,0,255));        
        settextstyle(0,0,20);
        outtextxy(250,100,"ГЛАВНОЕ МЕНЮ");
        settextstyle(0,0,70);
        rectangle(414,245,586,285); 
        outtextxy(415,250,"НОВАЯ ИГРА"); 
        rectangle(414,295,586,335); 
        outtextxy(440,300,"РЕКОРДЫ");
        rectangle(414,345,586,385);  
        outtextxy(450,350,"ПОМОЩЬ");
        rectangle(414,395,586,435);  
        outtextxy(458,400,"ВЫХОД");
        if(pr==0)
                 setcolor(COLOR(102,102,102));
        rectangle(414,195,586,235);
        outtextxy(415,200,"ПРОДОЛЖИТЬ");     
        dvig(key); 
        k=getch();
        switch(k)
        {
                 case 80: key++; if(key>5) key=5; break;
                 case 72: key--; if(key<key1) key=key1; break;
                 case 13: switch(key)
                          {
                                     case 1: if((pr=open(2))==0) 
                                                 break;
                                             else
                                             {
                                                 igra(file);
                                                 pr=open(1);
                                             }
                                             if(pr)
                                             {
                                                   key=1;
                                                   key1=1;
                                             }
                                             else
                                             {
                                                   key=2;
                                                   key1=2;
                                             }
                                             break;
                                     case 2: if(pr==0)
                                                      igra(file);
                                             else
                                             {
                                                 if(da_net(3)==1)  
                                                 {         
                                                              pr=0;
                                                              igra(file);
                                                 }                  
                                                 else 
                                                              break;  
                                             } 
                                             pr=open(1); 
                                             if(pr)
                                             {
                                                       key=1;
                                                       key1=1;
                                             }
                                             else
                                             {
                                                       key=2;
                                                       key1=2;
                                             }
                                             break;
                                     case 3: record(file,0); break;
                                     case 4: pom(); break;
                                     case 5: n=0; save_rekord(file); break; 
                          } break;
        }
        
      }          
closegraph();       
}
