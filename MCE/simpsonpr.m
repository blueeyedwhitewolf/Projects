function [I]=simpsonpr(a,b,func,m)
  %cuidado tem de ser par
  h=(b-a)/m;
  I=0;
  x=a;
  for i=3:2:m-1;
    x=x+2*h;
    fx=feval(func,x);
    I=I+fx;
  endfor
  I=2*I;
  
  x=a-h;
  for i=2:m
    x=x+2*h;
  endfor
endfunction
