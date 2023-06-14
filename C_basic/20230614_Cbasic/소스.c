#include <stdio.h>




int main()
{
    int student_scores[3];
    student_scores[0] = 20;
    student_scores[1] = 80;
    student_scores[2] = 30;

    // 1. int student_scores[3];  초기화 X
    // 2. int student_scores[3] = { 20, 80, 30 };
    // 3. int studnet_socres[] = {20, 80, 30 );     2와 같은 코드
    // 4. int student_scores[3] = {20, 80 };    비워둔 값은 컴퓨터가 0으로 초기화해줌
    //    int student_scores[3] = {20, 80, };  ,를 쓰는 이유는 같은 개발자에게
    //                                         보여주기 위하여  
    // 5. int student_scores[3] = { 0 };
    


}
