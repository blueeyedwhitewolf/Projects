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
n_it=500;
%matriz 5x2 para o enxame
%matriz 5*2 para a velocidade

b=zeros(5,2)
speed=zeros(5,2)
P=zeros(5,2)
enxame=zeros(5,2)

%inicializar enxame
for(i=1:5)
    j = 1;
    enxame(i,:)=LI(1,:)+ rand(1,2).*max_radius(1,:)
    speed(i,:)=1.6;
    %     while(j < i)
%         if(enxame(j,1) - enxame(i,1) < 1 && enxame(j,2) - enxame(i,j) < 1)
%             enxame(i,:)=LI(1,:)+ rand(1,2).*max_radius(1,:)
%             j=1;
%         end
%         j=j+1;
%     end
      b_best(i,:)=min(fobj(enxame(i,1),enxame(i,2)))
     
end

%b_best=

while(t<n_it)
    t=t+1;
    for(i=1:5)
        %bi - melhores posiçoes atingidas por cada uma das particulas
        b(t,:)=fobj(enxame(i,1),enxame(i,2))
        
        [P g]=min(b)
        %melor posiçao atingida pelo enxame
        if(P(i)<b_best(i))
            b_best(i)=P(i);
            g=t;
        end
        
        plot(b_best(1),b_best(2),'*b','Linewidth',3)
        
        best_all=min(b_best)
        
        c1=2;
        fi1=rand;
        c2=2;
        fi2=rand;
        
        speed(i,:)=speed(i,:)+c1*fi1*(b(i,:)-enxame(i,:))+c2*fi2*(g-enxame(i,:));
        enxame(i,:)=enxame(i,:)+speed(i,:);

        i=i+1;
    end
    
    plot(best_all,'*g','Linewidth',3)
    
end





