// PROJETO LAB.cpp : Defines the entry point for the console application.
//
#define _CRT_SECURE_NO_WARNINGS_
#include "stdafx.h"
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#define TRUE 1
#define FALSE 0

typedef struct smartphone {
	char marca[10];
	char designacao[20];
	int codigo[6];
	char dual_sim[8];
	float preco;
	int stock;
}smartphone;

smartphone *listaSP = NULL;

//MENU
char Menu(void) {

	char opt = '0';

	printf("Escolha uma opcao:\n");
	printf("1. Mostrar todos os dados SMARTPHONE atraves do seu codigo\n"
		   "2. Listar produtos por marca\n"
		   "3. Vender um SMARTPHONE (se o stock for zero este deve ser eliminado do sistema)\n "
		   "4. Acrescentar SMARTPHONE (1 ou mais)\n"
		   "0. Sair\n");

	scanf("%c",opt);
	return (opt);
}

////Função para ler dados do ficheiro "BD.txt" para um vetor de estruturas smartphone
//Vetor alocado dinamicamente
//Formato do ficheiro: marca;designacao;codigo;dual_sim;preco;stock \n

int lerficheiro(void) {

	FILE* ficheiro;
	char aux;
	int num_linhas = 0;
	int i = 0;

	if ((ficheiro = fopen("BD.txt", "r")) == NULL) {
		printf("Erro na abertura do ficheiro");
		return 0;
	}
	else {

		while (!feof(ficheiro)) {
			aux = fgetc(ficheiro); //lê do ficheiro

			if (aux == '\n') num_linhas++;
		}

		printf("\n %d linhas do ficheiro", num_linhas);

		listaSP = (smartphone*)malloc(num_linhas * sizeof(smartphone)); //cria o vetor

		rewind(ficheiro); //voltar ao início do ficheiro

		//ler linha a linha do ficheiro:
		for (i = 0; i < num_linhas; i++) {
			fscanf(ficheiro, "%[^;];%[^;];%d;%[^;];%f;%d\n",
				&listaSP[i].marca,
				&listaSP[i].designacao,
				&listaSP[i].codigo,
				&listaSP[i].dual_sim,
				&listaSP[i].preco,
				&listaSP[i].stock);
		}

		fclose(ficheiro);
		return num_linhas;
	}
}

//Mostrar todos os dados de um Smartphone através do seu código
void apresentaSP(void) {

	int *cod;
	int i;
	int total_sphones=lerficheiro();
	int encontrado = FALSE; 

	printf("Insira o codigo do smartphone:\n");
	scanf("%d", &cod);

	//procura o smartphone correspondente aquele código:
	for (i = 0; i < total_sphones; i++) {

		if (listaSP[i].codigo == cod) {
			encontrado = TRUE;

			printf("\nProduto é:\n"
				   "Marca: %s\n"
				   "Designação: %s\n"
				   "Código: %d\n"
				   "Dual Sim: %s\n"
				   "Preço: %f\n"
				   "Stock existente: %d\n",
				listaSP[i].marca,
				listaSP[i].designacao,
				listaSP[i].codigo,
				listaSP[i].dual_sim,
				listaSP[i].preco,
				listaSP[i].stock);
									}
	}

	if (encontrado == FALSE) printf("\nProduto não encontrado.\n");
	system("pause");
} 

//Listar os produtos por marca:
void listarSP(void) {

	int total_sphones = lerficheiro();
	char m[10];
	int i;

	printf("Insira a marca do smartphone");
	scanf("%s", &m);


	for (i = 0; i < total_sphones; i++) {

		if (strcmp(listaSP[i].marca, m) == 0) {

			printf("%s : %s : %d : %s : %.2f : %d \n",
				listaSP[i].marca,
				listaSP[i].designacao,
				listaSP[i].codigo,
				listaSP[i].dual_sim,
				listaSP[i].preco,
				listaSP[i].stock);

		}
	}
}


//Vender um smartphone
//Se o stock for zero deve ser elimina-o


void removeSP() {


}
void venderSP(void) {

	int *cod;
	int i;
	int total_sphones = lerficheiro();
	int encontrado = FALSE;

	//ir ao vetor procurar o produto, diminuir o valor do stock, e quando o stock for zero eliminar do ficheiro

	printf("Insira o codigo do smartphone que vendeu:\n");
	scanf("%d", &cod);

	//procura o smartphone correspondente aquele código:
	for (i = 0; i < total_sphones; i++) {

		if (listaSP[i].codigo == cod) {
			encontrado = TRUE;

			if ((listaSP[i].stock) == 0) { removeSP(); }
			printf("\nProduto é:\n"
				"Marca: %s\n"
				"Designação: %s\n"
				"Código: %d\n"
				"Dual Sim: %s\n"
				"Preço: %f\n"
				"Stock existente: %d\n",
				listaSP[i].marca,
				listaSP[i].designacao,
				listaSP[i].codigo,
				listaSP[i].dual_sim,
				listaSP[i].preco,
				listaSP[i].stock);
		}
	}



	//o smartphone nao sera apagado, nao vai é ser gravado para o ficheiro






}


void acrescentarSP(void)
{
	int cod, quant,i;
	int total_sphones = lerficheiro();

	printf("\nInsira o codigo do produto a acrescentar: ");
	scanf("%d", &cod);

	printf("Qual a quantidade que quer acrescentar? ");
	scanf("%d", &quant);

	for (i = 0; i < total_sphones; i++) {
		if (listaSP[i].codigo == &cod) {
			listaSP[i].stock = +quant;

			gravarLista(); //escreve no ficheiro o vetor

			return;
		}
		else printf("\n Não existe um produto com esse codigo\n");
	}

	system("pause");
}

int gravarLista(void) {

	FILE *ficheiro;
	int i;
	int total_sphones = lerficheiro();

	if ((ficheiro = fopen("BD.txt", "w")) == NULL) {
		printf("\nErro na abertura do ficheiro!\n");
		return -1;
	}

	else {

		for (i = 0; i < total_sphones; i++) {

			if (listaSP[i].stock > 0) {

				fprintf(ficheiro, "%-10s : %-20s : %-6d : %-8s : %-4.2f : %-5d",
					listaSP[i].marca,
					listaSP[i].designacao,
					listaSP[i].codigo,
					listaSP[i].dual_sim,
					listaSP[i].preco,
					listaSP[i].stock);
			}
		}
	}
	fclose(ficheiro);
}

//cria um ficheiro <log.txt> com: nº total marcas de smartphone;
								// nº total produtos em stock;
								// valor total dos smartphones.

int criarLog(void) {

	FILE *ficheiro;
	int numMarcas = 0;
	int numSP= 0;
	float valorProd = 0;
	int total_sphones = lerficheiro();

	ficheiro = fopen("log.txt", "w");

	if (ficheiro == NULL) {
		printf("\nErro na abertura do ficheiro!\n");
		return FALSE;
	}
	else {
		//calcula:
		for (int i = 0; i < total_sphones; i++) {

			valorProd = valorProd + listaSP[i].preco*listaSP[i].stock;

			numSP = numSP + listaSP[i].stock;
		}

		fprintf(ficheiro, "Numero total de marcas: %d\n"
			"Numero total de smartphones: %d\n"
			"Valor total dos produtos: %.2f",
			numMarcas, numSP, valorProd);
		fclose(ficheiro);

		return TRUE;
	}
}

int main()
{	char opt;
	int total_sphones;
	int sair = FALSE;
	
	total_sphones= lerficheiro();

	if (total_sphones == 0) {
		printf("\nErro de leitura!\n");
		system("pause");
		return 0;
	}

	printf("\nBase de dados lida com sucesso." 
			"Foram lidos %d elementos", total_sphones);

	if (criarLog()) printf("\nFicheiro log.txt criado com sucesso");

	else printf("\nErro na criação do ficheiro log.txt");

	do {
		opt = Menu();
		switch (opt) {

		case '1': apresentaSP();
				  break;


		case '2': listarSP(); 
				   break;


		case '3': venderSP(); 
				  break;


		case '4': acrescentarSP(); 
				  break;


		case '0': sair = TRUE; 
				  break;
		}

	} while (sair == FALSE);

	free(listaSP);

	return 0;
	system("pause");
}

   


