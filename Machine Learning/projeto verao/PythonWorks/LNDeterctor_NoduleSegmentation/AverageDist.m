function asd = AverageDist()

Path = ['C:\TrabalhosAcunha\DropboxAtcunhaGmailCom\Dropbox\PythonWorks\LNDeterctor_NoduleSegmentation\'];

P = load(strcat(Path,'SegmentedNodule.mat'));
P = logical(P.arr);

Q = load(strcat(Path,'GroundtruthNodule.mat'));
Q = logical(Q.arr);

sP = size(P); sQ = size(Q);

if ~(sP(2)==sQ(2))
    error('Inputs P and Q must have the same number of columns')
end

if nargin > 2 && ~isempty(lmf)
    % the user has specified the large matrix flag one way or the other
    largeMat = lmf;     
    if ~(largeMat==1 || largeMat==0)
        error('3rd ''lmf'' input must be 0 or 1')
    end
else
    largeMat = 0;   % assume this is a small matrix until we check
    % If the result is too large, we will not be able to build the matrix of
    % differences, we must loop.
    if sP(1)*sQ(1) > 2e6
        % ok, the resulting matrix or P-to-Q distances will be really big, lets
        % check if our memory can handle the space we'll need
        memSpecs = memory;          % load in memory specifications
        varSpecs = whos('P','Q');   % load in variable memory specs
        sf = 10;                    % build in a saftey factor of 10 so we don't run out of memory for sure
        if prod([varSpecs.bytes]./[sP(2) sQ(2)]) > memSpecs.MaxPossibleArrayBytes/sf
            largeMat = 1;   % we have now concluded this is a large matrix situation
        end
    end
end

if largeMat
% we cannot save all distances, so loop through every point saving only
% those that are the best value so far

maxP = 0;           % initialize our max value
% loop through all points in P looking for maxes
for p = 1:sP(1)
    % calculate the minimum distance from points in P to Q
    minP = min(sum( bsxfun(@minus,P(p,:),Q).^2, 2));
    if minP>maxP
        % we've discovered a new largest minimum for P
        maxP = minP;
    end
end
% repeat for points in Q
maxQ = 0;
for q = 1:sQ(1)
    minQ = min(sum( bsxfun(@minus,Q(q,:),P).^2, 2));
    if minQ>maxQ
        maxQ = minQ;
    end
end
hd = sqrt(max([maxP maxQ]));
D = [];
    
else
% we have enough memory to build the distance matrix, so use this code
    
% obtain all possible point comparisons
iP = repmat(1:sP(1),[1,sQ(1)])';
iQ = repmat(1:sQ(1),[sP(1),1]);
combos = [iP,iQ(:)];

% get distances for each point combination
cP=P(combos(:,1),:); cQ=Q(combos(:,2),:);
dists = sqrt(sum((cP - cQ).^2,2));

% Now create a matrix of distances where D(n,m) is the distance of the nth
% point in P from the mth point in Q. The maximum distance from any point
% in Q from P will be max(D,[],1) and the maximum distance from any point
% in P from Q will be max(D,[],2);
D = reshape(dists,sP(1),[]);

% Obtain the value of the point, p, in P with the largest minimum distance
% to any point in Q.
vp = mean(min(D,[],2));
% Obtain the value of the point, q, in Q with the largets minimum distance
% to any point in P.
vq = mean(min(D,[],1));

asd = (vp + vq) / 2;

end





% --- visualization ---
if nargin==4 && any(strcmpi({'v','vis','visual','visualize','visualization'},dv))
    if largeMat == 1 || sP(2)>3
        warning('MATLAB:actionNotTaken',...
            'Visualization failed because data sets were too large or data dimensionality > 3.')
        return;
    end
    % visualize the data
    figure
    subplot(1,2,1)
    hold on
    axis equal
    
    % need some data for plotting
    [mp ixp] = min(D,[],2);
    [mq ixq] = min(D,[],1);
    [mp ixpp] = max(mp);
    [mq ixqq] = max(mq);
    [m ix] = max([mq mp]);
    if ix==2
        ixhd = [ixp(ixpp) ixpp];
        xyf = [Q(ixhd(1),:); P(ixhd(2),:)];
    else
        ixhd = [ixqq ixq(ixqq)];
        xyf = [Q(ixhd(1),:); P(ixhd(2),:)];
    end
    
    % -- plot data --
    if sP(2) == 2
        h(1) = plot(P(:,1),P(:,2),'bx','markersize',10,'linewidth',3);
        h(2) = plot(Q(:,1),Q(:,2),'ro','markersize',8,'linewidth',2.5);
        % draw all minimum distances from set P
        Xp = [P(1:sP(1),1) Q(ixp,1)];
        Yp = [P(1:sP(1),2) Q(ixp,2)];
        plot(Xp',Yp','-b');
        % draw all minimum distances from set Q
        Xq = [P(ixq,1) Q(1:sQ(1),1)];
        Yq = [P(ixq,2) Q(1:sQ(1),2)];
        plot(Xq',Yq','-r');
        
        % denote the hausdorff distance
        h(3) = plot(xyf(:,1),xyf(:,2),'-ks','markersize',12,'linewidth',2);
        uistack(fliplr(h),'top')
        xlabel('Dim 1'); ylabel('Dim 2');
        title(['Hausdorff Distance = ' num2str(m)])
        legend(h,{'P','Q','Hausdorff Dist'},'location','best')
        
    elseif sP(2) == 1   
        ofst = hd/2;    % plotting offset
        h(1) = plot(P(:,1),ones(1,sP(1)),'bx','markersize',10,'linewidth',3);
        h(2) = plot(Q(:,1),ones(1,sQ(1))+ofst,'ro','markersize',8,'linewidth',2.5);
        % draw all minimum distances from set P
        Xp = [P(1:sP(1)) Q(ixp)];
        Yp = [ones(sP(1),1) ones(sP(1),1)+ofst];
        plot(Xp',Yp','-b');
        % draw all minimum distances from set Q
        Xq = [P(ixq) Q(1:sQ(1))];
        Yq = [ones(sQ(1),1) ones(sQ(1),1)+ofst];
        plot(Xq',Yq','-r');
        
        % denote the hausdorff distance
        h(3) = plot(xyf(:,1),[1+ofst;1],'-ks','markersize',12,'linewidth',2);
        uistack(fliplr(h),'top')
        xlabel('Dim 1'); ylabel('visualization offset');
        set(gca,'ytick',[])
        title(['Hausdorff Distance = ' num2str(m)])
        legend(h,{'P','Q','Hausdorff Dist'},'location','best')
        
    elseif sP(2) == 3
        h(1) = plot3(P(:,1),P(:,2),P(:,3),'bx','markersize',10,'linewidth',3);
        h(2) = plot3(Q(:,1),Q(:,2),Q(:,3),'ro','markersize',8,'linewidth',2.5);
        % draw all minimum distances from set P
        Xp = [P(1:sP(1),1) Q(ixp,1)];
        Yp = [P(1:sP(1),2) Q(ixp,2)];
        Zp = [P(1:sP(1),3) Q(ixp,3)];
        plot3(Xp',Yp',Zp','-b');
        % draw all minimum distances from set Q
        Xq = [P(ixq,1) Q(1:sQ(1),1)];
        Yq = [P(ixq,2) Q(1:sQ(1),2)];
        Zq = [P(ixq,3) Q(1:sQ(1),3)];
        plot3(Xq',Yq',Zq','-r');
        
        % denote the hausdorff distance
        h(3) = plot3(xyf(:,1),xyf(:,2),xyf(:,3),'-ks','markersize',12,'linewidth',2);
        uistack(fliplr(h),'top')
        xlabel('Dim 1'); ylabel('Dim 2'); zlabel('Dim 3');
        title(['Hausdorff Distance = ' num2str(m)])
        legend(h,{'P','Q','Hausdorff Dist'},'location','best')
        

    end
    
    subplot(1,2,2)
    % add offset because pcolor ignores final rows and columns
    [X Y] = meshgrid(1:(sQ(1)+1),1:(sP(1)+1));
    hpc = pcolor(X-0.5,Y-0.5,[[D; D(end,:)] [D(:,end); 0]]);
    set(hpc,'edgealpha',0.25)
    xlabel('ordered points in Q (o)')
    ylabel('ordered points in P (x)')
    title({'Distance (color) between points in P and Q';...
        'Hausdorff distance outlined in white'})
    colorbar('location','SouthOutside')
    
    hold on
    % bug: does not draw when hd is the very last point
    rectangle('position',[ixhd(1)-0.5 ixhd(2)-0.5 1 1],...
        'edgecolor','w','linewidth',2);
    
end









