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
1. *Unity* : 가구를 배치해 볼 수 있는 프로젝트를 제작 후 WebGL로 빌드하여 Web에서 구동시킬 수 있도록 했습니다.
-> Unity에서는 JavaScript코드를 Plugins에 포함시켜 Web에 Json데이터를 전송했고, Web에서는 SendMessage를 사용해서 Unity에 Json데이터를 전송했습니다.
2. *SketchUp* : 실제 가구의 3D모델링을 제작해보았습니다.
3. *Spring* : 프레임워크를 사용하여 Web 개발을 효율적으로 진행 할 수 있었습니다.
4. *Mybatis* : DB접근에 있어, 편의성 및 간결성을 보장했습니다.
5. *Ajax* : 비동기방식으로 요청할 수 있도록 했습니다.
6. *Data crawling* : Jsoup 라이브러리를 활용하여 실제 가구정보를 받아왔습니다.
7. *DataBase(MySQL)* : 이전에 작업했던 인테리어의 모든 정보를 Json으로 변환하여 DB에 저장하기 위해 로컬 DB를 운영했습니다.
<br>

### My Part.:computer:
Unity를 이용해 가상의 집을 구성하고, 가구를 배치해 볼 수 있는 프로젝트를 도맡아 개발했습니다.<br>
<br>

### Video.:video_camera:
*클릭하세요.* ***(내레이션있습니다!)***<br>
[![시연영상](https://img.youtube.com/vi/ZylFNa6sgBA/0.jpg)](https://www.youtube.com/watch?v=ZylFNa6sgBA)<br>
<br>

### Difficult Point.:sweat_smile:
* User가 찍은 2개의 vector3 좌표에 알맞게 벽을 생성해주어야 했는데, 벽의 Position은 두 좌표의 중간으로 해결할 수 있었지만 벽의 각도를 정하는데 문제가 있었습니다.
고심끝에 내적을 이용하여 두 좌표간의 각도를 구하고, 외적을 이용해서 좌우를 판별해서, 해당 각도로 벽의 각도를 설정해주면 될 것 같다는 아이디어를 얻을 수 있었습니다.
하지만, 추후에 Unity가 제공하는 메소드들을 공부하다보니 Quaternion.FromToRotation이나 Vector3.Angle등 벡터간의 각도를 구해주는 메소드들이 있다는 것을 알게되었고 더욱 손쉽게 해결할 수 있었습니다. -> 지금 생각해보니 내적,외적보다는 아크탄젠트로 각도를 구했으면 됐었던 것 같습니다..

<br>

* 사용자가 찍은 좌표들을 기반으로 동적으로 다각형을 생성해 바닥을 만들어주어야하는 문제가 있었는데, 당시 구현에 너무 큰 어려움을 겪었습니다.
그리하여 [오픈소스](https://gist.github.com/N-Carter/12242476dc4e4036db34)를 찾아보니, 다음과같이 제가 원하는 기능을 구현해둔 오픈소스를 찾을 수 있었습니다.
이를 통해, 바닥을 생성해 줄 수 있었습니다.

<br>

* User가 벽을세워 만들어낸 바닥에 Texture를 입혀서 바닥재를 표현하려면, Texture가 어떤 좌표들을 기준으로 입혀질지를 정해줘야한다는것을 배웠습니다. 하지만 정적인 대상이 아니였기 때문에 Uv 좌표를 구하기가 쉽지 않았습니다. 이를 해결하기 위해 사용자가 찍은 좌표들을 Normalize하여, Uv 좌표를 주먹구구식으로 구성하는 방식을 통해 텍스트를 나름 보기좋게 입힐 수 있었습니다.

<br>

* 집 구조를 설계할 때 벽을 연이어서 생성하는 기능을 구현했는데, 이때 사용자가 다음번 좌표를 클릭하기 전까지 이전에 생성된 벽이 마우스를 계속해서 따라가게끔 구현했습니다. 그런데 계속해서 로직을 구동시키는 Update 함수가 마우스를 따라가는 기능에만 얽매이게 되는 문제가 생겼습니다. 결국 여러 번의 부딪힘 끝에 서브루틴을 만들 수 있는 방법인 코루틴을 알게 되어 마우스를 따라가는 기능을 서브루틴에 안주시켜, 기존 루틴은 계속해서 다른 로직들을 체크할 수 있도록 구현하여 해결하였습니다.

<br>

* Unity에서 평면도를 그릴때, 뒤에 보이는 격자들이 화면이 멀어질 수록 깨지는 현상을 보였습니다. 이를 해결하기 위해서, 카메라가 멀어지면 격자의 선을 굵게 해줌으로써 해결했습니다.

<br>

### Feeling.:pencil:
팀 프로젝트를 처음으로 진행해본 것이라서 프로젝트의 방향성과 스케일을 정하는 데 많은 어려움이 있었습니다. 그래도 부딪히며 배워보자는 생각으로 나름 스케일을 크게 잡았었습니다. 그리하여 소켓 통신, DB, MVC, Java(GUI) 등 많은 것들을 기초부터 배워야 했습니다. 개발 기간이 12주라는 짧다면 짧은 시간이었기에 처음에는 좌절도 많이 했었습니다. 하지만 각 팀원이 맡은 파트를 수행하는 것을 넘어, 서로의 파트를 함께 고민하며 협업한 끝에 성공적으로 마무리 할 수 있었던 것 같습니다. 이 프로젝트를 계기로 3학년 4학년 때 배우게 될 DB, 소켓 통신 등을 예습할 수 있었기 때문에, 추후 지속해서 좋은 성적을 받는 발판이 되기도 했으며, 이때의 팀원들과 4학년을 마무리 할 때까지 많은 팀 활동을 할 수 있는 원동력이 되기도 했습니다.<br>

이번 15주차에는 모든 캡스톤과정을 마치게되면서, 그간 작업해온 프로젝트 결과물에 대해서 코드정리나 기타 리소스들 정리 및 폴더정리를 깔끔하게 마쳤다.

또한 현재 프로젝트를 좀 더 발전시키고 싶어하는 팀원들이 대다수여서 앞으로의 향후 일정을 회의했으며, 현재 프로젝트로 창업공모전에도 참가중이어서 지속적으로 개선할 수 있도록 방안을 세웠다. 

이번 캡스톤 수업을 진행하면서, 코드적인 스킬이나 Tool 활용법, UI설계방법 등 많은것들을 배울 수 있었지만, 가장 중요한 팀워크와 좋은 의사소통방식을 배울 수 있었던 것 같아 매우 뜻깊었고 사회로 진출하는데 있어 도약으로써, 작용할 수 있는 자신감을 불어 넣어 준 것 같았다.

좀 더 완성도있는 결과물을 선보이지 못한것에 큰 아쉬움이 남지만, 굉장히 재미있게 즐기면서 진행할 수 있었던 수업이었다고 생각된다.
<br>

### Documents.:book:
[프로젝트 관련문서](https://github.com/tlagmltjq11/Capston_Documents)
