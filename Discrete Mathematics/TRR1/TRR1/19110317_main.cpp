/*
   * MSSV: 19110317
   * HoTen: Chau Nguyen Bao Hoang
   * Assigment: bai1
   * Created_at: 11/11/2021
   * IDE: MS Visual Studio 2019 / Code C
*/

#include <stdio.h>
#include <conio.h>
#define MAX 100

int orFunction (int p, int q) { 
	if (p == 0 && q == 0)
		return 0;
	return 1;
} 

int andFunction (int p, int q) { 
	if (p == 1 && q == 1)
		return 1;
	return 0;
}

int nFunction(int p)  
{
	if (p == 0)
		return 1;
	return 0;
}

int cFunction(int p, int q) 
{
	if (p == 1 && q == 0)
		return 0;
	return 1;
}

int bFunction(int p, int q) 
{
	if ((p == 0 && q == 0) || (p == 1 && q == 1))
		return 1;
	return 0;
}

int convert(int dec, int bin[], int n) 
{
	for (int i = 0; i < n; i++) {
		bin[i] = dec % 2;
		dec = dec / 2;
	}
	return 1;
}

void outputTable(int a[][100], int n, int key) {
	if (n == 1) {
		a[0][3] = { 'p' }; // Những đoạn input p q và các phép em mới nghĩ ra cách phút chốt
		a[0][4] = { '~' }; // nên bố cục code hơi xấu thầy/chị thông cảm 15.11.2021
		printf_s("%c\t%c%c\n", a[0][3], a[0][4], a[0][3]);
		for (int i = 1; i > -1; i--) { 
			for (int j = 0; j < 2; j++) {
				if (a[i][j] == 1)
					printf_s("T\t");
				else
				{
					printf_s("F\t");
				}
			}
			printf_s("\n");
		}
	}
	else
	{
		if (key == 1) {
			a[0][3] = { 'p' };
			a[0][4] = { 'q' };
			a[0][5] = { 'v' };
			printf_s("%c\t%c\t%c%c%c\n", a[0][3], a[0][4], a[0][3], a[0][5], a[0][4]);
		}
		else if (key == 2){
			a[0][3] = { 'p' };
			a[0][4] = { 'q' };
			a[0][5] = { '^' };
			printf_s("%c\t%c\t%c%c%c\n", a[0][3], a[0][4], a[0][3], a[0][5], a[0][4]);
		}
		else if (key == 3) {
			a[0][3] = { 'p' };
			a[0][4] = { 'q' };
			a[0][5] = { '-' };
			a[0][6] = { '>' };
			printf_s("%c\t%c\t%c%c%c%c\n", a[0][3], a[0][4], a[0][3], a[0][5], a[0][6], a[0][4]);
		}
		else if (key == 4) {
			a[0][3] = { 'p' };
			a[0][4] = { 'q' };
			a[0][5] = { '<' };
			a[0][6] = { '-' };
			a[0][7] = { '>' };
			printf_s("%c\t%c\t%c%c%c%c%c\n", a[0][3], a[0][4], a[0][3], a[0][5], a[0][6], a[0][7], a[0][4]);
		}
		
		for (int i = 3; i > -1; i--) {
			for (int j = 0; j < 3; j++) {
				if (a[i][j] == 1)
					printf_s("T\t");
				else
				{
					printf_s("F\t");
				}
			}
			printf_s("\n");
		}
	}
	printf_s("\n");
}

void inputTable(int a[][100], int dec, int bin[], int n, int key) {
	if (n == 1) {
		for (int dec = 0; dec < 2 * n; dec++) {
			convert(dec, bin, n);
			for (int j = 0; j < 1; j++) {
				a[dec][j] = bin[j];
				a[dec][j + 1] = nFunction(a[dec][j]);
			}
		}
	}
	else if (n == 2)
	{
		if (key == 1) {
			for (int dec = 0; dec < 2 * n; dec++) {
				convert(dec, bin, n);
				for (int j = 0; j < 1; j++) {
					a[dec][j] = bin[j + 1];
					a[dec][j + 1] = bin[j];
					a[dec][j + 2] = orFunction(a[dec][j], a[dec][j + 1]);
				}
			}
		}
		else if (key == 2)
		{
			for (int dec = 0; dec < 2 * n; dec++) {
				convert(dec, bin, n);
				for (int j = 0; j < 1; j++) {
					a[dec][j] = bin[j + 1];
					a[dec][j + 1] = bin[j];
					a[dec][j + 2] = andFunction(a[dec][j], a[dec][j + 1]);
				}
			}
			 
		}
		else if (key == 3) {
			for (int dec = 0; dec < 2 * n; dec++) {
				convert(dec, bin, n);
				for (int j = 0; j < 1; j++) {
					a[dec][j] = bin[j + 1];
					a[dec][j + 1] = bin[j];
					a[dec][j + 2] = cFunction(a[dec][j], a[dec][j + 1]);
				}
			}
		}
		else if (key == 4) {
			for (int dec = 0; dec < 2 * n; dec++) {
				convert(dec, bin, n);
				for (int j = 0; j < 1; j++) {
					a[dec][j] = bin[j + 1];
					a[dec][j + 1] = bin[j];
					a[dec][j + 2] = bFunction(a[dec][j], a[dec][j + 1]);
				}
			}
		}
	}
}

void main() {
	int a[MAX][MAX];
	int bin[MAX], dec = 0, key = 1;
	
	int	n = 1;
	inputTable(a, dec, bin, n, key);
	outputTable(a, n, key);

	n = 2;
	inputTable(a, dec, bin, n, key);
	outputTable(a, n, key);

	key = 2;
	inputTable(a, dec, bin, n, key);
	outputTable(a, n, key);

	key = 3;
	inputTable(a, dec, bin, n, key);
	outputTable(a, n, key);

	key = 4;
	inputTable(a, dec, bin, n, key);
	outputTable(a, n, key);

	_getch();
}