


# ESTA FUNCAO DETERMINA OS COEFICIENTES PARA DEPOIS USAR NO ESBOCO DO GRAFICO

function [coeficiente] = calclagrange (x, y)

num=length(x);
coeficiente=zeros(1,num); 

for i=1:num
  pol=1;
  for j=1:num
    if j!=i
      pol=conv(pol,[1,-x(j)]/(x(i)-x(j)));
    endif
  endfor
  l(i,:)=pol*y(i);
  coeficiente=coeficiente+l(i,:);
endfor
endfunction
