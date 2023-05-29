function [a,b]=grilos(x,y)
  plot(x,y,"ko","MarkerSize",8)
  hold on;
  xlabel("Intensidade do canto dos grilos")
  ylabel("Temperatura")
  axis([0.9*min(x),1.1*max(x),0.9*min(y),1.1*max(y)]);
  % definicao da matriz A das equacoes normais
  format long
  n=length(x);
  A=[x;ones(1,n)];
  B=inv(A*(A'));
  sol=B*A*y';
  a=sol(1)
  b=sol(2)
  newy=a*x+b;
  plot(x,newy)
  hold off;
  legend("Dados", "Regressao Linear ","Location","northwest")
endfunction
