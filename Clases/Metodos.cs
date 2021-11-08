using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXAMEN.Clases
{
    public class Metodos
    {
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            if (fechaNacimiento > fechaActual)
            {
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }
    }
}
