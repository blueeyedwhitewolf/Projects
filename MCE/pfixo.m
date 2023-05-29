function sol=pfixo(a,b,error)
% a e b são os extermos do intervalo no qual se encontra a solucao
% NumberIterations denota o nº de iteracoes necessarias para determinar 
% a solucao com um erro inferior a error
  %NumberIterations=ceil(log2((b-a)/error));
  NumberIterations=20;
  it=1;
  
  function y=f(x)
      y=exp(x)-3*x;
  endfunction
  
  function y=g(x)
    y=log(3*x);
  endfunction
  
x0=(a+b)/2;
  
  %erro=b-a; % erro em cada iteracao
  
  
  fprintf('\n Metodo do ponto fixo no intervalo: [%f, %f]\n',a,b);
  fprintf('        i          xi                     |f(xi)|\n');
  
  
  while ((abs(f(x0))>error) && (it<=NumberIterations))
    x1=g(x0);
    fprintf('    %3d         %.10f               %.10f \n',it,x1,abs(f(x1)));
    
    it++;
    x0=x1;
    endwhile
  endfunction
  