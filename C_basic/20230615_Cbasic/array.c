//#include <stdio.h>
//
//int main(void)
//{
//	// ���� : ���ڿ� ���� ���� ����
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
//	// �ڵ� �ۼ�
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
//	// ���ϴ� ��¹�
//	// !dlroW olleH 
//
//
//
//
//
//	return 0;
//}