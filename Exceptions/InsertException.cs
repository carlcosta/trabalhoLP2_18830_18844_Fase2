using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class InsertException : ApplicationException
    {
        #region Constructors
        public InsertException() : base("insercao invalida")
        {
        }

        public InsertException(string s) : base(s)
        {
        }

        public InsertException(string s, Exception e)
        {
            throw new InsertException("ERRO:" + s + "-" + e.Message);
        }

        

        #endregion
    }
}
