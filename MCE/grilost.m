function [erro,a,b]=grilost(x,y)
plot(x,y,"ko","MarkerSize",8)
hold on;
xlabel("Intensidade do canto dos grilos")
ylabel("Temperatura")
%axis([0.9* min(x),1.1 * max(x), 0.9*min(y),1.1*max(y)])
% definicao da matriz A das equacoes normais
format long
n=length(x);
A=[x.^2;x;ones(1,n)];
B=inv(A*(A'));
sol=B*A*y';
a=sol(1);
b=sol(2);
c=sol(3);
xx=min(x):0.01:max(x);
yy=(a*xx.^2)+(b*xx)+c;

%newy=a*x+b;
plot(xx,yy)
legend("Dados", "Regressao Linear ","location","northwest")
hold off;
zz=yy=a*x.^2+b*x+c;
erro = 0;
for i =1:n
  erro=erro+(y(i)-zz(i))^2;
endfor
endfunction
