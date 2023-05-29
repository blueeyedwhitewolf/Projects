function f = fobj(x,y)

f= 0.5+((sin(sqrt(x^2+y^2)))^2-0.5)/((1-0.001*(x^2+y^2))^2);

end