//#include <stdio.h>
//
//int main(void)
//{
//	// 조건 : 문자열 변수 생성 금지
//
//
//	char str[] = "Hello World!";
//
//
//	printf("%s\n", str);	// Hello World!
//
//
//	int size = sizeof(str) / sizeof(str[0]) - 1;
//
//	// 코드 작성
//
//	for (int i = 0; i < size / 2; i++)
//	{
//		char temp = str[i];
//		str[i] = str[(size - 1) - i ];
//		str[(size - 1) - i ] = temp;
//	}
//
//	printf("%s", str);
//
//
//
//
//
//	// 원하는 출력문
//	// !dlroW olleH 
//
//
//
//
//
//	return 0;
//}