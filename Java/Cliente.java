import java.rmi.*;

public class Cliente {
    //instancia local do objeto remoto - utilidade da interface é aqui

    InterfaceRMICalc calc;

    public Cliente()
    {
        try{
            System.out.println("A iniciar Cliente");

            calc=(InterfaceRMICalc) Naming.lookup("rmi://127.0.0.1/Calculadora"); //calculadora é o nome da aplicaçao que registamos no servidor local

        }catch (Exception e)
        {
            System.out.println("Erro!"+e.toString());
        }
    }

    //metodo remoto
    public double CalculaArea(double a, double b) throws RemoteException
    {
        return calc.Multiplicacao(a,b);
    }

    public static void main(String argv[])
    {
        Cliente c=new Cliente();
        //calcular a area de um campo de 10m X 14m

        try{
            System.out.println("A area de 10m X 14 m= "+c.CalculaArea(10.0,14.0));
        }catch(Exception e)
        {
            System.out.println("Erro!"+e.toString());
        }

    }
}
