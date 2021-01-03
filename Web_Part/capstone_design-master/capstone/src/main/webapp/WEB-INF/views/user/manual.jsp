<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

<style>
#manual { position:relative; width: 100%; height:100%;}
#manual #explain_list {  position:fixed;width: 13%; height:100%;float:left;}
#manual #explain_list > ul li { list-style:none; margin:0; padding:0;}
#manual #explain_list > ul.list {padding:0px 0px; height:610px;}
#manual #explain_list > ul.list > li {height:67.1px; margin-left:3px;}
#manual #explain_detail { position:relative; width: 85%; height:100%; float : right; overflow-x:hidden;  }
#manual #blank {  position:relative;width: 2%; height:100%;float:left;}
</style>

<title>Manual</title>
</head>
<body>
	<div id = "manual">
		<div id = "explain_list" style = " border-right:2px solid; margin-right:5px;">
			<ul class = "list">
				<li id = "1" onclick = "detail(1)"><img src="/resources/wallcreate.png" style  = "width:60px; height:62px; vertical-align:middle"></li>
				<li id = "2" onclick = "detail(2)"><img src="/resources/removewall.png" style  = "width:60px; height:62px; vertical-align:middle"></li>
				<li id = "3" onclick = "detail(3)"><img src="/resources/removeallwall.png" style  = "width:60px; height:62px; vertical-align:middle"></li>
				<li id = "4" onclick = "detail(4)"><img src="/resources/removefurn.png" style  = "width:60px; height:62px; vertical-align:middle"></li>
				<li id = "5" onclick = "detail(5)"><img src="/resources/removeallfurn.png" style  = "width:60px; height:62px; vertical-align:middle"></li>
				<li id = "6" onclick = "detail(6)"><img src="/resources/3dview.png" style  = "width:60px; height:62px; vertical-align:middle"></li>
				<li id = "7" onclick = "detail(7)"><img src="/resources/eyelevel.png" style  = "width:60px; height:62px; vertical-align:middle"></li>
				<li id = "8" onclick = "detail(8)"><img src="/resources/save.png" style  = "width:60px; height:62px; vertical-align:middle"></li>
				<li id = "9" onclick = "detail(9)"><img src="/resources/load.png" style  = "width:60px; height:62px; vertical-align:middle"></li>
				<li id = "10" onclick = "detail(10)"><img src="/resources/move.png" style  = "width:48px; height:48px; vertical-align:middle; margin-left:5px"></li>
			</ul>
		</div>
		<div id="blank">
		</div>
		<div id = "explain_detail" style = "font-size:1.5em;  ">

		</div>
	</div>
	<script type="text/javascript">
		function detail(e) {
			var id = document.getElementById('explain_detail');
			switch(e){
			case 1:
				id.innerHTML = "<h2>Create wall</h2><hr>집 벽을 구성하는 버튼입니다.<br>2D 화면의 격자 판에서 마우스 왼쪽 버튼을 이용하여 벽을 연결 할 수 있습니다.<br> 화면의 오른쪽 아래에 현재 생성 중인 벽의 길이가 m 단위로 표시 됩니다.<br> 벽의 각도가 수직에 가까워지면 자동으로 각도를 수직으로 맞춰 줍니다.<br> 원하는 만큼 벽을 생성 하였으면 마우스 오른쪽 버튼으로 벽 구성을 완료 할 수 있습니다.<br>";
				break;
			case 2:
				id.innerHTML = "<h2>Remove wall</h2><hr>벽 하나를 지우는 버튼입니다.<br> 가장 최근에 생성한 벽부터 가장 먼저 생성한 벽까지 순서대로 삭제됩니다.<br>";
				break;
			case 3:
				id.innerHTML = "<h2>Remove all walls</h2><hr>벽 전체를 지우는 버튼입니다.<br> 현재 생성되어 있는 모든 벽을 삭제합니다.<br>";
				break;
			case 4:
				id.innerHTML = "<h2>Remove furniture</h2><hr>가구 하나를 지우는 버튼입니다.<br>마우스 오른쪽 클릭이나 f + 마우스 왼쪽 클릭으로 삭제하고자 하는 가구를 선택하면 화면에 버튼이 활성화 됩니다.<br>활성화 된 버튼을 클릭하면 선택된 가구를 삭제합니다.<br>";
				break;
			case 5:
				id.innerHTML = "<h2>Remove all furnitures</h2><hr>가구 전체를 지우는 버튼입니다.<br> 현재 화면에 추가 되어 있는 모든 가구를 삭제합니다.<br>";
				break;
			case 6:
				id.innerHTML = "<h2>3D view</h2><hr>구성이 완료된 집을 3D 화면으로 볼 수 있는 버튼입니다.<br>마우스 왼쪽 드래그로 화면을 이동할 수 있고 오른쪽 드래그로 화면의 각도를 변경할 수 있습니다.<br>벽이 올바르게 구성이 되어있다면 벽의 좌표를 바탕으로 집의 바닥을 구성해줍니다.<br>구성된 벽과 바닥을 키보드의 t를 누른 상태로 마우스 오른쪽 클릭을 하면 벽지와 바닥재를 선택할 수 있는 창이 활성화 됩니다.변경하고자 하는 벽지 또는 바닥재를 클릭하면 선택된 벽과 바닥의 모습이 변합니다.<br>";
				break;
			case 7:
				id.innerHTML = "<h2>Eye level</h2><hr>사람의 눈높이로 시점을 변경하는 버튼입니다.<br>w와 s로 이동할 수 있고 a와 d로 화면의 좌우를, 마우스로 화면의 상하를 조정할 수 있습니다.<br>사람 시점일 때는 다른 기능이 불가하며 시점의 이동만 가능합니다.<br>키보드의 esc키를 이용하여 사람 시점 화면을 빠져 나올 수 있습니다.<br>";
				break;
			case 8:
				id.innerHTML = "<h2>Save</h2><hr>방 정보를 저장하는 버튼입니다.<br> 로그인을 했을 때에만 가능합니다.<br> 회원은 현재 화면에 구성한 집을 자신의 계정에 저장 시킬 수 있습니다.<br>";
				break;
			case 9:
				id.innerHTML = "<h2>Load</h2><hr>방 정보를 불러오는 버튼입니다.<br>로그인을 했을 때에만 가능합니다.<br>회원은 자신의 계정 정보에 방 정보가 담아져 있다면 저장된 방 정보를 불러옵니다.<br>현재 진행 중이던 집 구성은 전부 지워집니다.<br>";
				break;
			case 10:
				id.innerHTML = "<h2>Move</h2><hr>화면에 추가한 가구를 f + 마우스 왼쪽 클릭을 하면 가구 위에 이동할 수 있는 UI가 나오며 드래그를 통해 가구를 이동할 수 있습니다.<br>가구를 마우스 오른쪽 클릭을 하면 가구 위에 회전할 수 있는 UI가 나오며 드래그를 통해 가구를 회전할 수 있습니다.<br>또한 화면 왼쪽 아래에 각도 값을 입력하는 필드가 나오며 원하는 각도를 입력 후 엔터를 누르면 가구가 회전합니다.<br>";
				break;
			}
		}
	</script>
</body>

</html>