# -*- coding: utf-8 -*-
"""
Created on Thu Jan 10 15:17:04 2019

@author: Admin
"""

from sklearn import tree
import numpy as np #algebra linear
import pandas as pd #processamento de dados, CSV file input/output
import matplotlib.pyplot as plt
import seaborn as sns
import pydotplus
import collections
import graphviz
from IPython.display import Image

#leitura do ficheiro e selecionar dados de interesse
iris = pd.read_csv ("iris2.csv")
X = iris.iloc[:, 1:5]
y = iris.iloc[:, 5]

#Codigo para visualizar os dados que se pretendem
sns.set(style="ticks", color_codes=True)
sns.set_palette("husl")
sns.pairplot (iris.iloc[:,1:6],hue="Species",palette="husl")

plt.show()

#determinar o classificador e prever novos exemplos
clf = tree.DecisionTreeClassifier(criterion = "entropy")
clf = clf.fit(X, y)

newX=[[6.5, 3, 5.5, 1.8],
      [6.6, 3, 4.4, 1.4],
      [6.6, 3, 4.4, 1.0]]
newy=clf.predict(newX)
print(newy)

#criar um ficheiro com a árvore


data_feature_names=['SepalLengthCm','SepalWidthCm','PetalLengthCm','PetalWidthCm']
data_class_names=['setosa','versicolor','virginica']
#
##visualizar dados
dot_data=np.StringIO()
#
tree.export_graphviz(clf,feature_names=data_feature_names,out_file=dot_data,filled=True, rounded=True)
graph=pydotplus.graph_from_dot_data(dot_data.getvalues())
graph=pydotplus.graph_from_dot_data()
graph.write_pdf=pydotplus.graph_from_dot_data(dot_data.getvalue())
graph=pydotplus.graph_from_dot_data(dot_data)

tree.export_graphviz(clf,feature_names=data_feature_names,out_file='iris.txt',filled=True,rounded=True)
graph=pydotplus.graph_from_dot_file('iris.txt')

tree.export_graphviz(clf,feature_names=data_feature_names,out_file=None,filled=True,roundes=True)
graph=pydotplus.from_dot_file('irirs.txt')

#Show graph

Image(graph.create_png())

colors = ('turquoise', 'orange')
edges = collections.defaultdict(list)

for edge in graph.get_edge_list():
    edges[edge.get_source()].append(int(edge.get_destination()))

for edge in edges:
    edges[edge].sort()
    for i in range(2):
        dest = graph.get_node (str(edges[edge][i]))[0]
        dest.set_fillcolor(colors[i])

graph.write_png ('tree.png')
