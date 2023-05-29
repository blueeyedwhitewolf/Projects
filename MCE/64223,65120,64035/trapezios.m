function [res,error] = trapezios (a,b,funcao,h)
  
  res = 0;
  soma = 0;
  for i=a+h:h:b-h
    soma += feval(funcao,i);
  endfor
  res = (h/2)*(feval(funcao,a)+2*soma+feval(funcao,b));
 
%caso nao tivessemos o valor exato 
%  aux=0;
%  error=0;
  
%   for x = a:0.001:b
%        aux = abs(feval("ddfx",x));
%        if error < aux
%          error = aux;
%        endif
%    endfor
%    error = (((b-a)*h^2)/12)* error;
  
  absoluto=feval("integral",b)-feval("integral",a);
  error=abs(absoluto-res);
  
endfunction
