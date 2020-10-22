using Memento;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Memento_.Data
{
    public static class RunTimeData
    {
        public static List<Item> MemorizableItems { get; set; }

        static RunTimeData()
        {
            StaticData.Load();
        }
    }
}
