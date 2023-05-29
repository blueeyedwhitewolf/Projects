

# PARA VER DIFERENTES APROXIMACOES, TEM DE SER USADA UMA MATRIZ DE CADA VEZ


function A = funcao_base (x)
  n=length(x);
  
  #sao geradas as matrizes para usar no metodo dos minimos quadrados
  
  #A=[x.^2;ones(1,n)];
  A=[x.^2;x;ones(1,n)];
  #A=[x.^2;x];
endfunction
