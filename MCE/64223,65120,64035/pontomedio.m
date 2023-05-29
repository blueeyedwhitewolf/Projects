function [res,error,absoluto] = pontomedio (a,b,funcao,h)
  
  res = 0;
  soma = 0;
  for i=a+h:h:b-h
    soma += feval(funcao,i);
    i+=h/2;
  endfor
  res = h*(soma);
  absoluto=feval("integral",b)-feval("integral",a);
  error=abs(absoluto-res);
  
endfunction