function [GaborImage]=GaborFiltering()

    Path = 'C:\TrabalhosAcunha\DropboxAtcunhaGmailCom\Dropbox\PythonWorks\LNDeterctor_NoduleSegmentation\';

    Image = load(strcat(Path,'Image.mat'));    
    Image = double(Image.arr); 
           
    Size = size(Image);
    
    GaborImage=zeros(Size);  
    
    for theta=0:180:360

        % Filter the image
        [G,GABOUT]=gaborfilter(Image,75,0.1,theta,0);
         M=abs(GABOUT);

        GaborImage=GaborImage+M;

    end
    
    GaborImage = medfilt2(GaborImage);
    
end

