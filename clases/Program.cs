using System;
using System.Collections;

namespace clases
{
	class Program
	{
		static void Main(string[] args)
		{
			// (string nombreDeporte, DateTime categoria, Entrenador entrenador, 
			// int cupo, int cantidadInscriptos, double costo, string horario)
			
			ArrayList listDeportes = new ArrayList();	
			ArrayList listSocio = new ArrayList();
			
			ClubDeportivo club = new ClubDeportivo(listSocio, listDeportes);
			while (true) {
				Console.Clear();
				string opcion = menuInfo();
				if(opcion == "x")
				{
					break;
				}
				Menu(club, opcion);
				Console.ReadKey();
			}
								
			
		}
		
		
		static public string menuInfo ()
		{
			Console.WriteLine("Menú:");
			Console.WriteLine("a- Agregar a un entrenador");
			Console.WriteLine("b- Dar de baja a un entrenador");
			Console.WriteLine("c- Agregar a un niño/socio en un deporte");
			Console.WriteLine("d- Dar de baja a un niño/socio en un deporte");
			Console.WriteLine("e- Simular el pago de una cuota");
			Console.WriteLine("f- Submenú de inscripción:");
			Console.WriteLine("g- Listado de deudores");
			Console.WriteLine("h- Agregar un deporte");
			Console.WriteLine("i- Eliminar un deporte");
			Console.WriteLine("x- Salir");

			Console.Write("Seleccione una opción: ");
			string opcion = Console.ReadLine();
			return opcion;
		}
		
		static public void Menu(ClubDeportivo club, string opcion){
			try{
				switch (opcion) {
					case "a":
						Entrenador entrador = pedirDatos();
						Console.WriteLine("Ingrese el nombre del deporte");
						string nombreDeporte2 = Console.ReadLine();
						if(club.buscarDeporte(nombreDeporte2)){
							Console.WriteLine("Ingrese la categoria aaaa (año)");
							int categoriaAño = int.Parse(Console.ReadLine());
							DateTime categoria2 = new DateTime(categoriaAño,3,3);
							if(club.agregarEntrenador(entrador, nombreDeporte2, categoria2)){
								Console.WriteLine("El entrenador se agrego correctamente");
							}
							else{
							Console.WriteLine("Este deporte ya tiene entrenador");
							}
							
						}
						else{
							Console.WriteLine("El deporte ingresado no se encontro en la lista");
						}
						break;
					case "b":
						Console.WriteLine("Ingrese el Dni del Entrenador");
						int dni = int.Parse(Console.ReadLine());
						if(club.eliminarEntrenador(dni)){
							Console.WriteLine("Se dio de baja correctamente");
						}
						else{
						Console.WriteLine("El entrenador ya estaba dado de baja");
						}
						break;
					case "c":
						Socio socio = pedirDatosSocio();
						Console.WriteLine("Ingrese el nombre del deporte");
						string nombreDeporte3 = Console.ReadLine();
						club.agregarSocio(socio, nombreDeporte3);
						break;
					case "d":
						Console.WriteLine("Ingrese su dni");
						int dni2 = int.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese su nombre del deporte");
						string nombreDeporte4 = Console.ReadLine();
						club.eliminarSocio(dni2, nombreDeporte4);
						break;
					case "e":
						// PagarCuota(double montoCuota, int dni, string nombreDeporte, ClubDeportivo club)
						Console.WriteLine("Ingrese el monto a depositar");
						double montoCuota = double.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese su dni");
						int dni3 = int.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese nombre del deporte");
						string nombreDeporte5 = Console.ReadLine();
						club.PagarCuota(montoCuota, dni3, nombreDeporte5, club);
						break;
					case "f":
						Console.WriteLine("Ingrese una opcion");
						Console.WriteLine("1 - Por deporte");
						Console.WriteLine("2 - Por deporte y categoría");
						Console.WriteLine("3 - Total");
						int opcion2 = int.Parse(Console.ReadLine());
						switch (opcion2) {
							case 1:
								ListarInscriptosPorDeporte(club);
								break;
							case 2:
								ListarInscriptosPorDeporteYCategoría(club);
								break;
							case 3:
								imprimirTotalIncriptos(club);
								break;
								
						}
						break;
					case "g":
						if(club.ListSocio == null || club.ListSocio.Count == 0 )
						{
							Console.WriteLine("La lista esta vacia");
						}
						else{
						imprimirDeudores(club);
						}
						break;
					case "h":
						agregarDeporte(club);
						break;
					case "i":
						Console.WriteLine("Ingrese el nombre del deporte");
						string nombreDeporte6 = Console.ReadLine();
						club.eliminarDeport(nombreDeporte6);
						break;
				}
			}
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
			}
			
		}
		
		static public void ListarInscriptosPorDeporte(ClubDeportivo club)
		{
			foreach (Deporte d3 in club.ListDeportes) { //recorro la lista de deportes
				Console.WriteLine("Inscriptos en el deporte " + d3.NombreDeporte + ":");
				foreach (Socio s in club.ListSocio) { // recorro la lista de socios
					foreach (Deporte d in s.Deportes) { //por cada socio recorro su lista de deportes
						if(d.NombreDeporte == d3.NombreDeporte){
							Console.WriteLine("Nombre: {0}, Dni: {1}, Edad{2}",s.Nombre,s.Dni,s.Edad);
							break;
						}
						
					}
				}
			}
			
		}
		
		static public void ListarInscriptosPorDeporteYCategoría(ClubDeportivo club)
		{
			
			foreach (Deporte d3 in club.ListDeportes) { //recorro la lista de deportes
				Console.WriteLine("Inscriptos en el deporte " + d3.NombreDeporte + ":");
				foreach (Socio s in club.ListSocio) { // recorro la lista de socios
					foreach (Deporte d in s.Deportes) { //por cada socio recorro su lista de deportes
						if(d.NombreDeporte == d3.NombreDeporte && d.Categoria == d3.Categoria){
							Console.WriteLine("Nombre: {0}, Dni: {1}, Edad{2}",s.Nombre,s.Dni,s.Edad);
							break;
						}
						
					}
				}
			}
			
		}
		// int edad, string nombre, int dni, ArrayList deportes, int categoria, int mesPago
		static public Socio pedirDatosSocio(){
			Console.WriteLine("ingrese su edad");
			int edad2 = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese su nombre");
			string nombre2 = Console.ReadLine();
			Console.WriteLine("Ingrese su Dni");
			int dni2 = int.Parse(Console.ReadLine());
			ArrayList listaDeportes = new ArrayList();
			Console.WriteLine("Ingrese su año de nacimiento");
			int categoriaAño2 = int.Parse(Console.ReadLine());
			DateTime categoria3 = new DateTime(categoriaAño2,3,3);
			DateTime fechaActual = DateTime.Now;
			
			Socio socio = new Socio(edad2, nombre2, dni2, listaDeportes, categoriaAño2, fechaActual.Month);
			return socio;
		}
		
		
		static public void imprimirTotalIncriptos(ClubDeportivo club)
		{
			foreach (Socio s3 in club.ListSocio) {
				Console.WriteLine("Nombre: {0}, Dni: {1}, Edad{2}",s3.Nombre,s3.Dni,s3.Edad);
			}
		}
		
		
		static public void imprimirDeudores(ClubDeportivo club){
			DateTime fechaActual = DateTime.Now;
			foreach (Socio s4 in club.ListSocio) {
				if(fechaActual.Month > s4.MesPago){
					Console.WriteLine("Deudores: ");
					Console.WriteLine("Nombre: {0}, Dni: {1}, Edad{2}",s4.Nombre,s4.Dni,s4.Edad);
				}
			}
		}
		
		// string nombreDeporte, DateTime categoria, Entrenador entrenador, int cupo,
		// int cantidadInscriptos, double costo, string horario
		static public void agregarDeporte(ClubDeportivo club){
			Console.WriteLine("ingrese el nombre del deporte");
			string nombreDeporte = Console.ReadLine();
			try{
				Console.WriteLine("Ingrese la categoria aaaa (año)");
				int año = int.Parse(Console.ReadLine());
				DateTime categoria = new DateTime(año,3,3);
				Console.WriteLine("Ingrese los datos del entreador para el deporte");
				Entrenador entrenador = pedirDatos();
				Console.WriteLine("Ingrese la cantidad de cupos del deporte");
				int cupo = int.Parse(Console.ReadLine());
				int cantidadIncriptos = 0;
				Console.WriteLine("Ingrese el costo del deporte");
				double costo = double.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese el horario del deporte");
				string horario = Console.ReadLine();
				
				Deporte deporte = new Deporte(nombreDeporte, categoria, entrenador, cupo, cantidadIncriptos, costo, horario);
				
				Console.WriteLine("EL DNI ES:" + entrenador.Dni);
				Console.ReadKey();
				club.agregarDeporte(deporte);
				Console.WriteLine("El deporte se agrego correctamente");
			}
			catch(FormatException ex){
				Console.WriteLine(ex.Message);
			}
			
		}
		
		static public Entrenador pedirDatos()
		{
			int edad2, dni2;
			Console.WriteLine("Ingrese su nombre");
			string nombre = Console.ReadLine();
			try{
				Console.WriteLine("ingrese su edad");
				string edadTexto = Console.ReadLine();
				bool valor = int.TryParse(edadTexto, out edad2);
				if (valor)
				{
					Console.WriteLine("ingrese su dni");
					string dniTexto = Console.ReadLine();
					bool valor2 = int.TryParse(dniTexto, out dni2);
					if(valor2)
					{
						Entrenador entrenador = new Entrenador(dni2, nombre, edad2);
						Console.WriteLine("EL DNI DENTRO DE PEDIR DATOS:" + entrenador.Dni);
						Console.ReadKey();
						return entrenador;
					}
					else{
						throw new ExceptionDniInvalido ("El dni ingresado en invalido");
					}
				}
				else{
					throw new ExceptionEdadInvalida("La edad ingresada es invalida");
				}
				
			}
			
			catch (ExceptionEdadInvalida ex){
				Console.WriteLine(ex.Message);
			}
			catch (ExceptionDniInvalido ex2){
				Console.WriteLine(ex2.Message);
			}
			return null;
		}
				
	}
		
}

