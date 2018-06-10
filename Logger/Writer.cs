using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public static class Writer
    {

        public static void Write(string type, string message, string application )
        {
            Console.WriteLine($"{type} | {message} | {application}");
        }

    }
}
