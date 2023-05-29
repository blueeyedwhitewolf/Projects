function [I]=Trapezios2(a,b,funca,n)
 
 %a = in�cio do intervalo
 %b = final do intervalo
 %funcao que recebemos
 % n = n�mero de intervalos
 
 %Para chamar Trapezios2(0,1,'maria',55) --> nome da fun��o entre '...'
 %Trapezios2(0,1,'maria',5)
 
 
 h=(b-a)/n;
 I=0;
 x=a;
 
  for i=2:n
    x=x+h;
    fx=feval(funca,x); %funcao entra no ponto x
    I=I+fx;
  endfor
  I=2*I;
  I=I+feval(funca,a)+feval(funca,b);
  I=I*h/2;
  
 endfunction
  
  
  