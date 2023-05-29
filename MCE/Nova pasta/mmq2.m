

# ESTA FUNCAO APRESENTA O ERRO E O GRAFICO DA APROXIMACAO DO METODO DOS QUADRADOS MINIMOS

function mmq2 ()

dados

xx=min(x):0.01:max(x);
A=funcao_base(x);
B=A*A';
sol=inv(B)*A*y';
sol
yy=funcao_coe(sol,xx);
erro=erro(x,y,sol)

plot(x,y,'xr')

hold on

#polinomios
pol1 = -0.033*xx.^2 + 0.62*xx;
pol2 = 0.019231*xx.^2 + 1.678571;
pol3 = 0.17857*xx.^2 -1.03571*xx + 2.71429;

#legendas do grafico
legend('Os pontos do ficheiro "dados"')
title('Representacao grafica dos polinomios')
text(2, 2, 'ax^2 + c')
text(1, 0.5, 'ax^2 + bx')
text(4, 1.25, 'ax^2 + bx + c')
plot(xx,pol1,'b',xx,pol2,'k',xx,pol3, 'g')

hold on

endfunction
