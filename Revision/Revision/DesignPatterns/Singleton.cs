using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.DesignPatterns
{
    //Singleton Class
    class Singleton
    {
        //Singleton Instance
        private static Singleton Instance { get; set; } = null;
        //Static method that returns Instance.
        public static Singleton GetSingleton()
        {
            if(Instance == null)
                Instance = new Singleton();
            return Instance;
        }
    }
}
