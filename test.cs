using System;
using System.Threading;

class Program
{
    static void Main()
    {
        double totalTime = 100; // seconds
        double dt = 0.4;        // seconds

        int ph1 = 7;
        int ph2 = 2;

        int pt1 = 5;
        int pt2 = 3;

        int pq1 = 4;

        int loopnum = (int)(totalTime / dt);

        string empty = "\n\n\n\n\n\n\n\n\n\n\n";
        Console.Write(empty);

        for (int i = 0; i <= loopnum; i++)
        {
            int ch1 = 33 * ((i / ph1) % 2);
            int ch2 = 30 + 6 * ((i / ph2) % 2);
            int ct1 = 30 + (int)(3.5 * ((i / pt1) % 3));
            int ct2 = 30 + ((i / pt2) % 3);
            int cq1 = 36 - ((i / pq1) % 4) * (((i / pq1) % 4) + 1) / 2;

            string tree =
                $"　\e[{ct1}m＋\e[0m　　　　\e[{ch1}m★\e[0m　　　　\n" +
                $"　　　　　／\e[{cq1}m。\e[0m＼　　\e[{ct1}m＋\e[0m　\n" +
                $"　　　　／\e[{ct2}m。\e[0m　\e[{ch2}m＊\e[0m＼　　　\n" +
                $"　　　／　\e[{ch2}m。\e[0m　　\e[{cq1}m。\e[0m＼　　　\n" +
                $"　　\e[{ct1}m＋\e[0m　／　　\e[{ct2}m。\e[0m＼　　　\n" +
                $"　　　／\e[{cq1}m。\e[0m　\e[{ch2}m。\e[0m　\e[{ch2}m＊\e[0m＼　　\n" +
                $"　　／　\e[{ct2}m＊\e[0m　　　\e[{cq1}m。\e[0m　＼　\n" +
                $"　／\e[{ch2}m。\e[0m　\e[{ch2}m。\e[0m　\e[{ct2}m。\e[0m　　\e[{ct2}m。＊\e[0m＼\n" +
                $"　\e[{ct2}mｉ　\e[0m\e[{ch2}mｉ\e[0m｜　\e[{ct2}mｉ\e[0m　｜\e[{ct2}mｉ\e[0m　\e[{ch2}mｉ\e[0m\n" +
                $"　　　　｜　　　｜　　　\n";

            // カーソルを10行上に戻して上書き
            Console.Write($"\x1b[10A{tree}");

            Thread.Sleep((int)(dt * 1000));
        }
    }
}


////
using System.Runtime.InteropServices;

[DllImport("kernel32.dll", SetLastError = true)]
static extern IntPtr GetStdHandle(int nStdHandle);

[DllImport("kernel32.dll")]
static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

const int STD_OUTPUT_HANDLE = -11;
const int ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

// Mainの最初で呼ぶ
var handle = GetStdHandle(STD_OUTPUT_HANDLE);
SetConsoleMode(handle, ENABLE_VIRTUAL_TERMINAL_PROCESSING);


///
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        double totalTime = 100;
        double dt = 0.4;

        int ph1 = 7;
        int ph2 = 2;
        int pt1 = 5;
        int pt2 = 3;
        int pq1 = 4;

        int loopnum = (int)(totalTime / dt);

        Console.Clear();

        for (int i = 0; i <= loopnum; i++)
        {
            int ch1 = 33 * ((i / ph1) % 2);
            int ch2 = 30 + 6 * ((i / ph2) % 2);
            int ct1 = 30 + (int)(3.5 * ((i / pt1) % 3));
            int ct2 = 30 + ((i / pt2) % 3);
            int cq1 = 36 - ((i / pq1) % 4) * (((i / pq1) % 4) + 1) / 2;

            Console.SetCursorPosition(0, 0);

            DrawLine(new (string, int)[] {
                ("　", -1), ("＋", ct1), ("　　　　", -1), ("★", ch1)
            });

            DrawLine(new (string, int)[] {
                ("　　　　　／", -1), ("。", cq1), ("＼　　", -1), ("＋", ct1)
            });

            DrawLine(new (string, int)[] {
                ("　　　　／", -1), ("。", ct2), ("　", -1), ("＊", ch2), ("＼", -1)
            });

            DrawLine(new (string, int)[] {
                ("　　　／　", -1), ("。", ch2), ("　　", -1), ("。", cq1), ("＼", -1)
            });

            DrawLine(new (string, int)[] {
                ("　　", -1), ("＋", ct1), ("　／　　", -1), ("。", ct2), ("＼", -1)
            });

            DrawLine(new (string, int)[] {
                ("　　　／", -1), ("。", cq1), ("　", -1), ("。", ch2), ("　", -1), ("＊", ch2), ("＼", -1)
            });

            DrawLine(new (string, int)[] {
                ("　　／　", -1), ("＊", ct2), ("　　　", -1), ("。", cq1), ("　＼", -1)
            });

            DrawLine(new (string, int)[] {
                ("　／", -1), ("。", ch2), ("　", -1), ("。", ch2), ("　", -1), ("。", ct2), ("　　", -1), ("。＊", ct2), ("＼", -1)
            });

            DrawLine(new (string, int)[] {
                ("　", -1), ("ｉ", ct2), ("　", -1), ("ｉ", ch2), ("｜　", -1),
                ("ｉ", ct2), ("　｜", -1), ("ｉ", ct2), ("　", -1), ("ｉ", ch2)
            });

            DrawLine(new (string, int)[] {
                ("　　　　｜　　　｜　　　", -1)
            });

            Thread.Sleep((int)(dt * 1000));
        }
    }

    static void DrawLine((string text, int colorCode)[] parts)
    {
        foreach (var (text, code) in parts)
        {
            if (code != -1)
                Console.ForegroundColor = MapColor(code);
            else
                Console.ResetColor();

            Console.Write(text);
        }
        Console.WriteLine();
    }

    static ConsoleColor MapColor(int ansiCode)
    {
        return ansiCode switch
        {
            30 => ConsoleColor.Black,
            31 => ConsoleColor.Red,
            32 => ConsoleColor.Green,
            33 => ConsoleColor.Yellow,
            34 => ConsoleColor.Blue,
            35 => ConsoleColor.Magenta,
            36 => ConsoleColor.Cyan,
            37 => ConsoleColor.White,
            _ => ConsoleColor.White
        };
    }
}