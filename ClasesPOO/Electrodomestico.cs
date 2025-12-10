namespace ClasesPOO
{
    //Enumerados
    public enum TipoLavadora
    {
        DOMESTICA = 1, 
        SEMIINDUSTRIAL = 2,
        INDUSTRIAL = 3

    }

    public enum ResolucionTV {
        HD = 1, 
        FULLHD = 2,
        ULTRAHD_4K = 4,
        ULTRAHD_8K = 16
            }

    public abstract class Electrodomestico
    {
        //Atributos

        protected int id;
        protected string marca;
        protected string modelo;
        protected decimal consumoBaseWatts;

        //Constructor

        public Electrodomestico(int id, string marca, string modelo, decimal consumoBaseWatts)
        {
            this.id = id;
            this.marca = marca;
            this.modelo = modelo;
            this.consumoBaseWatts = consumoBaseWatts;
        }

        //Atributo Abstracto

        public abstract string CategoriaEnergetica { get; }

        //Metodo Abstracto

        public abstract decimal CalcularCostoMensual(int horasDiarias, decimal costoPorWatt);

        //Metodo no abstracto

        public string ObtenerInformacion()
        {
            string info = $"Marca = {marca} \nModelo: {modelo} \nConsumo Base de Watts: {consumoBaseWatts}";
            return info;
        }

    }
}
