function sol=secante1(a,b,tol)
 % a e b s�o os extremos do intervalo no qual se encontra a solu��o
 % NumberIterations denota o n.� de intera��es necess�rias para determinar
 % a solu��o com um erro inferior a tol
 
 
     NumberIterations = 5;
     it=1;
     function y=f(x);  
       y=cos(x)-2+3*x;
     endfunction
     
     %Pontos iniciais s�o a e b
     x0=a;
     x1=b;
     erro=abs(x1-x0);
     
     fprintf('\n Metodo da Secante no intervalo: [%f, %f]\n',a,b);
     fprintf('      i            xi              |f(x)| \n');
     
      for it=1:NumberIterations
       
       xseguinte=x1-(f(x1)*(x1-x0)/(f(x1)-f(x0)));
       if(((((abs(x1-x0))/abs(x1))>=tol)))
        fprintf('    %3d           %.10f     %.10f\n', it,xseguinte,abs(f(xseguinte)));
       endif 
       erro=abs(f(xseguinte));
       x0=x1; 
       x1=xseguinte;  
     endfor
     
 endfunction 