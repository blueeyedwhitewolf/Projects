 function [YInt] = Interp(x,y, XInt)
   
% Função que determina um valor interpolado de um ponto
%x = vetor das coordenadas x dos pontos dados
%y = vetor das coordenadas y dos pontos dados 
%XInt = coordenada do ponto a ser interpolado
%Devolve YInt = valor interpolado de XInt

 num=length(x); %numero de termos do polinomio

for i=1:num
  L(i)=1; %inicializacao do polinomio de Lagrange
  for j=1:num 
    if j!=i %Verifica se o valor de j nao e igual ao valor de i 
            %para impedir a divisao de um valor por 0
      L(i)=L(i)*(XInt-x(j))/(x(i)-x(j));
    endif
  endfor
 endfor
 YInt=y*(L');
 printf('O valor e: %.6f\n',YInt);
 endfunction
   
   