function [I]=trapeziospr(a,b,funca,n)
  h=(b-a)/n;
  I=0;
  x=a;
  for i=2:n
    x=x+h;
    fx=feval(funca,x);
    I=I+feval(funca,x);
  endfor
  I=2*I;
  I=I+feval(funca,a)+feval(funca,b);
  I=I*h/2;
endfunction
