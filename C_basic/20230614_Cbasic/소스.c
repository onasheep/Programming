#include <stdio.h>




int main()
{
    int student_scores[3];
    student_scores[0] = 20;
    student_scores[1] = 80;
    student_scores[2] = 30;

    // 1. int student_scores[3];  �ʱ�ȭ X
    // 2. int student_scores[3] = { 20, 80, 30 };
    // 3. int studnet_socres[] = {20, 80, 30 );     2�� ���� �ڵ�
    // 4. int student_scores[3] = {20, 80 };    ����� ���� ��ǻ�Ͱ� 0���� �ʱ�ȭ����
    //    int student_scores[3] = {20, 80, };  ,�� ���� ������ ���� �����ڿ���
    //                                         �����ֱ� ���Ͽ�  
    // 5. int student_scores[3] = { 0 };
    


}
