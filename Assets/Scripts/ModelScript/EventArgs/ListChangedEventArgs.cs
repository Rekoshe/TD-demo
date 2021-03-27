using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ModelScript.EventArgs
{
    public class ListChangedEventArgs : System.EventArgs
    {
        public Enemy enemy;
        public ListChangedEventArgs(Enemy enemy)
        {
            this.enemy = enemy;
        }
    }
}
