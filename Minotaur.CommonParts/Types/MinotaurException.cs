using System;

namespace Minotaur.CommonParts.Types
{
    public class MinotaurException : Exception
    {
        public string Code { get; }

        public MinotaurException()
        {
        }

        public MinotaurException(string code)
        {
            Code = code;
        }

        public MinotaurException(string message, params object[] args) 
            : this(string.Empty, message, args)
        {
        }

        public MinotaurException(string code, string message, params object[] args) 
            : this(null, code, message, args)
        {
        }

        public MinotaurException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public MinotaurException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}
