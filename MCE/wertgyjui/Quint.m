function [a,b,c,d,e]=Quint(x,y)

dados2;

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

zz=yy=a*xx.^5+b*xx.^4+c*xx.^2+d*xx+e;

endfunction