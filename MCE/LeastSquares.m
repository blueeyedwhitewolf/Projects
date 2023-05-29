function [sol]=LeastSquares(x,y) % x e y sao os pontos a ajustar
  format long
  be=basis(x(1)); % basis deve ser um script onde est´a definido um vetor coluna com as funcoes base
  np=length(x); % no de pontos
  nbf=length(be); % no de funcoes base
  A=zeros(nbf,nbf);B=zeros(nbf,1);
  for j=1:nbf
    for k=1:nbf
      for i=1:np
        A(j,k)=A(j,k)+(basis(x(i))(j))*(basis(x(i))(k));
      endfor
    endfor
    for i=1:np
      B(j,1)=B(j,1)+basis(x(i))(j)*y(i);
    endfor
  endfor
  sol=inv(A)*B;
 
 function [f]=ajuste(var) % Func¸ao de ajuste e respectivo grafico
  f=zeros(1,length(var));
  for jj=1:length(var)
    for ii=1:length(sol)
      f(jj)=f(jj)+sol(ii)*((basis(var(jj)))(ii));
    endfor
  endfor
 endfunction
  u=(min(x)):0.01:(max(x));
  v=ajuste(u);
  plot(u,v)
  res=0; % Erro do ajuste
  for i=1:np
    res = res + (y(i)-ajuste(x)(i))ˆ2;
  endfor
  residuo=sqrt(res);
  fprintf("Erro da aproximacao --> %8f\n",residuo)
endfunction
