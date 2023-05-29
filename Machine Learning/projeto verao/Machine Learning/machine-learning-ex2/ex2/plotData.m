function plotData(X, y)
%PLOTDATA Plots the data points X and y into a new figure 
%   PLOTDATA(x,y) plots the data points with + for the positive examples
%   and o for the negative examples. X is assumed to be a Mx2 matrix.

% Create New Figure
figure; hold on;

% ====================== YOUR CODE HERE ======================
% Instructions: Plot the positive and negative examples on a
%               2D plot, using the option 'k+' for the positive
%               examples and 'ko' for the negative examples.
%
% Find Indices of Positive and Negative Examples
pos=find(y==1);
neg=find(y==0); 

plot(X(pos,1),X(pos,2),'k+'); %returns indices corresponding to the entries of X
% that are positive (on the first and second column, where the data is) and plots on x axis the scores of exam 1
%and on y axis the scores of second exam
plot(X(neg,1),X(neg,2),'ko'); %same but for the negative examples

% =========================================================================

hold off;

end
