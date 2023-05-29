


#ESBOCA O GRAFICO DO POLINOMIO INTERPOLADOR SEGMENTADO

dados

plot(x,y,'xr')
hold on

xx=min(x):0.01:max(x);
pol=calclagrange(x,y); #o script que usa metodo do lagrange
yy=polyval(pol,xx);

legend('Os pontos do ficheiro "dados"')
title('Representacao grafica do polinomio interpolador')
text(1, 0.9, 'Primeiro polinomio')
text(4.5, 1.25, 'Segundo polinomio')
text(2.5, 2.10, 'Ponto de continuidade da funcao')
plot(xx,yy,'-b')

# 1º Polinomio encontrado: 0.0041667*x^3 - 0.0541667*x^2 + 0.2291667*x - 0.3958333   
# 2º Polinomio encontrado: 0.3958333*x^3 + 0.7666667*x^2 -2.0500000*x - 3.0000000

hold off