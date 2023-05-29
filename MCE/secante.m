function sol=secante(a,b,tol)
 % a e b s�o os extremos do intervalo no qual se encontra a solu��o
 % NumberIterations denota o n.� de intera��es necess�rias para determinar
 % a solu��o com um erro inferior a tol
 
 
     NumberIterations = 20; %Faz menos intera��es que o da bisse�ao por isso 10 � suficiente
     it=1;
     
     function y=f(x);  %define-se a fun��o 
       y=exp(x)-3*x;
     endfunction
     
     %Pontos iniciais s�o a e b
     x0=a;
     x1=b;
     erro=abs(x1-x0);
     
     fprintf('\n Metodo da Secante no intervalo: [%f, %f]\n',a,b);
     fprintf('      i            xi              |f(x)| \n');
     
    while ((erro>tol)&&(it<=NumberIterations))
       
       xseg=x1-(f(x1)*(x1-x0)/(f(x1)-f(x0)));
       fprintf('    %3d           %.10f     %.10f\n', it,xseg,abs(f(xseg)));
       it++; %atualiza intera��es
       erro=abs(f(xseg));
       x0=x1; 
       x1=xseg;
         
     endwhile 
     
     
 endfunction 