function [X_poly] = polyFeatures(X, p)
%POLYFEATURES Maps X (1D vector) into the p-th power
%   [X_poly] = POLYFEATURES(X, p) takes a data matrix X (size m x 1) and
%   maps each example into its polynomial features where
%   X_poly(i, :) = [X(i) X(i).^2 X(i).^3 ...  X(i).^p];
%


% You need to return the following variables correctly.
X_poly = zeros(numel(X), p);

% ====================== YOUR CODE HERE ======================
% Instructions: Given a vector X, return a matrix X_poly where the p-th 
%               column of X contains the values of X to the p-th power.
%
% 

%Colum 1 of X_poly -> original values of X
%C2 -> values of X.^2
%C3 -> values of X.^3
%...

exp=[1:p]; %row vector with exponents from 1 to p

%X is a column vector of feature values 'X'

%bsxfun is a function to apply element-wise operation to two arrays with implicit 
%expansion enabled

X_poly=bsxfun(@power,X,exp);


% =========================================================================

end
