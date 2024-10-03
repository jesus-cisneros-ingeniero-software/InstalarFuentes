/*
 * Created by SharpDevelop.
 * User: JCISNEROS
 * Date: 02/10/2024
 * Time: 11:19 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using Microsoft.Win32;

namespace InstalarFuentes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Lista de fuentes a instalar (puedes agregar más rutas aquí)
                string[] fuentes = new string[]
                {
                    @"\\10.3.12.10\Fuentes_2024\Geomanist-Black.otf",
					@"\\10.3.12.10\Fuentes_2024\Geomanist-Bold.otf",
					@"\\10.3.12.10\Fuentes_2024\Geomanist-Book.otf",
					@"\\10.3.12.10\Fuentes_2024\Geomanist-Thin.otf",                    
					@"\\10.3.12.10\Fuentes_2024\Geomanist-Ultra.otf",
					@"\\10.3.12.10\Fuentes_2024\Geomanist-ExtraLight.otf",
					@"\\10.3.12.10\Fuentes_2024\Geomanist-Light.otf",
					@"\\10.3.12.10\Fuentes_2024\Geomanist-Medium.otf",
					@"\\10.3.12.10\Fuentes_2024\Geomanist-Regular.otf",
					@"\\10.3.12.10\Fuentes_2024\Geomanist-Regular-Italic.otf"

                     
                     
                  	
                };

                foreach (var fuenteOrigen in fuentes)
                {
                    // Nombre de la fuente (puedes ajustar esto según cada fuente)
                    string nombreFuente = Path.GetFileNameWithoutExtension(fuenteOrigen);
                    string fuenteDestino = Path.Combine(@"C:\Windows\Fonts\", Path.GetFileName(fuenteOrigen));

                    // 1. Copiar la fuente al directorio de fuentes de Windows
                    if (!File.Exists(fuenteDestino))
                    {
                        File.Copy(fuenteOrigen, fuenteDestino);
                        Console.WriteLine("Fuente copiada correctamente: " + nombreFuente);
                    }
                    else
                    {
                        Console.WriteLine("La fuente " + nombreFuente + " ya existe en el directorio de fuentes.");
                    }

                    // 2. Registrar la fuente en el Registro de Windows
                    string fuenteKey = nombreFuente + " (TrueType)";
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", true))
                    {
                        if (key != null)
                        {
                            key.SetValue(fuenteKey, Path.GetFileName(fuenteDestino));
                            Console.WriteLine("Fuente registrada correctamente en el registro: " + nombreFuente);
                        }
                        else
                        {
                            Console.WriteLine("Error al acceder al registro para la fuente: " + nombreFuente);
                        }
                    }
                }

                // Pausa para ver los mensajes antes de cerrar el programa
                Console.WriteLine("Presiona cualquier tecla para salir...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Presiona cualquier tecla para salir...");
                Console.ReadKey(); // Pausa en caso de error también
            }
        }
    }
}

                     
                     
                     
               
                 