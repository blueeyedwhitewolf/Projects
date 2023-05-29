clc %Clear screen
close all %Fecha as janelas abertas
%clear all % Limpa as variaveis da worspace

syms x y
%colormap('pink')
f= @(x,y) (0.5+((sin(sqrt(x^2+y^2)))^2-0.5)/((1-0.001*(x^2+y^2))^2));

%f= (@(x,y) 0.5+(((sin(sqrt(x^2+y^2)))^2-0.5)/(1-0.001*(x^2+y^2)^2),[-2 2 -2 2]))
fcontour(f,[-2.048 2.048 -2.048 2.048])
hold on

VarLBounds = [-2.048,-2.048] %Lower Bounds (Limite Inferior)
VarUBounds = [2.048,2.048] %Upper Bounds (Limite Superior)

%Raio máximo para gerar uma nova solução
max_radius = (VarUBounds- VarLBounds)

x_trial = VarLBounds(1,:)+rand(1,2).*max_radius(1,:)
plot(x_trial(1),x_trial(2),'ro','Linewidth',3)
hold off

%%%%%% CICLO:

hold on
NumIter=100 %Numero de iterações
n=1;
while n<=NumIter
    %Soulucao de teste aleatoria
    x_trial = VarLBounds(1,:)+ rand(1,2).*max_radius(1,:);
    %chamar a funçao objetivo
    F=fobj(x_trial(1),x_trial(2));
    
    %r - color vermelha
    %o - Simbolo
    plot(x_trial(1),x_trial(2),'ro','Linewidth',3)
    n=n+1;
end
hold off


