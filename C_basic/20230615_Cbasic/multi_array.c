#include <stdio.h>



int main(void)
{
	Work002();

}




int Desc001()
{

	int arr[2][3] =
	{
		{1,2,3,}, // 0���� int[3] �迭
		{1,2,3,}  // 1���� int[3] �迭
	};


	int arr_count = sizeof(arr) / sizeof(arr[0]);
	int arr_length = sizeof(arr[0]) / sizeof(arr[0][0]);

	// 0��° �迭 ��� ��� ���


	// 2. �迭 ������ŭ �ݺ�
	for (int arr_idx = 0; arr_idx < arr_count; arr_idx++)
	{
		// 1, 1���� �迩�l ��� ��Ҹ� ����ϴ� ������
		for (int data_idx = 0; data_idx < arr_length; data_idx++)
		{
			printf("%d\n", arr[arr_idx][data_idx]);
		}
	}




	return 0;
}

int Desc002()
{
	int arr[2][3]; // �Ϸ翡 ��� 3�ٲ �� 2�ϵ��� ���� �Ͱ� �Ȱ��� �ǹ�
	// ��� 3���� ���� ����� 2����ŭ, �� ��Ҵ� 6��.


	arr[1][2]; // �Ϸ縦 �� ����, + 2 ���� �� ��

	/*int arr[n][m];

	arr[i][j]
	arr[i * m + j]*/


}

int Desc003()
{
	int arr[3] = { 0 , };

	f(arr, 3);

	for (int i = 0; i < 3; i++)
	{
		printf("%d", arr[i]);
	}

	return 0;

	//arr[0]�� �ּ� = arr[0]�� �ּ� + sizeof(int) * 0����Ʈ
	//arr[1]�� �ּ� = arr[0]�� �ּ� + sizeof(int) * 1����Ʈ
	//arr[2]�� �ּ� = arr[0]�� �ּ� + sizeof(int) * 2����Ʈ
	//arr[3]�� �ּ� = arr[0]�� �ּ� + sizeof(int) * 3����Ʈ

}

// int f(int* arr,int size)�� ���� �ڵ�
int f(int arr[], int size) // �迭�� ������ ������ sizeof() �� ����� �������� �ʾ� size ���� ���� ������ �־�� �Ѵ�.
{
	for (int i = 0; i < size; i++)
	{
		arr[i] = i;
	}
}

int Work001()
{
	// ���� : ���ڿ� ���� ���� ����


	char str[] = "Hello World!";


	printf("%s\n", str);	// Hello World!


	int size = sizeof(str) / sizeof(str[0]) - 1;

	// �ڵ� �ۼ�

	for (int i = 0; i < size / 2; i++)
	{
		char temp = str[i];
		str[i] = str[(size - 1) - i ];
		str[(size - 1) - i ] = temp;
	}

	printf("%s", str);





	// ���ϴ� ��¹�
	// !dlroW olleH 





	return 0;
}

int Work002()
{
	int num = 7;


	while (num > 0)
	{



	}



}