
% Este script junta todos os ficheiros e funcoes que foram implementadas
% Para usar, deve escolher a opcao que deseja.

# MODO DE USO:

# Este script apresenta um menu onde podem ser escolhidas varias opcoes
# A primeira opcao mostra o grafico do polinomio interpolar segmentado
# A segunda opcao utiliza o Metodo dos Minimos Quadrados para determinar a aproximacao da funcao
# A terceita opcao mostra o grafico da Aproximacao e o erro

function geral ()

  fprintf("********Bem-Vindo ao programa que calcula aproximacao de funcoes*******\n\n");
  
  op=input("Escolha a opcao:\n1-Construir o polinomio interpolador segmentado;\n2-Utilizar os Metodos dos Minimos Quadrados(determinar a aproximacao e o erro);\n3-Visualizar o grafico da aproximacao do Metodo dos Minimos Quadrados e o erro;\nSua opcao:");
  
  if op==1
   segmento; 
    
  elseif op==2
    mmq;
    
    elseif op==3
    mmq2;
    
  endif
endfunction
