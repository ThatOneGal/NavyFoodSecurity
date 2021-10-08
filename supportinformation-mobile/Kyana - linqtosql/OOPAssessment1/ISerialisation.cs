using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssessment1
{
    interface ISerialisation
    {
        void Serialise(List<Recipe> favList);

        List<Recipe> Deserialise();

    }
}
