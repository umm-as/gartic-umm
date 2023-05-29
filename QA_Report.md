# Gartic Umm QA Report

- **`QA 구분`**

  개발 QA에 관한 부분만 작성하였습니다.

  퍼블리싱, 성능, 보안 측면의 QA는 진행하지 않았다는 점 말씀 드립니다.

</br>
  
- **`역할 분담에 대하여`**

  **# 역할분담 계획**
  
  | 담장자 | 구현 기능 |
  |---|---|
  | 이\*재 (이하 `wjlee611`) | (총괄 개발 관리) 이미지 직렬화, 디버깅 및 QA |
  | 정\*준 (이하 `hoijun`) | 레이아웃 디자인, 기능 구현 |
  | 김\*석 (이하 `dsundert`) | 레이아웃 디자인, 기능 구현 |
  | 문\*현 (이하 `moonjh000`) | 게임 시작/종료/재시작 구현 |
  
  - 소켓 통신 파트는 분할하여 작업
  
  </br>
  
  **# 역할분담 변경**
  
  기존에는 대략적인 역할만 지정하여서 계획서를 제출하였습니다.
  
  하지만, 실제 개발을 진행함에 따라 위에서 언급된 개발 파트가 순차적으로 진행되어야만 하는 부분이 존재하였습니다.
  
  뿐만 아니라, 기여도의 차이가 크게 벌어지는 문제가 예상되었습니다.
  
  또한, 협업을 효과적으로 체험해보기 위해서는 의도적으로 Conflict를 발생시키고, 브랜치를 분기하고, 서로 코드를 리뷰하는 것이 학습 취지와도 맞다고 판단되었습니다.
  
  </br>
  
  따라서 실제로 분담된 역할은 계획대로가 아닌, 최대한 모두의 기여도가 공평하도록 분배하였습니다.
  
  분배는 총괄 개발자 `wjlee611`이 분배 일시의 기여도를 판단하여 계획 및 포지션을 분배하였고,
  
  분배 일시는 각 개발 프로세스가 시작되는 단계에서 분배하였습니다.
  
  자세한 역할분담은 아래의 `개발 프로세스별 QA`의 프로세스마다 작성되어 있습니다.
  
  _역할분담이 모호하며 적절히 분배되지 않은 계획을 제출한 점은 사과드립니다._

</br>
</br>


## 개발 프로세스별 QA

### # 레이아웃 UI 디자인 

- `기획 개발일정` 4/13 ~ 4/19

- `실제 개발일정` 4/13 ~ 5/4 (https://github.com/umm-as/gartic-umm/pull/1 ~ https://github.com/umm-as/gartic-umm/pull/7)

</br>

**# 역할 분담**

| 담장자 | 구현 기능 |
|---|---|
| wjlee611 | 프로젝트 초기화, Metro UI 적용, 레이아웃 구상, 아이콘 제작 |
| hoijun | 그림판 도구 레이아웃 제작 |
| dsundert | 채팅창 레이아웃 제작 |
| moonjh000 | 그림판 레이아웃 제작 |

</br>

**# `Goal` 직관적인 UI 디자인**

좀 더 깔끔한 디자인을 위해 MetroUI를 사용.

<img width="424" alt="스크린샷 2023-05-29 16 12 18" src="https://github.com/umm-as/gartic-umm/assets/66172061/d3a533a6-0146-48c3-a921-d58c0dd28918">

`Form1`은 서버(방장)와 클라이언트(플레이어)를 선택하여 구동할 수 있도록 표시함과 동시에 게임 타이틀 소개.

<img width="870" alt="스크린샷 2023-05-29 16 13 27" src="https://github.com/umm-as/gartic-umm/assets/66172061/81c821c8-50cb-48de-966f-83c2f1cab823">

`Form2`는 게임이 진행되는 화면으로 그림판과, 도구, 채팅창 및 현재 게임 상태를 표시하는 라벨로 구성.
 
</br>

**# `QA Review`**

실제 개발 일정보다 상당히 지연되었습니다. 그 이유로는 중간고사 시험이 사이에 예정되었었기 때문입니다.

하지만, 레이아웃을 제작하면서 이후에 진행될 `디자인에 대한 기능 구현`파트의 일부를 미리 땡겨와서 개발할 필요가 있었습니다.

그렇기에, 개발 일정의 변동이 있을 뿐, 실제 개발에는 영향이 없었습니다.

아래는 리뷰하며 발견된 문제점입니다.
 
- **전체화면 전환시 채팅창 부분이 왼쪽으로 쏠리는 현상 수정 필요**

</br>

---

</br>


### # 디자인에 대한 기능 구현 (1)

- `기획 개발일정` 4/20 ~ 4/26

- `실제 개발일정` 5/4 ~ 5/8 (https://github.com/umm-as/gartic-umm/pull/7 ~ https://github.com/umm-as/gartic-umm/pull/13)

</br>

**# 역할 분담**

| 담장자 | 구현 기능 |
|---|---|
| wjlee611 | 직선 저장용 클래스 구현, 이미지 직렬화, 역직렬화 메서드 구현 |
| hoijun | 펜 색깔 및 굵기 바꾸는 기능 구현 |
| dsundert | 게임 시간의 제한을 둘 Timer 구현 |
| moonjh000 | 그림판에 그림을 그리는 기능 구현 |

</br>

**# `Goal` Form2의 모달창 띄우기 및 그림판의 원활한 동작**

<img width="446" alt="스크린샷 2023-05-29 16 19 26" src="https://github.com/umm-as/gartic-umm/assets/66172061/e40729ca-7d19-45d3-9ae8-06b7b700d9b1">

선 굵기, 색깔, 지우개 기능 구현 완료.

</br>

**# `QA Review`**

그림판에 그림을 그리기 위해서는 선을 저장할 클래스의 구현이 필수였습니다.

그 이유는 `이미지 직렬화(인코딩/디코딩) 처리` 에서의 `❗️제한사항`에서 언급된 바와 같습니다.

따라서 `이미지 직렬화(인코딩/디코딩) 처리`에서 구현해야 할 내용일 미리 땡겨와서 클래스 구현할 때 같이 개발하였습니다.

아래는 리뷰하며 발견된 문제점입니다.

- **마우스의 움직이는 속도가 빠르면 선들이 끊기는 현상 수정 필요**

  _`수정 완료` 5/9@https://github.com/umm-as/gartic-umm/pull/14_

- **채팅창 기능 구현 필요**

  _`수정 완료` 5/22@https://github.com/umm-as/gartic-umm/pull/22_

</br>

---

</br>


### # 디자인에 대한 기능 구현 (2)

- `기획 개발일정` 4/27 ~ 5/3

- `실제 개발일정` 5/9 ~ 5/11 (https://github.com/umm-as/gartic-umm/pull/14, https://github.com/umm-as/gartic-umm/pull/16)

</br>

**# 역할 분담**

| 담장자 | 구현 기능 |
|---|---|
| wjlee611 | 선 끊김 현상 수정 |
| moonjh000 | 창이 움직이면 그림이 지워지는 현상 수정 |

</br>

**# `Goal` 기존에 발생한 여러 문제점 수정**

<p>
  <img width="49%" alt="스크린샷 2023-05-29 16 19 37" src="https://github.com/umm-as/gartic-umm/assets/66172061/49402735-cc21-4ab6-a096-9429141c66f9">
  <img width="49%" alt="스크린샷 2023-05-29 17 37 56" src="https://github.com/umm-as/gartic-umm/assets/66172061/26f57e86-54e0-4fd4-a988-5882e505f181">
</p>

점들로는 속도를 따라잡기 충분치 않다고 판단, 따라서 점이 아닌 박스로 선을 구현했습니다.

하지만, 선 역시 끊겨보이는 현상 발생했습니다. 따라서 점, 선을 적절히 사용하여 선을 구현했습니다.

</br>

**# `QA Review`**

파트 1에서 거의 모든 기능이 구현되었기에 파트 2에서는 짧게 버그만 수정하였습니다.

코드 리뷰하는 과정에서 창을 움직일 때 그림이 모두 지워지는 문제가 발견되었습니다.

하지만, 이 문제는 앞서 개발한 선을 관리하는 클래스를 이용하여 간단하게 해결할 수 있었습니다.

아래는 리뷰하며 발견된 문제점입니다.
  
- **창을 이동하거나 전체화면 전환할 경우 그림판의 그림이 모두 지워지는 현상 수정 필요**

  _`수정 완료` 5/11@https://github.com/umm-as/gartic-umm/pull/16_
  
</br>

---

</br>


### # 이미지 직렬화(인코딩/디코딩) 처리

- `기획 개발일정` 5/4 ~ 5/10

- `실제 개발일정` 5/6 (https://github.com/umm-as/gartic-umm/pull/10)

</br>

**# `Goal` 그림판 이미지를 전송, 불러오기 위해 이미지 직렬화, 역직렬화 구현**

**`❗️제한사항` 핵심 기능인 만큼 라이브러리가 아닌 자체구현 할 것**

직렬화, 역직렬화를 위해서는 그 이미지를 처리하는 형식을 먼저 지정해야 함.

따라서, 이미지를 관리하는 방식을 별도의 클래스로 정의하고, 이 클래스에서 직렬화, 역직렬화 기능을 제공하는 메서드로 구현.

_`구현 완료` 5/6@https://github.com/umm-as/gartic-umm/pull/10_

_(`디자인에 대한 기능 구현 (1)`에서 미리 구현했습니다)_

</br>

---

</br>


### # 소켓 통신 테스트

- `기획 개발일정` 5/11 ~ 5/17

- `실제 개발일정` 5/18 ~ 5/23 (https://github.com/umm-as/gartic-umm/pull/17 ~ https://github.com/umm-as/gartic-umm/pull/25)

</br>

**# 역할 분담**

| 담장자 | 구현 기능 |
|---|---|
| wjlee611 | TCP 소켓 통신 모듈 개발 |
| dsundert | 제시어 입력 모달 구현, 플레이어 입장/퇴장 메세지 구현 |
| moonjh000 | 채팅창 구현 |

</br>

**# `Goal` 소켓 통신을 이용해서 문자열 데이터를 주고 받을 수 있는지 테스트**

이 부분은 코드를 상당부분 변경이 일어날 것을 대비하여 `tcp-test` 브랜치에서 개발하였습니다.

하지만, 제시어 입력 모달과 같은 디자인 파트는 여전히 `master` 브랜치에서 개발하였습니다.

소켓 통신 모듈이 Form2에서 개발시 코드의 길이가 너무 길어지고, 디자인과 비즈니스 영역의 구분이 사라지는 문제점이 예상되었습니다.

따라서, 소켓 통신 모듈 부분은 별도의 클래스로 만들어 `모듈화` 하기로 결정했습니다.

동시에, 각 통신 모듈은 `스레드에서 동작`하고, 이벤트 핸들러를 부착하여 Form2에 `이벤트를 발생` 시키는 형식으로 개발을 진행하였습니다.

소켓 모듈이 개발이 되고 나서야, 채팅창의 개발이 가능했기에, 채팅창 개발 일정이 여기까지 밀라고 이제야 개발되었습니다.

또한, 제시어를 채팅창으로 입력받을 생각이었는데, 플레이어의 실수로 제시어가 노출될 경우를 고려햐여 제시어를 모달을 통해 입력받기로 결정, 개발하였습니다.

</br>

**# `QA Review`**

개발 후 예외가 발생하지 않는 상황에서는 문자열이 잘 전송됨을 확인할 수 있었습니다.

다만, 아래의 예외 상황을 상정하고 테스트시 여러 비정상적인 상황이 발생함이 확인되었습니다.

아래는 리뷰하며 발견된 문제점입니다.

- **서버(방장), 클라이언트가 입장하는 상황을 구분지을 수 있도록 수정 필요**

  _`수정 완료` 5/18@https://github.com/umm-as/gartic-umm/pull/20_

- **Form2를 종료시에도 서버, 클라이언트 TCP 스레드가 정상적으로 종료되지 않는 문제 수정 필요**

  _`수정 완료` 5/18@https://github.com/umm-as/gartic-umm/pull/20_
  
- **클라이언트가 접속 중일 때 서버가 종료되는 경우 프로그램이 먹통이 되는 문제 수정 필요**

  _`수정 완료` 5/23@https://github.com/umm-as/gartic-umm/pull/25_
  
- **서버가 실행 중일 때 또 서버를 실행하는 경우 접속이 되는 문제 수정 필요**

  _`수정 완료` 5/23@https://github.com/umm-as/gartic-umm/pull/25_
  
- **서버가 열리지도 않았는데 클라이언트가 접속되는 문제 수정 필요**

  _`수정 완료` 5/23@https://github.com/umm-as/gartic-umm/pull/25_

</br>

---

</br>


### # 제시어, 인코딩 이미지 소켓 통신 (1)

- `기획 개발일정` 5/18 ~ 5/24

- `실제 개발일정` 5/23, 5/24 (https://github.com/umm-as/gartic-umm/pull/26 ~ https://github.com/umm-as/gartic-umm/pull/32)

</br>

**# 역할 분담**

| 담장자 | 구현 기능 |
|---|---|
| wjlee611 | 서버, 클라이언트 스레드 관련 에러 수정, 브랜치 통합 |
| hoijun | 이벤트 코드 추가, 채팅 전송 개발 |
| dsundert | Timer 모듈화, 버그 수정 |
| moonjh000 | 플레이어 관리용 Queue 개발, 메세지/그림 전송 테스트 |

</br>

**# `Goal` 발견된 TCP 소켓 버그 수정 및 데이터 전송 테스트**

앞서 발견되었던 5가지의 소켓 버그를 수정하였습니다.

따라서 소켓 모듈의 개발이 일단락 되었다고 판단하여 `tcp-test` 브랜치를 `master` 브랜치로 통합하였습니다.

이후 Timer 코드를 리팩토링하여 코드를 깔끔하게 정리하였습니다.

또한, 채팅/그림/이벤트를 구분하기 위해 `code`를 정의하였고, 이를 이용해서 데이터를 전송하는데 성공하였습니다.

</br>

**# `QA Review`**

개발 일정을 상당부분 따라잡았고, 원하는 기능이 안정적으로 동작함을 확인했습니다.

대부분의 기능을 리팩토링하여 모듈화를 진행하였고, 그 결과 추후 개발에 있어 간단하게 메서드만 호출하면 되도록 구현되었습니다.

뿐만 아니라 그 효과로 디자인 영역과 비즈니스 영역이 구분되어 코드의 가독성, 디버깅의 편의성이 증대되었습니다.

</br>

---

</br>



### # 제시어, 인토딩 이미지 소켓 통신 (2), 게임 종료 및 재시작 구현 (1) `5/25` ~ `5/31`

</br>

---

</br>


### # 제시어, 인토딩 이미지 소켓 통신 (2), 디버깅 및 QA `6/1` ~ `6/7`

</br>

---

</br>


### # 프로젝트 마무리 `6/8` ~ `6/14`