function [res,error] = simpson (a,b,funca,h)
  n=(b-a)/h;
  if(rem(n,2) != 0)
    n= round(n);
    if(rem(n,2) != 0)
      n = n-1;
      display("Numero de intervalos tem de ser par")
      h=(b-a)/n;
      display(["n arredondado para: ", num2str(n)]);
    endif
   endif
   if(n==0)
      display("Nao e possivel fazer com 0 intervalos");
  else
    res = 0;
    h = (b-a)/n;
    som_par = 0;
    som_imp = 0;
    for i=a+h:2*h:b-h
      som_imp += feval(funca,i);
    endfor
    for j=a+2*h:2*h:b-2*h
      som_par += feval(funca,j);
    endfor
    res = (h/3)*(feval(funca,a)+2*som_par+4*som_imp+feval(funca,b));

%caso nao tivessemos o valor exato    
%    aux = 0;
%   error = 0;
%  for x = a:0.001:b
%     aux = abs(feval("ddddfx",x));
%     if error < aux
%      error = aux;
%   endif
%    endfor
%    error = (((b-a)*h^4)/180)*error;
%  
  absoluto=feval("integral",b)-feval("integral",a);
  error=abs(absoluto-res);
endif  
  
endfunction
