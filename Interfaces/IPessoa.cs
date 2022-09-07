using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.Interfaces
{
    public interface IPessoa
    {
        float CalcularImposto(float rendimento);
    }
}