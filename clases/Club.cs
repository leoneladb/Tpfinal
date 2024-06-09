using System.Collections;
using System;
namespace clases{
	public class ClubDeportivo
	{
		private ArrayList listSocio = new ArrayList();
		private ArrayList listDeportes = new ArrayList();

		public ClubDeportivo(ArrayList listSocio, ArrayList listDeportes)
		{
			
			this.listDeportes = listDeportes;
			this.listDeportes = listSocio;
		}

		public ArrayList ListSocio
		{
			get { return listSocio; }
		}

		public ArrayList ListDeportes
		{
			get { return listDeportes; }
		}
		
		public void agregarDeporte(Deporte deporte)
		{
			foreach (Deporte d6 in ListDeportes) {
				if(d6.NombreDeporte == deporte.NombreDeporte)
				{
				   return;
				}
			}
			ListDeportes.Add(deporte);
		}
		
		public bool agregarEntrenador (Entrenador entrador, string deporte, DateTime categoria)
		{
			foreach (Deporte a in this.listDeportes) {
				if(a.NombreDeporte == deporte && a.Categoria.Year == categoria.Year && a.Entrenador == null)
				{
					a.Entrenador = entrador;
					return true;
				}
			}
			return false;
		}
		
		public bool eliminarEntrenador(int dni){
			
			foreach (Deporte b in this.listDeportes) {
				if(b.Entrenador.Dni == dni)
				{
					Console.WriteLine("DENTRO DE LA CLASE CLUB " + b.Entrenador.Nombre +  b.Entrenador.Dni);
					b.Entrenador = null;
					return true;
				}
			}
			return false;
			
			
		}
		
		public void eliminarDeport(string nombreDeporte){
		   foreach (Deporte d5 in ListDeportes) {
				if(d5.NombreDeporte == nombreDeporte && d5.CantidadInscriptos == 0){
					ListDeportes.Remove(d5);
				}
		   }
		}
		
		public bool buscarDeporte(string nombreDelDeporte){
		   foreach (Deporte d7 in this.ListDeportes) {
				if(d7.NombreDeporte == nombreDelDeporte)
				{
				return true;
				}
		   }
			return false;
		}
		
		
		public bool agregarSocio (Socio socio, string deporte)
		{
			DateTime fechaActual = DateTime.Now;
			DateTime categoria = new DateTime(fechaActual.Year - socio.Edad, 3, 3);
			try{
				foreach (Deporte c in listDeportes) {
					if (c.Cupo < 0)
					{
						throw new ExceptionCupoSocio("No hay cupos");
					}
					if(c.Cupo > 0 && c.NombreDeporte == deporte && categoria.Year == c.Categoria.Year){
						ListSocio.Add(socio);
						c.Cupo--;
						c.CantidadInscriptos++;
						return true;
					}
				}
			}
			catch(ExceptionCupoSocio ex3)
			{
				Console.WriteLine(ex3.Message);
			}
			return false;
		}
		
		public bool eliminarSocio (int dni, string deporte)
		{
			foreach (Deporte e in listDeportes) {
				if (e.NombreDeporte == deporte)
				{
					foreach (Socio d in listSocio) {
						if(d.Dni == dni){
							ListSocio.Remove(d);  // lista que tiene la clase club
							d.Deportes.Remove(e); // lista que tiene el objeto socio
							e.CantidadInscriptos--;
							e.Cupo++;
							return true;
						}
					}
				}
			}
			return false;
			
		}
		
		public Socio buscarSocio(int dni)
		{
			foreach (Socio s2 in listSocio) {
				if(s2.Dni == dni)
				{
					return s2;
				}
			}
			return null;
		}
		
		public bool PagarCuota(double montoCuota, int dni, string nombreDeporte, ClubDeportivo club)
		{
			double montoPorMes = 0;
			foreach (Deporte x in club.ListDeportes) {
				if(x.NombreDeporte == nombreDeporte)
				{
				   montoPorMes = x.Costo;
				}
			}
			bool validador =  false;
			int descuento = 0;
			Deporte deporte;
			Socio socio = buscarSocio (dni);
			if (socio == null)
			{
				return validador;
			}
			if (socio != null){
			foreach (Deporte d2 in socio.Deportes) {
				if(d2.NombreDeporte == nombreDeporte)
				{
					deporte = d2;
					
					// Descueto por categoria
					if(deporte.Categoria.Year < 2000)
					{
						descuento = 10;
					}
					else if (deporte.Categoria.Year >= 2000 || deporte.Categoria.Year < 2005)
					{
						descuento = 15;
					}
					else if (deporte.Categoria.Year >= 2005 || deporte.Categoria.Year < 2010)
					{
						descuento = 20;
					}
					else if (deporte.Categoria.Year >= 2010)
					{
						descuento = 25;
					}
					// Descuesto por deporte
					if (nombreDeporte == "futbol" || nombreDeporte == "voley"){
						descuento = descuento + 3;
					}
					else if (nombreDeporte == "Tenis" || nombreDeporte == "handball"){
						descuento = descuento + 4;
					}
					else if (nombreDeporte == "Hockey" || nombreDeporte == "Rugby"){
						descuento = descuento + 5;
					}
					
					
					double descuentoTotal =  (montoPorMes - ((12000 / 100) * descuento));
					try{
					if ((descuentoTotal - montoCuota) < 0)
					{
						DateTime fechaActual = DateTime.Now;
						socio.MesPago = fechaActual.Month; 
					}
					else{
						throw new ExceptionMontoInsuficiente("El monto no es sufiente para cubrir la Cuota");
					}
					}
					catch (ExceptionMontoInsuficiente ex4)
					{
						Console.WriteLine(ex4.Message);
					}
					validador = true;
					return validador;
				}
			}
			}
			
			
			
			return validador;
		}
		
		
		
		
		
		
		
		
		
		
	}
}

