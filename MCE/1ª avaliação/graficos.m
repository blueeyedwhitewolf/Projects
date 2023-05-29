
x=-10:0.1:10;
y=cos(x)-2+3*x;
z=-sin(x)+3;
w=-cos(x);
plot(x,y,x,z,x,w)

legend('f(x)', 'df(x)', 'ddf(x)');

%No ficheiro Grafico1:
%A linha azul representa a função f(x)
%A linha a vermelho representa a primeira derivada de f(x)
%A linha a amarelo representa a segunda derivada de f(x)
%Para podermos visualizar melhor a solução, efetuamos um zoom no intervalo x=[-10,10]
%Como observado pelo grafico1, existe uma única solução que corresponde ao valor 
%aproximado da raiz da equação não linear dada

%Conforme verificado pela análise do Grafico1, 
%No intervalo em que estamos a trabalhar, a=-10 e b=10
%f(a) é negativo e ddf(a) é positivo, tendo sendo contrários a sua
%multiplicação vai dar um valor negativo, assim o nosso x inicial 
%será igual a b, ou seja, 10. 




