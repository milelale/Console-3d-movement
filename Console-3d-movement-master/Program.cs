using System;

namespace ProjekatZaSkstadic
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new char[16, 16]{
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ','*'},
                {'*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ','*'},
                {'*','*','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ','*',' ','*'},
                {'*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ','*'},
                {'*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*'},
                {'*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*'},
                {'*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*'},
                {'*','*','*',' ',' ',' ',' ',' ',' ','*',' ',' ',' ','*','*','*'},
                {'*',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ','*'},
                {'*',' ','*','*','*',' ','*',' ',' ','*',' ','*',' ',' ',' ','*'},
                {'*',' ','*',' ',' ',' ','*',' ',' ','*',' ','*',' ','*',' ','*'},
                {'*',' ','*',' ','*','*','*',' ',' ','*',' ','*',' ','*',' ','*'},
                {'*',' ','*',' ','*',' ',' ',' ',' ','*',' ','*','*','*',' ','*'},
                {'*',' ','*',' ','*',' ','*','*','*','*',' ',' ',' ',' ',' ','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'}
            };
            char[,] ekran = new char[120, 30];
            Console.SetWindowSize(121, 31);
            Console.SetBufferSize(122, 32);
            Console.CursorVisible = false;
            string lum = " ,:-=+#%@";

            double posx = 8.0, posy = 8.0, ugao = 0, fov = Math.PI / 2.00;
            do
            {
                for (int i = 0; i < 120; i++)
                {
                    double dist = 0.01;
                    bool hit = false;
                    double ugaoProv = ugao - (fov / 2.00)+ ((double)i/ 120.00) * fov;
                    if (ugaoProv < 0)
                    {
                        ugaoProv += 2 * Math.PI;
                    }
                    else if (ugaoProv > 2 * Math.PI)
                    {
                        ugaoProv -= Math.PI * 2;
                    }

                    while (!hit)
                    {
                        double xProv, yProv;
                        xProv = dist * Math.Sin(ugaoProv);
                        yProv = dist * Math.Cos(ugaoProv)*-1;
                        xProv += posx;
                        yProv += posy;
                        if (map[(int)Math.Floor(xProv), (int)Math.Floor(yProv)] == '*')
                        {
                            
                            hit = true;
                        }
                        dist += 0.01;
                       
                    }
                    int heightCol = (int)(30.00 - dist*(30.00/8.00));
                    for(int j =0;j < 30; j++)
                    {
                        if(j > 15 - (heightCol / 2)  && j < 15 + (heightCol / 2)) {
                            ekran[i, j] = lum[lum.Length - (int)dist-1];
                        }
                        else if (j >= heightCol / 2 + 15)
                        {
                            ekran[i, j] = '.';
                        }
                        else
                        {
                            ekran[i, j] = ' ';
                        }
                    }
                    
                }
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 30; i++) { 
                    for(int j = 0; j < 120;j++)
                    {
                        Console.Write(ekran[j, i]);
                    }
                    Console.Write("\n");
                }
                
                char movement = Console.ReadKey().KeyChar;
                
                if(movement  == 'a')
                {
                    ugao -= Math.PI / 45.00;
                }
                if (movement == 'd')
                {
                    ugao += Math.PI / 45.00;
                }
                if (ugao < 0)
                {
                    ugao += 2 * Math.PI;
                }
                else if (ugao > 2 * Math.PI)
                {
                    ugao -= Math.PI * 2;
                }
                if (movement == 's')
                {
                    double xProv = 0.1 * Math.Sin(ugao);
                    double yProv = 0.1 * Math.Cos(ugao) * -1;
                    posx -= xProv;
                    posy -= yProv;
                    if (map[(int)Math.Floor(posx), (int)Math.Floor(posy)] == '*')
                    {
                        posx += xProv;
                        posy += yProv;
                    }
                }
                if (movement == 'w')
                {
                    double xProv = 0.1 * Math.Sin(ugao);
                    double yProv = 0.1 * Math.Cos(ugao) * -1;
                    posx += xProv;
                    posy += yProv;
                    if(map[(int)Math.Floor(posx), (int)Math.Floor(posy)] == '*')
                    {
                        posx -= xProv;
                        posy -= yProv;
                    }
                }
                
            } while (true);

        }
    }
}
