import java.rmi.*;

public interface InterfaceRMICalc extends Remote
{
	public double Soma(double num1,double num2) throws RemoteException;
	public double Subtracao(double num1,double num2) throws RemoteException;
	public double Multiplicacao(double num1,double num2) throws RemoteException;
	public double Divisao(double num1,double num2) throws RemoteException;
}