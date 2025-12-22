using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    interface IAdd
    { int AddMe(int a, int b); }

    interface ISub
    { int SubMe(int a, int b); }

    interface IProd
    { int ProdMe(int a, int b); }

    interface IDiv
    { float DivMe(int a, int b); }

    interface IAddSub : IAdd, ISub { }
    interface IAddProdDiv : IAdd, IProd, IDiv { }
    interface IAll : IAdd, ISub, IProd, IDiv { }



}
