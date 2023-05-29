function [I]= Simpson (a,b,fun, m)
  %ATENÇÃO: m = numero de intervalos --> TEM DE SER PAR
  
  h=(b-a)/m;
  I=0;
  x=a;
  
  for i=3:2:m-1    %diferença entre o numero de intervalos e numero pontos
                  %m intervalos;   m+1 pontos    ; queremos acabar em m-1 = último com coeficiente 2
    x=x+2*h;
    fx=feval(fun,x);
    I=I+fx;
  endfor
  
  I=2*I;
  
  x=a-h;
  for i=2:m
   x=x+2*h;
   
   
   
  endfor  

 endfunction
  
  