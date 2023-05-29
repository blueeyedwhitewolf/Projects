function [I]=Trapezios(a,b,numintervalos)
 
 %a = início do intervalo
 %b= fim do intervalo
 %numintervalos = numero de intervalos em que vamos dividir
 %a função que vamos receber
 
 n=numintervalos;
 h=(b-a)/n; %amplitude dos intervalos 
 
 % function y=f(x);
  % y=funcao;
  %endfunction
  
function y=f(x);
 y=exp(-x);
endfunction
    
  soma=0;
  
  for i=2:n-1
    soma=soma + f(i);
    endfor
 
 I=h/2*[f(0) + 2*soma + f(n)];
  
  endfunction