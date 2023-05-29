
    %Clear console and windows
clc
close all

    %Definition and representation of function
syms x y
func=@(x,y) (0.5+((sin(sqrt(x^2+y^2)))^2-0.5)/((1-0.001*(x^2+y^2))^2));
fcontour(func,[-2.048 2.048 -2.048 2.048])
VarLBounds = [-2.048,-2.048];
VarUBounds = [2.048,2.048];
max_radius = (VarUBounds- VarLBounds);
hold on



    %inertia max and min
wmax = 0.8;
wmin = 0.5;

    %acceleration factor
c1 = 0.08;
c2 = 0.3;

iter=100;  %number of iterations

    %Probability and hipothesys Representation 
xplot=zeros(1,iter);
yplot=zeros(1,iter);
fplot=zeros(1,iter);
prob=zeros(1,iter);
temp=zeros(1,iter);

f = zeros(1,4);
    %Definition of the first positions
x = zeros(4,2);
f0 = zeros(1,4);
for i = 1:4    
    x(i,:) = VarLBounds(1,:)+rand(1,2).*max_radius(1,:);
    f0(i) = fobj(x(i,1),x(i,2));
    plot(x(i,1),x(i,2),'ko','Linewidth',3)
end
hold on;
[fmin0,index0] = min(f0);
v = 0.1*x;
pbest = x;
gbest = x(index0,:);
ffmin = zeros(1,iter);
n = 1;
tolerance=1; 
while ( n < iter && tolerance>10^-8)
    w = wmax-(wmax-wmin)*n/iter; % update inertia weight
    
    %velocity update
    for i = 1:4
        for j = 1:2
            v(i,j) = w*v(i,j)+c1*rand()*(pbest(i,j)-x(i,j))+c2*rand()*(gbest(1,j)-x(i,j));
        end
    end
    
    for i = 1:4
        x(i,:) = x(i,:)+v(i,:);
    end
    for i=1:4
        for j = 1:2
            if(x(i,j)<VarLBounds(j))
                x(i,j) = VarLBounds(j);
            elseif x(i,j)> VarUBounds(j)
                x(i,j) = VarUBounds(j);
            end
        end
    end
    
    for i = 1:4
        f(i) = fobj(x(i,1),x(i,2));
        if(f(i)<f0(i))
            pbest(i,:) = x(i,:);
            f0(i)=f(i);
        end
    end
    
    [fmin,index]=min(f0);  % Look for best particle
    ffmin(n) = fmin;
    
    if fmin<fmin0
        gbest = pbest(index,:);
        fmin0 = fmin;
    end
    
    if(n > 20)
        tolerance = abs(ffmin(n-20)-fmin0);
    end
    hold on
    plot(x(1,1),x(1,2),'bx','Linewidth',1)
    plot(x(2,1),x(2,2),'cx','Linewidth',1)
    plot(x(3,1),x(3,2),'gx','Linewidth',1)
    plot(x(4,1),x(4,2),'mx','Linewidth',1)
    n = n+1;
    pause(0.2)
end

plot(x(index,1),x(index,2),'rd','Linewidth',3)
hold off