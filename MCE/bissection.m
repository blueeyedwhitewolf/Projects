function sol=bissection(a,b,error)
 % a e b s�o os extremos do intervalo no qual se encontra a solu��o
 % NumberIterations denota o n.� de intera��es necess�rias para determinar
 % a solu��o com um erro inferior a error
 
     NumberIterations=ceil(log2((b-a)/error));
     it=1;
     
     function y=f(x)  %define se a fun��o dentro de uma fun��o
       y=exp(x)-3*x;
     endfunction
 
     fprintf('\n Metodo das Bissecoes no intervalo: [%f, %f]\n',a,b);
     fprintf('      i            xi              |f(x)| \n');
     
     while it<=NumberIterations
        c=(a+b)/2;  %calcula ponto m�dio
        auxiliar=f(c);
        fprintf('    %3d           %.10f     %.10f\n', it,c, abs(auxiliar)); %it � o nr de intera��es
        
        if abs(auxiliar)<0.00000000000001 %� pq acertamos logo no zero
          it=NumberIterations;
        endif
        if f(a)*auxiliar<0     %escolha do extremo do intervalo
           b=c;   %a solucao est� � esquerda
        else 
           a=c;   %a solu�ao est� � direita
        endif
        it++;
     endwhile 
 endfunction