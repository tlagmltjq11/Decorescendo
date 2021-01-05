# Decrescendo

## Award.
<center><img src="https://user-images.githubusercontent.com/43705434/103533219-1193e000-4ed0-11eb-9770-e7b0a3757b36.jpg" width="300" height="400"></center>
<br>
<br>
<br>

### About Project.:two_men_holding_hands:
데코레센도는 가상의 집을 구성하고, 그 안에 실제 가구들의 3D모델링을 배치해보면서, 실제로 예상되는 모습을 미리 간접적으로 체험해 볼 수 있는 프로젝트 입니다.
또한 비슷한 디자인을 가진 가구들의 가격비교를 할 수 있는 기능도 포함되어 있습니다.<br>

이런 기능들을 통해 사용자는 인테리어를 하는 과정에 있어서 시간과 돈을 절약할 수 있을 것이라 생각합니다.
가격비교를 통해 합리적인 소비로 지출을 아낄 수 있고, 가구를 배치하고 난 후의 모습을 미리 볼 수 있으므로 환불⦁반품률을 줄이는 효과를 예상하고 있습니다.<br>
<br>

### About Dev.:nut_and_bolt:
1. *Unity* : 가구를 배치해 볼 수 있는 프로젝트를 제작 후 WebGL로 빌드하여 Web에서 구동시킬 수 있도록 했습니다.<br>
-> Unity에서는 JavaScript코드를 Plugins에 포함시켜 Web에 Json데이터를 전송했고, Web에서는 SendMessage를 사용해서 Unity에 Json데이터를 전송했습니다.
2. *Spring* : 프레임워크를 사용하여 Web 개발을 효율적으로 진행 할 수 있었습니다.
3. *Mybatis* : DB접근에 있어, 편의성 및 간결성을 보장했습니다.
4. *Ajax* : 비동기방식으로 요청할 수 있도록 했습니다.
5. *Data crawling* : Jsoup 라이브러리를 활용하여 실제 가구정보를 받아왔습니다.
6. *DataBase(MySQL)* : 이전에 작업했던 인테리어의 모든 정보를 Json으로 변환하여 DB에 저장하기 위해 로컬 DB를 운영했습니다.
<br>

### My Part.:computer:
__Unity를 이용해 가상의 집을 구성하고, 가구를 배치해 볼 수 있는 프로젝트를 도맡아 개발했습니다.__<br>
<br>

### Video.:video_camera:
*클릭하세요.* ***(내레이션있습니다!)***<br>
[![시연영상](https://img.youtube.com/vi/ZylFNa6sgBA/0.jpg)](https://www.youtube.com/watch?v=ZylFNa6sgBA)<br>
<br>

### Difficult Point.:sweat_smile:
* 사용자가 찍은 좌표들을 기반으로 동적으로 다각형을 생성해 바닥을 만들어주어야하는 문제가 있었는데, 당시 구현에 너무 큰 어려움을 겪었습니다.
그리하여 [오픈소스](https://gist.github.com/N-Carter/12242476dc4e4036db34)를 찾아보니, 다음과같이 제가 원하는 기능을 구현해둔 오픈소스를 찾을 수 있었습니다.
이를 통해, 바닥을 생성해 줄 수 있었습니다.

<!--
* User가 찍은 2개의 vector3 좌표에 알맞게 벽을 생성해주어야 했는데, 벽의 Position은 두 좌표의 중간으로 해결할 수 있었지만, 벽의 각도를 정하는 데 문제가 있었습니다. 고심 끝에 내적을 이용하여 두 좌표 간의 각도를 구하고, 외적을 이용해서 좌우를 판별해서, 해당 각도로 벽의 각도를 설정해주면 될 것 같다는 아이디어를 얻을 수 있었습니다. 하지만, 이후에 Unity가 제공하는 메소드들을 공부하다 보니 Quaternion.FromToRotation이나Vector3.Angle등 벡터 간의 각도문제를 해결할 수 있는 메소드들이 있다는 것을 알게 되었고 더욱더 손쉽게 개발할 수 있었습니다.<br> -->

<!--
* User가 벽을 세워 만들어낸 바닥에 Texture를 입혀서 바닥재를 표현하려면, Texture가 어떤 좌표들을 기준으로 입혀질지를 정해 줘야 한다는 것을 배웠습니다. 하지만 정적인 대상이 아니었기 때문에 UV 좌표를 구하기가 쉽지 않았습니다. 이를 해결하기 위해 사용자가 찍은 좌표들을 Normalize하여, UV 좌표를 주먹구구식으로 구성하는 방식을 통해 텍스트를 나름 보기 좋게 입힐 수 있었습니다.-->

<!--
* 집 구조를 설계할 때 벽을 연이어서 생성하는 기능을 구현했는데, 이때 사용자가 다음번 좌표를 클릭하기 전까지 이전에 생성된 벽이 마우스를 계속해서 따라가게끔 구현했습니다. 그런데 계속해서 로직을 구동시키는 Update 함수가 마우스를 따라가는 기능에만 얽매이게 되는 문제가 생겼습니다. 결국 여러 번의 부딪힘 끝에 서브루틴을 만드는 방법인 코루틴을 알게 되어 마우스를 따라가는 기능을 서브루틴에 안주시켜, 기존 루틴은 계속해서 다른 로직들을 체크할 수 있도록 구현하여 해결하였습니다. -->

<br>

### Feeling.:pencil:
Unity 엔진에 대해서 많은 것을 알 수 있게 돼서, 굉장히 재미있고 유익한 시간이었습니다. 더군다나 팀원들이 너무나 훌륭하게 각자의 파트를 소화해준 탓에, 우수상을 받게 되어 개인적으로 가장 기억에 남는 교내 팀 활동이었습니다.
<br>
<br>

### Documents.:book:
[프로젝트 관련문서](https://github.com/tlagmltjq11/Capston_Documents)
<br>
<br>

### Pictures.:camera:
로그인 화면
![login](https://user-images.githubusercontent.com/43705434/103642019-ea9fe180-4f95-11eb-8d92-2b825e6a80d0.png)
<br>

홈 화면
![home](https://user-images.githubusercontent.com/43705434/103642017-e96eb480-4f95-11eb-9a14-c69547f0bd75.png)
<br>

가구 리스트 화면
![list](https://user-images.githubusercontent.com/43705434/103642018-ea9fe180-4f95-11eb-9e13-f5356d695b27.png)
<br>

장바구니 화면
![cart](https://user-images.githubusercontent.com/43705434/103642021-eb387800-4f95-11eb-9f77-2fcbe7b6b97c.png)
<br>

바닥재 선택 화면
![floorSelect](https://user-images.githubusercontent.com/43705434/103642027-ebd10e80-4f95-11eb-9d71-223860f800a9.png)
<br>

인테리어 완성 화면
![complete](https://user-images.githubusercontent.com/43705434/103642024-eb387800-4f95-11eb-965a-15da2b31d984.png)
