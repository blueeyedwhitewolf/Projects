clc 
close all 
syms x y
LI = [-2.048,-2.048]; %Lower Bounds (Limite Inferior)
LS = [2.048,2.048]; %Upper Bounds (Limite Superior)

f= @(x,y) (0.5+((sin(sqrt(x^2+y^2)))^2-0.5)/((1-0.001*(x^2+y^2))^2));

fcontour(f,[-2.048 2.048 -2.048 2.048])
hold on

%Raio máximo para gerar uma nova solução
max_radius = (LS- LI);
t=0;
n=1;
n_Iter=1000;

best_x=LI(1,:)+ rand(1,2).*max_radius(1,:);

x_radius=max_radius*0.1;

while (n<=n_Iter)
    %x_new=best_x+((2*rand(1,2)-1).*x_radius);
    x_new=LI(1,:)+ rand(1,2).*max_radius(1,:);
    if(fobj(x_new(1),x_new(2))<fobj(best_x(1),best_x(2))&&x_new(1)<2&&x_new(2)<2&&x_new(1)>-2&&x_new(2)>-2)
        best_x=x_new;
    end
    
    xplot(1,n)=best_x(1);
    yplot(1,n)=best_x(2);
    fplot(1,n)=fobj(best_x(1),best_x(2));
    
    plot(best_x(1),best_x(2),'ro','Linewidth',3)
    pause(0.01)
    t=t+1;
    n=n+1;     
end

plot(best_x(1),best_x(2),'*k','Linewidth',3)
hold off

itera=1:1:n_Iter;

figure

subplot(2,1,1)
plot(itera,fplot,'k-')
xlabel('Iteracao')
ylabel('F melhor')
hold on

subplot(2,1,2)
plot(itera,xplot,'b-')
hold on
plot(itera,yplot,'g-')
xlabel('Iteracoes')
ylabel('x,y')
hold off



