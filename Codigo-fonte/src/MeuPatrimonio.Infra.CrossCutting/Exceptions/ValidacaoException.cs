using MeuPatrimonio.Infra.CrossCutting.Types;
using System;
using System.Collections.Generic;

namespace MeuPatrimonio.Infra.CrossCutting.Exceptions
{
    public class ValidacaoException : Exception
    {
        public IList<Mensagem> InvalidMessages;

        public ValidacaoException(IList<Mensagem> invalidMessages)
        {
            InvalidMessages = invalidMessages;
        }
    }
}
