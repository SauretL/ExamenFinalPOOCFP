using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPOO
{
    internal class Lavadora : Electrodomestico
    {
        //Atributos

        private decimal capacidadKilos;
        TipoLavadora tipo; 

        //Constante Interna

        private double FACTOR_CARGA = 0.75;

        //Constructores
        public Lavadora(string marca, string modelo, decimal consumoBaseWatts, decimal capacidadKilos)
           : base(marca, modelo, consumoBaseWatts)
        {
            CapacidadKilos = capacidadKilos;
            Tipo = TipoLavadora.DOMESTICA;
        }

        public Lavadora(string marca, string modelo, decimal consumoBaseWatts, decimal capacidadKilos, TipoLavadora tipo)
          : base(marca, modelo, consumoBaseWatts)
        {
            capacidadKilos = CapacidadKilos;
            tipo = Tipo;
        }

        // Propiedad abstracta del padre

        public override string CategoriaEnergetica 
        {
            get 
            {
                switch(tipo)
                {
                    case TipoLavadora.INDUSTRIAL:
                        return "Industrial";
                    case TipoLavadora.SEMIINDUSTRIAL:
                        return "Comercial";
                    default:
                        return "Hogar";
                }
            }
        }

        //Metodo abstracto del padre

        public override decimal CalcularCostoMensual(int horasDiarias, decimal costoPorWatt, double ValorDelTipo, double Kilos)
        {
            decimal consumoReal = consumoBaseWatts + (decimal)(Kilos * FACTOR_CARGA * ValorDelTipo);

            decimal costoMensual = consumoReal * horasDiarias * 30 * costoPorWatt;
            return costoMensual;
        }

        // Metodo Extra

        public string IniciarCicloLavado(double kilos, string tipoDeCiclo)
        {
            string txt = $"===INICIANDO CICLO DE LAVADO===\nTipos de ciclo: {tipoDeCiclo}\nKilos dentro del lavarropa: {kilos}kg.";
        }

    }
}
