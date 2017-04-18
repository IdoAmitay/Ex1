using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class MyView : IView
    {
        private IController c;
        public MyView(IController c)
        {
            this.c = c;
        }
        public void GetCommand(string s)
        {
            throw new NotImplementedException();
        }

        public void ShowResult(string s)
        {
            throw new NotImplementedException();
        }
    }
}
