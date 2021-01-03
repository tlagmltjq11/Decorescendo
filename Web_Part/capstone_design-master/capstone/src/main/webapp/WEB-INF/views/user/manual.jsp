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
				id.innerHTML = "<h2>Create wall</h2><hr>�� ���� �����ϴ� ��ư�Դϴ�.<br>2D ȭ���� ���� �ǿ��� ���콺 ���� ��ư�� �̿��Ͽ� ���� ���� �� �� �ֽ��ϴ�.<br> ȭ���� ������ �Ʒ��� ���� ���� ���� ���� ���̰� m ������ ǥ�� �˴ϴ�.<br> ���� ������ ������ ��������� �ڵ����� ������ �������� ���� �ݴϴ�.<br> ���ϴ� ��ŭ ���� ���� �Ͽ����� ���콺 ������ ��ư���� �� ������ �Ϸ� �� �� �ֽ��ϴ�.<br>";
				break;
			case 2:
				id.innerHTML = "<h2>Remove wall</h2><hr>�� �ϳ��� ����� ��ư�Դϴ�.<br> ���� �ֱٿ� ������ ������ ���� ���� ������ ������ ������� �����˴ϴ�.<br>";
				break;
			case 3:
				id.innerHTML = "<h2>Remove all walls</h2><hr>�� ��ü�� ����� ��ư�Դϴ�.<br> ���� �����Ǿ� �ִ� ��� ���� �����մϴ�.<br>";
				break;
			case 4:
				id.innerHTML = "<h2>Remove furniture</h2><hr>���� �ϳ��� ����� ��ư�Դϴ�.<br>���콺 ������ Ŭ���̳� f + ���콺 ���� Ŭ������ �����ϰ��� �ϴ� ������ �����ϸ� ȭ�鿡 ��ư�� Ȱ��ȭ �˴ϴ�.<br>Ȱ��ȭ �� ��ư�� Ŭ���ϸ� ���õ� ������ �����մϴ�.<br>";
				break;
			case 5:
				id.innerHTML = "<h2>Remove all furnitures</h2><hr>���� ��ü�� ����� ��ư�Դϴ�.<br> ���� ȭ�鿡 �߰� �Ǿ� �ִ� ��� ������ �����մϴ�.<br>";
				break;
			case 6:
				id.innerHTML = "<h2>3D view</h2><hr>������ �Ϸ�� ���� 3D ȭ������ �� �� �ִ� ��ư�Դϴ�.<br>���콺 ���� �巡�׷� ȭ���� �̵��� �� �ְ� ������ �巡�׷� ȭ���� ������ ������ �� �ֽ��ϴ�.<br>���� �ùٸ��� ������ �Ǿ��ִٸ� ���� ��ǥ�� �������� ���� �ٴ��� �������ݴϴ�.<br>������ ���� �ٴ��� Ű������ t�� ���� ���·� ���콺 ������ Ŭ���� �ϸ� ������ �ٴ��縦 ������ �� �ִ� â�� Ȱ��ȭ �˴ϴ�.�����ϰ��� �ϴ� ���� �Ǵ� �ٴ��縦 Ŭ���ϸ� ���õ� ���� �ٴ��� ����� ���մϴ�.<br>";
				break;
			case 7:
				id.innerHTML = "<h2>Eye level</h2><hr>����� �����̷� ������ �����ϴ� ��ư�Դϴ�.<br>w�� s�� �̵��� �� �ְ� a�� d�� ȭ���� �¿츦, ���콺�� ȭ���� ���ϸ� ������ �� �ֽ��ϴ�.<br>��� ������ ���� �ٸ� ����� �Ұ��ϸ� ������ �̵��� �����մϴ�.<br>Ű������ escŰ�� �̿��Ͽ� ��� ���� ȭ���� ���� ���� �� �ֽ��ϴ�.<br>";
				break;
			case 8:
				id.innerHTML = "<h2>Save</h2><hr>�� ������ �����ϴ� ��ư�Դϴ�.<br> �α����� ���� ������ �����մϴ�.<br> ȸ���� ���� ȭ�鿡 ������ ���� �ڽ��� ������ ���� ��ų �� �ֽ��ϴ�.<br>";
				break;
			case 9:
				id.innerHTML = "<h2>Load</h2><hr>�� ������ �ҷ����� ��ư�Դϴ�.<br>�α����� ���� ������ �����մϴ�.<br>ȸ���� �ڽ��� ���� ������ �� ������ ����� �ִٸ� ����� �� ������ �ҷ��ɴϴ�.<br>���� ���� ���̴� �� ������ ���� �������ϴ�.<br>";
				break;
			case 10:
				id.innerHTML = "<h2>Move</h2><hr>ȭ�鿡 �߰��� ������ f + ���콺 ���� Ŭ���� �ϸ� ���� ���� �̵��� �� �ִ� UI�� ������ �巡�׸� ���� ������ �̵��� �� �ֽ��ϴ�.<br>������ ���콺 ������ Ŭ���� �ϸ� ���� ���� ȸ���� �� �ִ� UI�� ������ �巡�׸� ���� ������ ȸ���� �� �ֽ��ϴ�.<br>���� ȭ�� ���� �Ʒ��� ���� ���� �Է��ϴ� �ʵ尡 ������ ���ϴ� ������ �Է� �� ���͸� ������ ������ ȸ���մϴ�.<br>";
				break;
			}
		}
	</script>
</body>

</html>