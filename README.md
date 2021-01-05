# Decrescendo

## Award
<center><img src="https://user-images.githubusercontent.com/43705434/103533219-1193e000-4ed0-11eb-9770-e7b0a3757b36.jpg" width="300" height="400"></center>
<br>
<br>
<br>

### About Project.:two_men_holding_hands:
데코레센도는 가상의 집을 구성하고, 그 안에 실제 가구들의 3D모델링을 배치해보면서, 실제로 예상되는 모습을 미리 간접적으로 체험해 볼 수 있는 프로젝트 입니다.
또한 비슷한 디자인을 가진 가구들의 가격비교를 할 수 있는 기능도 포함되어 있습니다.<br>
이런 기능들을 통해 사용자는 인테리어를 하는 과정에 있어서 시간과 돈을 절약할 수 있을 것이라 생각합니다. <br>
가격비교를 통해 합리적인 소비로 지출을 아낄 수 있고, 가구를 배치하고 난 후의 모습을 미리 볼 수 있으므로 환불⦁반품률을 줄이는 효과를 예상하고 있습니다.<br>
<br>

### About Dev.:nut_and_bolt:
1. *Spring* : 프레임워크를 사용하여 Web 개발을 효율적으로 진행 할 수 있었습니다.
2. *Mybatis* : DB접근에 있어, 편의성 및 간결성을 보장했습니다.
3. JQuery의 Ajax를 이용한 비동기통신
4. *Data crawling* : Jsoup 라이브러리를 활용하여 실제 가구정보를 받아왔습니다.
5. *DataBase(MySQL)* : 이전에 작업했던 인테리어의 모든 정보를 Json으로 변환하여 DB에 저장하기 위해 로컬 DB를 운영했습니다.
6. *Unity* : 가구를 배치해 볼 수 있는 프로젝트를 제작 후 WebGL로 빌드하여 Web에서 구동시킬 수 있도록 했습니다.<br>
-> Unity에서는 JavaScript코드를 Plugins에 포함시켜 Web에 Json데이터를 전송했고, Web에서는 SendMessage를 사용해서 Unity에 Json데이터를 전송했습니다.
7. *SketchUp* : 실제 가구의 3D모델링을 제작해보았습니다.

### My Part.:computer:
Unity

### Video.:video_camera:
*클릭하세요. (내레이션있습니다!)*<br>
[![시연영상](https://img.youtube.com/vi/ZylFNa6sgBA/0.jpg)](https://www.youtube.com/watch?v=ZylFNa6sgBA)<br>
<br>

### Difficult Point.:sweat_smile:
Unity에서 해결해야할 대표적인 문제(기능)으로는 집을 생성하기 위해 벽의 각도를 계산하는 기능과 집 면적을 알기위해 다각형 넓이를 구하는 기능, 또한 집의 바닥을 생성하는 기능과 해당 바닥에 텍스쳐를 알맞게 씌워야 하는 문제, 마지막으로 벽을 연이어서 생성할 때, 이전에 생성된 벽이 마우스를 따라다니게 되는데, 이를 싱글스레드를 지원하는 Unity의 특성을 고려해 해결해야 하는 문제가 존재했다.

1) 생성할 벽의 각도를 계산하는 기능
float CalculateAngle(Vector3 from, Vector3 to) {
        Vector3 temp = to - from;
   	 // 두 벡터좌표간의 차를 이용하여 각도를 구해서 반환.
        if(temp.x == 0f) {
            return 0f;
        } else if(temp.z == 0f) {
            return 9999f;
        } else {
            return Quaternion.FromToRotation(Vector3.up, temp).eulerAngles.y;
   	     //마우스로 찍은 좌표와 현재 마우스의 위치 좌표간의 각도를 구할 수 있어야 해당 	      각도대로 벽을 생성할 수 있으므로 y축을 기준으로 회전한 각도를 구해야 한다.
        }    
    }

2) 방안의 면적 구하는 기능 : 좌표를 찍었을 때 그려지는 다각형의 넓이를 구하는 메소드 사용
private float Area() {
      int n = m_points.Count;
      float A = 0.0f;
      for (int p = n - 1, q = 0; q < n; p = q++) {
         Vector2 pval = m_points[p];
         Vector2 qval = m_points[q];
         A += pval.x * qval.y - qval.x * pval.y;
      }
      return A * 0.5f;
   }

3) 유저가 찍은 좌표를 기준으로 바닥을 생성하고, 텍스쳐를 알맞게 씌우는 기능.

사용자가 찍은 좌표들을 기반으로 동적으로 다각형을 생성해 바닥을 만들어주도록 구현했는데(오픈소스사용https://gist.github.com/N-Carter/12242476dc4e4036db34), 이때 이 다각형에 Texture를 입혀서 바닥재를 표현하려면 Texture가 다각형에 어떤 좌표들을 기준으로 입혀질지를 정해줘야한다. 이 기준좌표들을 Uv 좌표라고 하는데, 바닥이 정적인 대상이 아니기 때문에 Uv 좌표를 구하기가 쉽지 않았다. 이를 해결하기 위해 사용자가 찍은 3D 좌표들을 Normalize하여 Uv 좌표를 주먹구구식으로 구성하는 방식을 통해 텍스트를 나름 보기좋게 입힐 수 있었다. 이 기능을 구현하는데 있어 아무래도 처음 접하는 분야이다 보니 굉장히 어려움을 많이 겪었다.

4) 이전에 생성된 벽이 마우스좌표를 따라다니게 만드는 기능.

유니티 화면에서 집 구조를 설계할 때 벽을 연이어서 생성하는 기능을 구현했는데, 이때 사용자가 다음번 좌표를 클릭하기 전까지 이전에 생성된 벽이 마우스를 계속해서 따라가게끔 구현했다. 그런데 계속해서 로직을 구동시키는 Update 함수가 마우스를 따라가는 기능에만 얽매이게 되는 문제가 생겼다. 즉, 벽이 마우스를 따라가는 기능만 처리하다보니 다른 조건들을 체크해줄 겨를이 없게 된 것이다. 결국 여러 번의 부딪힘 끝에 서브루틴(을 만들 수 있는 방법을 알게 되어 마우스를 따라가는 기능을 서브루틴에 안주시켜, 기존 루틴은 계속해서 다른 로직들을 체크할 수 있도록 구현하여 해결하였다.

5 Unity에서 평면도를 그릴때, 뒤에 보이는 격자들이 화면이 멀어질 수록 깨지는 현상을 보여, 화면이 멀어지면 격자의 선을 굵게 해줌으로써 해결함.

### Feeling.:pencil:
팀 프로젝트를 처음으로 진행해본 것이라서 프로젝트의 방향성과 스케일을 정하는 데 많은 어려움이 있었습니다. 그래도 부딪히며 배워보자는 생각으로 나름 스케일을 크게 잡았었습니다. 그리하여 소켓 통신, DB, MVC, Java(GUI) 등 많은 것들을 기초부터 배워야 했습니다. 개발 기간이 12주라는 짧다면 짧은 시간이었기에 처음에는 좌절도 많이 했었습니다. 하지만 각 팀원이 맡은 파트를 수행하는 것을 넘어, 서로의 파트를 함께 고민하며 협업한 끝에 성공적으로 마무리 할 수 있었던 것 같습니다. 이 프로젝트를 계기로 3학년 4학년 때 배우게 될 DB, 소켓 통신 등을 예습할 수 있었기 때문에, 추후 지속해서 좋은 성적을 받는 발판이 되기도 했으며, 이때의 팀원들과 4학년을 마무리 할 때까지 많은 팀 활동을 할 수 있는 원동력이 되기도 했습니다.<br>

이번 15주차에는 모든 캡스톤과정을 마치게되면서, 그간 작업해온 프로젝트 결과물에 대해서 코드정리나 기타 리소스들 정리 및 폴더정리를 깔끔하게 마쳤다.

또한 현재 프로젝트를 좀 더 발전시키고 싶어하는 팀원들이 대다수여서 앞으로의 향후 일정을 회의했으며, 현재 프로젝트로 창업공모전에도 참가중이어서 지속적으로 개선할 수 있도록 방안을 세웠다. 

이번 캡스톤 수업을 진행하면서, 코드적인 스킬이나 Tool 활용법, UI설계방법 등 많은것들을 배울 수 있었지만, 가장 중요한 팀워크와 좋은 의사소통방식을 배울 수 있었던 것 같아 매우 뜻깊었고 사회로 진출하는데 있어 도약으로써, 작용할 수 있는 자신감을 불어 넣어 준 것 같았다.

좀 더 완성도있는 결과물을 선보이지 못한것에 큰 아쉬움이 남지만, 굉장히 재미있게 즐기면서 진행할 수 있었던 수업이었다고 생각된다.
<br>

### Documents.:book:
[프로젝트 관련문서](https://github.com/tlagmltjq11/Capston_Documents)
