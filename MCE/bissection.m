function sol=bissection(a,b,error)
 % a e b são os extremos do intervalo no qual se encontra a solução
 % NumberIterations denota o n.º de interações necessárias para determinar
 % a solução com um erro inferior a error
 
     NumberIterations=ceil(log2((b-a)/error));
     it=1;
     
     function y=f(x)  %define se a função dentro de uma função
       y=exp(x)-3*x;
     endfunction
 
     fprintf('\n Metodo das Bissecoes no intervalo: [%f, %f]\n',a,b);
     fprintf('      i            xi              |f(x)| \n');
     
     while it<=NumberIterations
        c=(a+b)/2;  %calcula ponto médio
        auxiliar=f(c);
        fprintf('    %3d           %.10f     %.10f\n', it,c, abs(auxiliar)); %it é o nr de interações
        
        if abs(auxiliar)<0.00000000000001 %é pq acertamos logo no zero
          it=NumberIterations;
        endif
        if f(a)*auxiliar<0     %escolha do extremo do intervalo
           b=c;   %a solucao está à esquerda
        else 
           a=c;   %a soluçao está à direita
        endif
        it++;
     endwhile 
 endfunction