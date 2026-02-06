namespace CalculadoraCompletaJZ
{
    public partial class MainPage : ContentPage
    {
        string entrada = "";
        double valorAnterior = 0;
        string operador = "";
        bool nuevoValor = true;

        public MainPage()
        {
            InitializeComponent();
            lblResultado.Text = "0";
        }

        private void Numero_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            if (nuevoValor)
            {
                entrada = "";
                nuevoValor = false;
            }

            // evitar ceros extras
            if (boton.Text == "0" && (entrada == "" || entrada == "0"))
            {
                entrada = "0";
            }
            else if (entrada == "0")
            {
                entrada = boton.Text;
            }
            else
            {
                entrada += boton.Text;
            }

            lblResultado.Text = entrada;
        }

        private void Punto_Clicked(object sender, EventArgs e)
        {
            if (nuevoValor)
            {
                entrada = "0";
                nuevoValor = false;
            }
            if (!entrada.Contains("."))
            {
                if (string.IsNullOrEmpty(entrada))
                    entrada = "0";
                entrada += ".";
                lblResultado.Text = entrada;
            }
        }

        private void Modulo_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entrada))
            {
                double valor = double.Parse(entrada);
                valor = valor / 100;
                entrada = valor.ToString();
                lblResultado.Text = entrada;
                nuevoValor = true;
            }
        }

        private void Operador_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            if (!string.IsNullOrEmpty(entrada))
            {
                valorAnterior = double.Parse(entrada);
                operador = boton.Text;
                nuevoValor = true;
            }
        }

        private void Igual_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entrada) && !string.IsNullOrEmpty(operador))
            {
                double valorActual = double.Parse(entrada);
                double resultado = 0;

                switch (operador)
                {
                    case "+":
                        resultado = valorAnterior + valorActual;
                        break;
                    case "-":
                        resultado = valorAnterior - valorActual;
                        break;
                    case "×":
                        resultado = valorAnterior * valorActual;
                        break;
                    case "÷":
                        resultado = valorActual != 0 ? valorAnterior / valorActual : double.NaN;
                        break;
                }

                if (double.IsNaN(resultado))
                {
                    lblResultado.Text = "Error";
                    entrada = "";
                }
                else
                {
                    // se limita la cantidad de numeros despes del punto
                    entrada = resultado.ToString();
                    if (entrada.Contains(".") && entrada.Length > 10)
                    {
                        
                        entrada = resultado.ToString("0.#######");
                    }
                    lblResultado.Text = entrada;
                }

                operador = "";
                nuevoValor = true;
            }
        }

        private void Borrar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entrada) && entrada.Length > 0)
            {
                entrada = entrada.Substring(0, entrada.Length - 1);
                lblResultado.Text = entrada.Length > 0 ? entrada : "0";
            }
        }

        private void AC_Clicked(object sender, EventArgs e)
        {
            entrada = "";
            valorAnterior = 0;
            operador = "";
            lblResultado.Text = "0";
            nuevoValor = true;
        }
    }
}