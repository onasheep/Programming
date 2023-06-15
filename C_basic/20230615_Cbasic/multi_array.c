#include <stdio.h>



int main(void)
{
	Work002();

}




int Desc001()
{

	int arr[2][3] =
	{
		{1,2,3,}, // 0번쨰 int[3] 배열
		{1,2,3,}  // 1번쨰 int[3] 배열
	};


	int arr_count = sizeof(arr) / sizeof(arr[0]);
	int arr_length = sizeof(arr[0]) / sizeof(arr[0][0]);

	// 0번째 배열 모든 요소 출력


	// 2. 배열 개수만큼 반복
	for (int arr_idx = 0; arr_idx < arr_count; arr_idx++)
	{
		// 1, 1차원 배여릐 모든 요소를 출력하는 행위를
		for (int data_idx = 0; data_idx < arr_length; data_idx++)
		{
			printf("%d\n", arr[arr_idx][data_idx]);
		}
	}




	return 0;
}

int Desc002()
{
	int arr[2][3]; // 하루에 운동장 3바뀌씩 총 2일도안 도는 것과 똑같은 의미
	// 요소 3개를 묶은 덩어리를 2개만큼, 총 요소는 6개.


	arr[1][2]; // 하루를 돈 상태, + 2 바퀴 더 돔

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

	//arr[0]의 주소 = arr[0]의 주소 + sizeof(int) * 0바이트
	//arr[1]의 주소 = arr[0]의 주소 + sizeof(int) * 1바이트
	//arr[2]의 주소 = arr[0]의 주소 + sizeof(int) * 2바이트
	//arr[3]의 주소 = arr[0]의 주소 + sizeof(int) * 3바이트

}

// int f(int* arr,int size)와 같은 코드
int f(int arr[], int size) // 배열을 변수로 받으면 sizeof() 가 제대로 동작하지 않아 size 값을 따로 변수로 주어야 한다.
{
	for (int i = 0; i < size; i++)
	{
		arr[i] = i;
	}
}

int Work001()
{
	// 조건 : 문자열 변수 생성 금지


	char str[] = "Hello World!";


	printf("%s\n", str);	// Hello World!


	int size = sizeof(str) / sizeof(str[0]) - 1;

	// 코드 작성

	for (int i = 0; i < size / 2; i++)
	{
		char temp = str[i];
		str[i] = str[(size - 1) - i ];
		str[(size - 1) - i ] = temp;
	}

	printf("%s", str);





	// 원하는 출력문
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