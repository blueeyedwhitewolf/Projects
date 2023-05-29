function z=Lagrange(x,y,a)
% x abcissa dos pontos dados
% y ordenada dos pontos fornecidos
% a abcissa do ponto cuja ordenada queremos estimar
% modo de utilização z=Lagrange(x,y,a)

N=length (x);
z=0;

 for i = 1:N
    p=1;
      for j=1:N
        if j ~= i
          p=p*((a-xi)/(xi-xj));
        end if
       endfor
        z = z + p*yi;
 endfor
endfunction