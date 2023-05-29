function [a,b,c,d]=Cubic(x,y)

dados2;

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

zz=yy=a*xx.^3+b*xx.^2+c*xx+d;

endfunction