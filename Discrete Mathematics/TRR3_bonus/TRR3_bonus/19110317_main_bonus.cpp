/*
   * MSSV: 19110317
   * HoTen: Chau Nguyen Bao Hoang
   * Assigment: bai bonus
   * Created_at: 30/12/2021
   * IDE: MS Visual Studio 2019 / Code C++
*/

#include <iostream>
#include <fstream>
#include <string>
using namespace std;

#define MAX 100
#define INF 10000

void inPut(int a[MAX], int &dem, int &vertex, int &A, int &Z) {
	ifstream FileIn;
	FileIn.open("thong_tin_dinh_3.txt", ios_base::in);
	if (FileIn.fail() == true)
	{
		cout << "File khong ton tai\n";
		system("pause");
		exit(0);
	}

	while (!FileIn.eof())
	{
		dem++;
		FileIn >> a[dem];
	}

	vertex = a[2];
	A = a[dem - 2];
	Z = a[dem - 1];
	FileIn.close();

	
}

void adjacencyMatrix(int a[MAX], int mtk[][MAX], int dem, int vertex) {
	int b[MAX];
	int z = 1;

	for (int i = 3; i < dem - 2; i++) {
		b[i - 2] = a[i];
		z++;
	}
	
	for (int i = 1; i <= vertex; i++) {
		for (int j = 1; j <= vertex; j++) {
			mtk[i][j] = NULL;
		}
	}


	for (int i = 1; i < z; i = i + 3) {
		if (a[1] == 1) {
			mtk[b[i]][b[i + 1]] = b[i + 2];
		}
		else
		{
			mtk[b[i]][b[i + 1]] = b[i + 2];
			mtk[b[i + 1]][b[i]] = b[i + 2];
		}

	}
}

void Dijkstra(int length[MAX], int before[MAX], int mtk[][MAX], int vertex, int A) {
	bool out[MAX];
	for (int i = 1; i <= vertex; i++) {
		length[i] = INF;
		before[i] = -1;
		out[i] = false;
	}

	int c = A;
	length[A] = 0;
	before[A] = 0;
	out[A] = true;


	for (int i = 1; i <= vertex; i++)
	{
		int min = INF;
		int minindex = -1;
		for (int i = 1; i <= vertex; i++) {

			if (out[i] == false && length[i] < min)
			{
				min = length[i];
				minindex = i;
			}
		}
		if (minindex != -1) {
			out[minindex] = true;
			c = minindex;
		}

		for (int j = 1; j <= vertex; j++)
		{
			if (!out[j] && mtk[c][j] != 0 && length[c] != INF && length[c] + mtk[c][j] < length[j]) {
				length[j] = length[c] + mtk[c][j];
				before[j] = c;
			}

		}
	}
}

void outFile(int length[MAX], int before[MAX],string v[MAX] , int Z, int vertex, int vdem) {
	ofstream Fileout("ket_qua_bonus_19110317.txt");
	if (before[Z] == -1) {
		Fileout << "Khong co duong di ngan nhat";
	}
	else {
		Fileout << "Tong chi phi di chuyen = " << length[Z] << endl;
		Fileout << "Duong di ngan nhat cua do thi la:";
		int op[MAX];
		int after = before[Z];
		op[0] = Z;
		int z = 0;
		for (int i = 0; i < vertex; i++) {
			for (int j = vertex; j >= 0; j--) {
				if (after == j) {
					z++;
					op[z] = j;
					after = before[j];
				}
				if (after == 0) {
					break;
				}
			}
		}
		for (int i = z; i >= 0; i--) {
			for (int j = 1; j <= vdem; j++) {
				if (op[i] == j) {
					Fileout << v[j] << " ";
				}

			}
			if (op[i] == Z) {
				break;
			}
			Fileout << "->";
		}
	}
	Fileout.close();
}

void vInput(string v[MAX], int &vdem) {
	ifstream FileIn2;
	FileIn2.open("ten_dinh.txt", ios_base::in);
	if (FileIn2.fail() == true)
	{
		cout << "File khong ton tai\n";
		system("pause");
		exit(0);
	}

	while (!FileIn2.eof())
	{
		vdem++;
		getline(FileIn2, v[vdem]);

	}

	for (int i = 1; i <= vdem; i++) {
		
		v[i].erase(v[i].begin());
		if (i >= 10) {		
			v[i].erase(v[i].begin());
		}
	}

	FileIn2.close();
}

void outPut(int length[MAX], int before[MAX], string v[MAX], int Z, int vertex, int vdem) {
	if (before[Z] == -1) {
		cout << "Khong co duong di ngan nhat";
	}
	else {
		cout << "Tong chi phi di chuyen = " << length[Z] << endl;
		cout << "Duong di ngan nhat cua do thi la:";
		int op[MAX];
		int after = before[Z];
		op[0] = Z;
		int z = 0;
		for (int i = 0; i < vertex; i++) {
			for (int j = vertex; j >= 0; j--) {
				if (after == j) {
					z++;
					op[z] = j;
					after = before[j];
				}
				if (after == 0) {
					break;
				}
			}
		}
		for (int i = z; i >= 0; i--) {
			for (int j = 1; j <= vdem; j++) {
				if (op[i] == j) {
					cout << v[j] << " ";
				}

			}
			if (op[i] == Z) {
				break;
			}
			cout << "->";
		}
	}
	
}

int main()
{
	int a[MAX];
	int mtk[MAX][MAX];
	int length[MAX];
	int before[MAX];
	int vertex = 0, dem = 0, A = 0, Z = 0;
	string v[MAX];
	int vdem = 0;

	inPut(a, dem, vertex, A, Z);
	adjacencyMatrix(a, mtk, dem, vertex);
	Dijkstra(length, before, mtk, vertex, A);
	vInput(v, vdem);
	outPut(length, before, v, Z, vertex, vdem);
	outFile(length, before, v, Z, vertex, vdem);
	
	cout << endl;
	system("pause");

}