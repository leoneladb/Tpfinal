﻿using System.Collections;
using System;
namespace clases{
	public class ClubDeportivo
	{
		private ArrayList listSocio = new ArrayList();
		private ArrayList listDeportes = new ArrayList();

		public ClubDeportivo(ArrayList listSocio, ArrayList listDeportes)
		{
			this.listDeportes = listDeportes != null ? listDeportes : new ArrayList();
			this.listSocio = listSocio != null ? listSocio : new ArrayList();
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
			foreach (Deporte d6 in ListDeportes)
			{
				if (d6.NombreDeporte == deporte.NombreDeporte)
				{
					return;
				}
			}
			ListDeportes.Add(deporte);
		}

		public Entrenador buscarEntrenador(int dni)
		{
			foreach (Deporte d23 in listDeportes)
			{
				if (d23.Entrenador.Dni == dni)
				{
					return d23.Entrenador;
				}

			}
			return null;
		}

		public bool buscarDeporte(string nombreDelDeporte)
		{
			foreach (Deporte d7 in this.ListDeportes)
			{
				if (d7.NombreDeporte == nombreDelDeporte)
				{
					return true;
				}
			}
			return false;
		}


		public void agregarSocio(Socio socio)
		{
			ListSocio.Add(socio);
		}



		public Socio buscarSocio(int dni)
		{
			foreach (Socio s2 in listSocio)
			{
				if (s2.Dni == dni)
				{
					return s2;
				}
			}
			return null;
		}
		
	}
}

