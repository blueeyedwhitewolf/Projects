

# PARA VER DIFERENTES APROXIMACOES, TEM DE SER USADA UMA FUNCAO DE CADA VEZ

function g = funcao_coe (coe, x)
  
  #as funcoes usadas no metodo dos quadrados minimos
  
  #g=coe(1)*x.^2+coe(2)*x;
  #g=coe(1)*x.^2+coe(2);
  g=coe(1)*x.^2+coe(2)*x + coe(3);

endfunction
