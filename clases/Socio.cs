﻿using System;
using System.Collections;

public class Socio : Persona
{
	private ArrayList referenciasDeportes;
	private ArrayList nombresDeDeportesAnotado;
	private int categoria;
	private int mesPago;

	public Socio(int edad, string nombre, int dni, ArrayList referenciasDeportes, int categoria, int mesPago, ArrayList nombresDeDeportesAnotado) : base(edad, nombre, dni)
	{
		this.nombresDeDeportesAnotado = nombresDeDeportesAnotado != null ? nombresDeDeportesAnotado : new ArrayList();
		this.referenciasDeportes = referenciasDeportes != null ? referenciasDeportes : new ArrayList();
		this.categoria = categoria;
		this.mesPago = mesPago;
	}

	public ArrayList ReferenciasDeportes
	{
		get { return referenciasDeportes; }
	}

	public ArrayList NombresDeDeportesAnotado
	{
		get { return nombresDeDeportesAnotado; }
	}

	public int Categoria
	{
		get { return categoria; }
		set { categoria = value; }
	}
	public int MesPago
	{
		get { return mesPago; }
		set { mesPago = value; }

	}

	
}