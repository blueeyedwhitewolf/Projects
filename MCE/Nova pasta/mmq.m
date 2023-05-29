

# APRESENTA APENAS O ERRO DA APROXIMACAO DO METODO DOS MINIMOS QUADRADOS
function mmq ()

dados

xx=min(x):0.01:max(x);
A=funcao_base(x);
B=A*A';
sol=inv(B)*A*y'; #funcao para determinar uma matriz
yy=funcao_coe(sol,xx);
erro=erro(x,y,sol) #calcula o erro

# Erro da funcao: ax^2 + bx = 10.670(pol1)
# Erro da funcao: ax^2 + c = 3.3104(pol2)
# Erro da funcao: ax^2 + bx + c = 1.00000(pol3)

endfunction
