clc 
close all 
syms x y
T=90;
LI = [-2.048,-2.048]; %Lower Bounds (Limite Inferior)
LS = [2.048,2.048]; %Upper Bounds (Limite Superior)

f= @(x,y) (0.5+((sin(sqrt(x^2+y^2)))^2-0.5)/((1-0.001*(x^2+y^2))^2));

fcontour(f,[-2.048 2.048 -2.048 2.048])
hold on

%Raio máximo para gerar uma nova solução
max_radius = (LS- LI)

n_Iter=200;

xplot=zeros(1,200);
yplot=zeros(1,200);
fplot=zeros(1,200);
prob=zeros(1,200);
temp=zeros(1,200);
best_plot_x=zeros(1,200);
best_plot_y=zeros(1,200);
f_best_plot=zeros(1,200);
x_act=LI(1,:)+ rand(1,2).*max_radius(1,:);
best_all_f=fobj(x_act(1),x_act(2));
best_all_x=x_act;

%ponto inicial
plot(x_act(1),x_act(2),'*b','Linewidth',3)
n=1;
%raio da vizinhança
while(n<=n_Iter)
    a=1;
    while(a<=3)
%         neig = (rand(1,2)-[0.5 0.5]);
%         x_new = x_act(1,:)+neig;
        x_new=LI(1,:)+ rand(1,2).*max_radius(1,:);

        delta_T=fobj(x_new(1),x_new(2))-fobj(x_act(1),x_act(2));
        %p=1/(1+exp(delta_T/T));
        p=exp(-abs(delta_T)/T);
        prob(n)=p;
        if(x_new(1)<=2&&x_new(1)>=-2&&x_new(2)>=(-2)&&x_new(2)<=2) 
            if (delta_T<0)
                x_act=x_new;
            elseif (rand<p) 
                x_act=x_new;  
            end
            if(best_all_f>fobj(x_act(1),x_act(2)))
              best_all_x=x_act;
              best_all_f=fobj(best_all_x(1),best_all_x(2));
            end
%             if(fobj(x_new(1),x_new(2))>best_all_f&&n>=140)
%                 x_act=best_all_x;
%             end
        end
        %pontos SA
        a=a+1;   
    end
    plot(x_act(1),x_act(2),'*r','Linewidth',3)

    pause(0.01)
    xplot(1,n)=x_act(1);
    yplot(1,n)=x_act(2);
    fplot(1,n)=fobj(x_act(1),x_act(2));
    temp(n)=T;
    best_plot_x(1,n)=best_all_x(1);
    best_plot_y(1,n)=best_all_x(2);
    f_best_plot(1,n)=fobj(best_all_x(1),best_all_x(2));
    T=0.96*T;
    n=n+1;
end

%Máximo encontrado
plot(best_all_x(1),best_all_x(2),'xk','Linewidth',11)
hold off

itera=1:1:200;

figure

subplot(2,1,1)
plot(itera,fplot,'k-')
xlabel('Iteracao')
ylabel('F Atual')
hold on

subplot(2,1,2)
plot(itera,xplot,'b-')
hold on
plot(itera,yplot,'g-')
xlabel('Iteracoes')
ylabel('x,y Actuais')
hold off

figure
subplot(2,1,1)
plot(itera,prob,'ro')
xlabel('Iteracoes')
ylabel('Probabilidade')
axis([0 n_Iter 0 1])
hold on

subplot(2,1,2)
plot(itera,temp,'-b')
xlabel('Iteracoes')
ylabel('Temperatura')
hold off

figure
subplot(2,1,1)
plot(itera,f_best_plot,'r-')
xlabel('Iteracoes')
ylabel('F melhor')
hold on

subplot(2,1,2)
plot(itera,best_plot_x,'b-')
hold on
plot(itera,best_plot_y,'g-')
xlabel('Iteracoes')
ylabel('Melhores x e y')
hold off

