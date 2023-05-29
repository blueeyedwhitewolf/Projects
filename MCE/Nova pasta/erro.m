

# FUNCAO QUE DETERMINA O ERRO

function e = erro (x, y, coe)
  e=0;
  N=length(x);
  for i=1:N
    e=e+(y(i)-funcao_coe(coe,x(i)))^2; #chama o script "funcao_coe" onde estao os polinomios
  endfor
endfunction
