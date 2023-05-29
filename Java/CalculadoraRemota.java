import java.rmi.*;
import java.rmi.server.*;

public class CalculadoraRemota 
				extends UnicastRemoteObject
				implements InterfaceRMICalc
{
	public CalculadoraRemota() throws RemoteException
	{
		//Também pode lançar exceecoes do tipo remote exception

		System.out.println("A iniciar Objeto remoto"); //por questoes de debugging
	}

	public double Soma(double num1,double num2) throws RemoteException
	{
		return num1+num2;
	}
	
	public double Subtracao(double num1,double num2) throws RemoteException
	{
		return num1-num2;
	}

	public double Multiplicacao(double num1,double num2) throws RemoteException
	{
		System.out.println("A multiplicar numeros"+num1+"*"+num2);
		return num1*num2;
	}

	public double Divisao(double num1,double num2) throws RemoteException
	{
		return num1/num2;
	}
}