using System.Collections;
using WindowsDisplayAPI;

Display[] displays = Display.GetDisplays().ToArray();

var b = displays[1].GammaRamp;
var c = new DisplayGammaRamp(0.0, 0.5,1.5);

displays[1].GammaRamp = c;
Thread.Sleep(3000);
displays[1].GammaRamp = b;

//for (int i = 0; i < b.Red.Length; i++)
//{
//    Console.WriteLine(b.Red[i] + "\t" + c.Red[i]);
//}

