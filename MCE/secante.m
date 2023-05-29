function sol=secante(a,b,tol)
 % a e b são os extremos do intervalo no qual se encontra a solução
 % NumberIterations denota o n.º de interações necessárias para determinar
 % a solução com um erro inferior a tol
 
 
     NumberIterations = 20; %Faz menos interações que o da bisseçao por isso 10 é suficiente
     it=1;
     
     function y=f(x);  %define-se a função 
       y=exp(x)-3*x;
     endfunction
     
     %Pontos iniciais são a e b
     x0=a;
     x1=b;
     erro=abs(x1-x0);
     
     fprintf('\n Metodo da Secante no intervalo: [%f, %f]\n',a,b);
     fprintf('      i            xi              |f(x)| \n');
     
    while ((erro>tol)&&(it<=NumberIterations))
       
       xseg=x1-(f(x1)*(x1-x0)/(f(x1)-f(x0)));
       fprintf('    %3d           %.10f     %.10f\n', it,xseg,abs(f(xseg)));
       it++; %atualiza interações
       erro=abs(f(xseg));
       x0=x1; 
       x1=xseg;
         
     endwhile 
     
     
 endfunction 