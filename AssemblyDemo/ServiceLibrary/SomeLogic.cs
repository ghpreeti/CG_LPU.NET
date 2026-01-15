using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class SomeLogic
    {
        #region Attributes
        int id;
        string name;
        string addr;
        #endregion

        #region Properties 
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Addr
        {
            get { return addr; }
            set { addr = value; }
        }

        #endregion

        #region Methods
        public SomeLogic() { }
        public SomeLogic(int yourId, string yourName, string yourAddress)
        {
            
        }

        public int AddMe(int num1,int num2)
        {
            return num1 + num2;
        }
        public List<Object> ShowAll() { 
        
            return new List<Object>();
        }

        public List<Player> ShowAllPlayer()
        {
            return new List<Player>()
            {
                new Player(){ PlayerId=1, PlayerName="Virat", Skills=new List<string>(){"Batsman","Fielder"} },
                new Player(){ PlayerId=2, PlayerName="Mike", Skills=new List<string>(){"Passing","Dribbling"} },
                new Player(){ PlayerId=3, PlayerName="Sara", Skills=new List<string>(){"Defending","Heading"} }
            };
        }
        #endregion
    }
}
