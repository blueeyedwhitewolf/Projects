function [a,b,c,d,e]=Quint(x,y)

dados2;

%plot(x,y,"ko","MarkerSize",8) alterar para circulos a preto:
plot(x,y,"kx","MarkerSize",8)
hold on;
xlabel("Coordenada x da localidade")
ylabel("Coordenada y da localidade")

% definicao da matriz A das equacoes normais
format long
n=length(x);

A=[x.^3;x.^2;x;ones(1,n)];
B=inv(A*(A'));
sol=B*A*y';
a=sol(1)
b=sol(2)
c=sol(3)
d=sol(4)
xx=min(x):0.001:max(x);
yy=a*xx.^3+b*xx.^2+ c*xx+d;

plot(xx,yy)
legend("Dados", "Regressao Linear ")
hold off;

zz=yy=a*xx.^3+b*xx.^2+c*xx+d;

% definicao da matriz A das equacoes normais
format long
n=length(x);

A=[x.^5;x.^4;x.^2;x;ones(1,n)];
B=inv(A*(A'));
sol=B*A*y';
a=sol(1)
b=sol(2)
c=sol(3)
d=sol(5)
e=sol(6)
xx=min(x):0.001:max(x);
yy=a*xx.^5+b*xx.^4+c*xx.^2+d*xx+e;

plot(xx,yy)
legend("Dados", "Regressao Linear ")
hold off;

zz=yy=a*xx.^5+b*xx.^4+c*xx.^2+d*xx+e;

endfunction