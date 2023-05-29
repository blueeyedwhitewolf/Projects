import java.rmi.*;

public class ServidorPrincipal
{
	public static void main(String argv[])
	{
		try{
			System.out.println("A iniciar servidor");

			Naming.rebind("Calculadora",new CalculadoraRemota());

		}catch(Exception e)
		{
			System.out.println("Erro!\n"+e.toString());
		}
	}
}