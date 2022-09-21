/*
   * MSSV: 19110317
   * HoTen: Chau Nguyen Bao Hoang
   * Assigment: bai2
   * Created_at: 4/12/2021
   * IDE: MS Visual Studio 2019 / Code C++
*/

#include <iostream>
#include<fstream>
using namespace std;
#define Max 100

void readFile(int &dem, int mtk[][Max]) {
	int arr[Max];
	int z = 0;

	ifstream FileIn;
	FileIn.open("input_dothi.txt", ios_base::in);
	if (FileIn.fail() == true)
	{
		cout << "File khong ton tai\n";
		system("pause");
		exit(0);
	}
	
	while (!FileIn.eof())
	{
		dem++;
		FileIn >> arr[dem];
	}
	
	for (int i = 0; i < sqrt(dem); i++) {
		for (int j = 0; j < sqrt(dem); j++) {
			mtk[i][j] = arr[z];
			z++;
		}
	}

	FileIn.close();
}

void connectedComponents(int a[Max] ,int mtk[][Max], int dem) {
	for (int i = 0; i < sqrt(dem); i++) {
		a[i] = i + 1;
	}

	for (int i = 0; i < sqrt(dem); i++) {
		for (int j = 0; j < sqrt(dem); j++) {
			if (mtk[i][j] == 1) {
				if (a[j] > a[i]) {
					a[j] = a[i];
				}
				else if (a[i] > a[j]) {
					a[i] = a[j];
				}
			}
		}
	}
}

void outPut(int a[Max], int mtk[][Max], int dem) {
	int z = 0;
	int t = 0;

	for (int m = 0; m < sqrt(dem); m++) {
		if (a[m] == m + 1) {
			z++;
		}
	}
	cout << "So luong thanh phan lien thong:" << z;
	
	for (int i = 0; i < sqrt(dem); i++) {
		if (a[i] == i + 1) {
			t++;
			cout << "\nthanh phan " <<  t << ": ";
			for (int j = 0; j < sqrt(dem); j++) {
				if (a[j] == a[i]) {
					cout << j + 1 << " ";
				}
			}
		}
	}
	cout << endl;
}

int main()
{
	int mtk[Max][Max];
	int dem = -1;
	int a[Max];
	
	readFile(dem, mtk);
	connectedComponents(a, mtk, dem);
	outPut(a, mtk, dem);
	system("pause");
}

