function sol=newton(a,b,error)
 % a e b são os extremos do intervalo no qual se encontra a solução
 % NumberIterations denota o n.º de interações necessárias para determinar
 % a solução com um erro inferior a error
 
     NumberIterations = 10; %Faz menos interações que o da bisseçao por isso 10 é suficiente
     it=1;
     
     function y=f(x);  %define-se a função dentro de uma função
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
     
     
     %Definir ponto inicial (ou a ou b) -- f(a) e ddf(a) têm de ter sinais =
     if f(a)* ddf(a)>0
       xantes=a;
     else
       xantes=b;
     endif 
     
     %Cabeçalho
     fprintf('\n Metodo de Newton no intervalo: [%f, %f]\n',a,b);
     fprintf('      i            xi              |f(x)| \n');
     
     while ((abs(f(xantes))>error)&&(it<=NumberIterations));
       
       xseg=xantes-(f(xantes)/df(xantes));
       fprintf('    %3d           %.10f     %.10f\n', it,xseg,abs(f(xseg)));
       it++; %atualiza interações
       xantes=xseg; %antes passa a ser o seguinte e volta a executar
         
     endwhile 
 endfunction