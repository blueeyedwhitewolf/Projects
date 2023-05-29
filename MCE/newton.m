function sol=newton(a,b,error)
 % a e b s�o os extremos do intervalo no qual se encontra a solu��o
 % NumberIterations denota o n.� de intera��es necess�rias para determinar
 % a solu��o com um erro inferior a error
 
     NumberIterations = 10; %Faz menos intera��es que o da bisse�ao por isso 10 � suficiente
     it=1;
     
     function y=f(x);  %define-se a fun��o dentro de uma fun��o
       y=exp(x)-3*x;
     endfunction
     
     %Primeira derivada
     function y=df(x)
     y=exp(x)*3;
     endfunction
     
     %Segunda derivada
     function y=ddf(x)
     y=exp(x);
     endfunction
     
     
     %Definir ponto inicial (ou a ou b) -- f(a) e ddf(a) t�m de ter sinais =
     if f(a)* ddf(a)>0
       xantes=a;
     else
       xantes=b;
     endif 
     
     %Cabe�alho
     fprintf('\n Metodo de Newton no intervalo: [%f, %f]\n',a,b);
     fprintf('      i            xi              |f(x)| \n');
     
     while ((abs(f(xantes))>error)&&(it<=NumberIterations));
       
       xseg=xantes-(f(xantes)/df(xantes));
       fprintf('    %3d           %.10f     %.10f\n', it,xseg,abs(f(xseg)));
       it++; %atualiza intera��es
       xantes=xseg; %antes passa a ser o seguinte e volta a executar
         
     endwhile 
 endfunction