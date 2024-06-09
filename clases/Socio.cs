using System;
using System.Collections;

public class Socio : Persona
{
	private ArrayList deportes;
	private int categoria;
	private int mesPago;
	
	public Socio(int edad, string nombre, int dni, ArrayList deportes, int categoria, int mesPago) : base(edad, nombre, dni)
	{
		this.deportes = new ArrayList();
		this.deportes = deportes;
		this.categoria = categoria;
		this.mesPago = mesPago;
	}

	public ArrayList Deportes
	{
		get { return deportes; }
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