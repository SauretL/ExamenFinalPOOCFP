using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesPOO
{
    public class Lavadora : Electrodomestico
    {
        //Atributos

        public decimal capacidadKilos;
        public TipoLavadora tipo; 

        //Constante Interna

        private const decimal FACTOR_CARGA = 0.75m;

        //Constructores
        public Lavadora(int id, string marca, string modelo, decimal consumoBaseWatts, decimal capacidadKilos)
           : base(id, marca, modelo, consumoBaseWatts)
        {
            this.capacidadKilos = capacidadKilos;
            this.tipo = TipoLavadora.DOMESTICA;
        }

        public Lavadora(int id, string marca, string modelo, decimal consumoBaseWatts, decimal capacidadKilos, TipoLavadora tipo)
          : base(id, marca, modelo, consumoBaseWatts)
        {
            this.capacidadKilos = capacidadKilos;
            this.tipo = tipo;
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

        public override decimal CalcularCostoMensual(int horasDiarias, decimal costoPorWatt)
        {

            decimal consumoReal = consumoBaseWatts + capacidadKilos * FACTOR_CARGA * (int)tipo;

            decimal costoMensual = consumoReal * horasDiarias * 30 * costoPorWatt;
            return costoMensual;
        }

        // Metodo Extra

        public string IniciarCicloLavado()
        {
            string txt = $"===INICIANDO CICLO DE LAVADO===\nTipo de ciclo: {this.tipo}\nCapacidad de Kilos dentro del lavarropa: {this.capacidadKilos}kg.";
            return txt;
        }

    }
}
