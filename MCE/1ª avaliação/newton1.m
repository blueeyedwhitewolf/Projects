function sol=newton1(a,b,error)
 % a e b são os extremos do intervalo no qual se encontra a solução
 % NumberIterations denota o n.º de iterações necessárias para determinar
 % a solução com um erro inferior a error
 
     NumberIterations = 10; 
     it=1;
     
     function y=f(x);
       y=cos(x)-2+3*x;
     endfunction
     
     %Primeira derivada
     function y=df(x)
     y=-sin(x)+3;
     endfunction
     
     %Segunda derivada
     function y=ddf(x)
     y=-cos(x);
     endfunction
      
     %Definir ponto inicial (ou a ou b) -- f(a) e ddf(a) têm de ter sinais iguais
     if f(a)* ddf(a)>0
       xantes=a;
     else
       xantes=b;
     endif 
     
     %Cabeçalho
     fprintf('\n Metodo de Newton no intervalo: [%f, %f]\n',a,b);
     fprintf('      i            xi              |f(x)| \n');
     
     
     for it=1:10
          xseguinte=xantes-(f(xantes)/df(xantes));
       if (((((abs(xseguinte-xantes))/abs(xseguinte))>=error))&&(it<=NumberIterations))
         fprintf('    %3d           %.10f     %.10f\n', it,xseguinte,abs(f(xseguinte)));
       endif
       xantes=xseguinte; %o x antes passa a ser o seguinte e volta a executar
     endfor    
 
 endfunction