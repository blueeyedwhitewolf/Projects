
x=-10:0.1:10;
y=cos(x)-2+3*x;
z=-sin(x)+3;
w=-cos(x);
plot(x,y,x,z,x,w)

legend('f(x)', 'df(x)', 'ddf(x)');

%No ficheiro Grafico1:
%A linha azul representa a fun��o f(x)
%A linha a vermelho representa a primeira derivada de f(x)
%A linha a amarelo representa a segunda derivada de f(x)
%Para podermos visualizar melhor a solu��o, efetuamos um zoom no intervalo x=[-10,10]
%Como observado pelo grafico1, existe uma �nica solu��o que corresponde ao valor 
%aproximado da raiz da equa��o n�o linear dada

%Conforme verificado pela an�lise do Grafico1, 
%No intervalo em que estamos a trabalhar, a=-10 e b=10
%f(a) � negativo e ddf(a) � positivo, tendo sendo contr�rios a sua
%multiplica��o vai dar um valor negativo, assim o nosso x inicial 
%ser� igual a b, ou seja, 10. 




