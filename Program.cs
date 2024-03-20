namespace FicheroSobreescribirLinea_Posicion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rutaArchivo = "archivo.txt";
            Console.WriteLine("Ingrese el numero de una linea");
            int numeroLinea = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de posicion");
            int numeroPosicion = Convert.ToInt32(Console.ReadLine());  
            Console.WriteLine("Ingrese el texto que deseas");
            string nuevoTexto = Console.ReadLine();

            using (StreamWriter writter = new StreamWriter(rutaArchivo))
            {
                writter.WriteLine(
                    "Linea 1\n" +
                    "Linea 2\n" +
                    "Linea 3\n" +
                    "Linea 4\n" +
                    "Linea 5\n" +
                    "Linea 6\n" );
            }
            try
            {
                // Leer todas las líneas del archivo
                string[] leerLineas = File.ReadAllLines(rutaArchivo);
                
                if (numeroLinea >= 1 && numeroLinea <= leerLineas.Length)
                {

                    string linea = leerLineas[numeroLinea - 1];

                   if(numeroPosicion >=0 && numeroPosicion <=linea.Length ) 
                    {
                        string nuevaLinea = linea.Insert(numeroPosicion, nuevoTexto);
                        // Reemplazar la línea original con la línea modificada
                        leerLineas[numeroLinea - 1] = nuevaLinea;

                        // Sobrescribir el archivo con las líneas actualizadas
                        File.WriteAllLines(rutaArchivo, leerLineas);

                        Console.WriteLine("El texto se ha escrito correctamente en la posición especificada de la línea.");
                    }
                }
                else
                {
                    Console.WriteLine("Fuera de rango");
                }

            } catch (IOException e)
            {
                Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);
            }
        }
    }
}
