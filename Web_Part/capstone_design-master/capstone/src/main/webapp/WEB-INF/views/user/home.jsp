<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="true"%>
<html>
<head>
<title>Capston</title>
<script
	src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script
	src="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"
	integrity="sha384-aJ21OjlMXNL5UyIl/XNwTMqvzeRMZH2w8c5cRVpzpU8Y5bApTppSuUkhZXN0VxHd"
	crossorigin="anonymous"></script>
<link rel="stylesheet"
	href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"
	integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu"
	crossorigin="anonymous">

<link rel="stylesheet"
	href="<c:url value="https://fonts.googleapis.com/css2?family=Jua&display=swap" />">
<link rel="stylesheet" href="<c:url value="/resources/style.css" />">
<script src="<c:url value="/resources/UnityLoader.js" />"></script>
<script src="https://kit.fontawesome.com/c176709a0d.js"
	crossorigin="anonymous"></script>

<script>
	var unityInstance = UnityLoader.instantiate("unityContainer",
			"/resources/Decorescendo.json");
</script>
</head>
<body>
	<div id="wrap">
		<div id="header">
			<div id="logo">
				<img src="<c:url value="/resources/caplogo.jpg"/>" width="20%"
					height="100%">
				<button style="display: none; visibility: hidden" id="node">
				</button>
				<button style="display: none; visibility: hidden" id="nodel">
				</button>
			</div>
			<c:choose>
				<c:when test="${empty sessionScope.loginUser }">
					<div id="signin">
						<a class="fas fa-user-circle" id="signInButton"
							onclick="location.href='/user/login'"
							style="margin-left: 50px; margin-top: 5px; font-size: 30px">
							<span aria-hidden=true></span>
						</a>
					</div>
				</c:when>
				<c:otherwise>
					<c:choose>
						<c:when test="${sessionScope.loginUser.id  eq 'admin'}">
							<div id="signout">
								<div id="logout">
									<a type="button" class="far fa-user-circle" id="signOutButton"
										data-toggle="modal" data-target="#adminInfoModal"
										style="margin-left: 50px; margin-top: 5px; font-size: 30px">
										<span aria-hidden=true></span>
									</a>
								</div>

							</div>
							<div class="modal fade" id="adminInfoModal" role="dialog"
								tabindex="-1" aria-labelledby="modal-login-label"
								aria-hidden="true">
								<div class="modal-dialog modal-custom" role="document">
									<!-- Modal content-->
									<div class="modal-content">
										<div class="modal-body"
											style="padding: 5px 10px; height: 80px;">
											<div class="fieldlabel">
												<label for="userId">${sessionScope.loginUser.id}</label>
											</div>
											<div class="fieldlabel">
												<label for="email">${sessionScope.loginUser.email}</label>
											</div>
											<input type="button" id="crawling" value="crawling"
												onclick="logoutCall2()">
										</div>
										<div class="modal-footer">
											<input type="button" id="logoutButton" value="로그아웃"
												onclick="logoutCall()">
										</div>

									</div>
								</div>
							</div>
						</c:when>
						<c:otherwise>
							<div id="signout">
								<div id="logout">
									<a class="far fa-user-circle" id="userInfoButton"
										onclick="userModalPop()"
										style="margin-left: 50px; margin-top: 5px; font-size: 30px">
										<span aria-hidden=true></span>
									</a>
								</div>
							</div>

							<div class="modal fade" id="userInfoModal" role="dialog"
								tabindex="-1" aria-labelledby="modal-login-label"
								aria-hidden="true">
								<div class="modal-dialog modal-custom" role="document">
									<!-- Modal content-->
									<div class="modal-content">
										<!--  <div class="modal-header" style="padding: 30px 30px;"> 					
									</div> -->
										<div class="modal-body"
											style="padding: 5px 10px; height: 80px;">
											<div class="fieldlabel">
												<label for="userId">${sessionScope.loginUser.id}</label>
											</div>
											<div class="fieldlabel">
												<label for="email">${sessionScope.loginUser.email}</label>
											</div>
										</div>
										<div class="modal-footer">
											<input type="button" id="logoutButton" value="로그아웃"
												onclick="logoutCall()">
										</div>

									</div>
								</div>
							</div>
						</c:otherwise>
					</c:choose>

				</c:otherwise>
			</c:choose>
			<div id="manual">
				<a type="label" class="fas fa-question-circle" id="question"
					onclick="questionCall()"
					style="margin-left: 10px; margin-top: 5px; font-size: 30px"> </a>
			</div>
		</div>

		<div id=content>
			<div id="left">
				<i class="fas fa-couch" aria-hidden="true"
					style="position: relative; margin-left: 20px; margin-top: 270px; font-size: 3em; color: #482b19; width: 45px; float: left">

				</i>
				<div id="list">
					<div id="kategorie">
						<div id="find">
							<ul class="Menu">
								<li id="type" class="mainMenu">Type
									<ul class="subMenu">
										<li id="Type" onclick="findType(this)">Type</li>
										<li id="bed" onclick="findType(this)">bed</li>
										<li id="cabinet" onclick="findType(this)">cabinet</li>
										<li id="chair" onclick="findType(this)">chair</li>
										<li id="closet" onclick="findType(this)">closet</li>
										<li id="drawer" onclick="findType(this)">drawer</li>
										<li id="shelf" onclick="findType(this)">shelf</li>
										<li id="sofa" onclick="findType(this)">sofa</li>
										<li id="table" onclick="findType(this)">table</li>
									</ul>
								</li>

								<li id="brand" class="brandMenu">Brand
									<ul class="subMenu">
										<li id="Brand" onclick="findBrand(this)">Brand</li>
										<li id="IKEA" onclick="findBrand(this)">IKEA</li>
										<li id="LIVART" onclick="findBrand(this)">LIVART</li>
										<li id="ILOOM" onclick="findBrand(this)">ILOOM</li>
									</ul>
								</li>

								<li id="color" class="colorMenu">Color
									<ul class="subMenu">
										<li id="Color" onclick="findColor(this)">Color</li>
										<li id="black" onclick="findColor(this)">black</li>
										<li id="blue" onclick="findColor(this)">blue</li>
										<li id="brown" onclick="findColor(this)">brown</li>
										<li id="gray" onclick="findColor(this)">gray</li>
										<li id="green" onclick="findColor(this)">green</li>
										<li id="pink" onclick="findColor(this)">pink</li>
										<li id="red" onclick="findColor(this)">red</li>
										<li id="white" onclick="findColor(this)">white</li>
									</ul>
								</li>

								<li id="price" class="price">Price
									<ul class="priceMenu">
										<li id="Price" onclick="findPrice(this)">Price</li>
										<li id="가격1" onclick="findPrice(this)">0~200000</li>
										<li id="가격2" onclick="findPrice(this)">200001~400000</li>
										<li id="가격3" onclick="findPrice(this)">400001~600000</li>
										<li id="가격4" onclick="findPrice(this)">600001~800000</li>
										<li id="가격5" onclick="findPrice(this)">800001~1000000</li>
										<li id="가격5" onclick="findPrice(this)">1000001~</li>
									</ul>
								</li>
							</ul>
						</div>

						<div id="search">
							<a type="button" class="fas fa-search" onclick="showList()"
								style="font-size: 20px;"> </a>
						</div>

					</div>

					<div id="listview"></div>
					<div id="page"></div>

				</div>
			</div>

			<div id="unityContainer"
				style="width: 91%; height: 100%; position: absolute; transform: translate(5%, 0); z-index: 1;">
			</div>

			<div id="right">
				<i class="fas fa-cart-arrow-down" aria-hidden="true"
					style="position: relative; margin-right: 23px; margin-top: 270px; font-size: 3em; color: #482b19; width: 45px; float: right;">
				</i>
				<div id="basket">
					<div id="totalprice"></div>
					<div id="basketview" sytle="position:relative"></div>



				</div>
			</div>
		</div>

		<div id="footer">
			<div id="footer_inner" class="clfix">
				<div class="foot_info">
					E-MAIL. Decrescendo@naver.com<br /> Copyright team Crescendo. all
					right reserved.
				</div>
			</div>
		</div>
	</div>

	<script type="text/javascript">
		
	
		function userModalPop(){
			$('#userInfoModal').modal('show');
		}
		
		function questionCall(){
		    var url = "/user/manual";
		    var name = "manual";
		    var option = "resizable = 0, width = 500, height = 650, top = 50, left = 200";
			window.open(url, name, option);
		}
	
    	function clicked(){
        	unityInstance.SendMessage("UIEvent",'CreateButtonClick');
     	}
		
		function findType(e) {
			type = document.getElementById('type');
			type.innerHTML = "<li id = 'type' class = 'mainMenu' style = 'list-style:none'>"
					+ e.innerText
					+ "<ul class = 'subMenu'><li id='Type' onclick='findType(this)'>Type</li><li id='bed' onclick='findType(this)'>bed</li><li id='cabinet' onclick='findType(this)'>cabinet</li><li id='chair' onclick='findType(this)'>chair</li><li id='closet' onclick='findType(this)'>closet</li><li id='drawer' onclick='findType(this)'>drawer</li><li id='shelf' onclick='findType(this)'>shelf</li><li id='sofa' onclick='findType(this)'>sofa</li><li id='table' onclick='findType(this)'>table</li></ul></li>"
		}
		
		function findBrand(e){
			brand = document.getElementById('brand');
			brand.innerHTML = "<li id = 'brand' class = 'brandMenu' style = 'list-style:none'>"
					+ e.innerText
					+"<ul class='subMenu'><li id='Brand' onclick='findBrand(this)'>Brand</li><li id='IKEA' onclick='findBrand(this)'>IKEA</li>	<li id='LIVART' onclick='findBrand(this)'>LIVART</li>	<li id='ILOOM' onclick='findBrand(this)'>ILOOM</li></ul></li>"
		}
		
		function findColor(e){
			color = document.getElementById('color');
			color.innerHTML = "<li id = 'color'  class = 'colorMenu' style = 'list-style:none'>"
					+ e.innerText
					+ "<ul class='subMenu'><li id='Color' onclick='findColor(this)'>Color</li>	<li id='black' onclick='findColor(this)'>black</li><li id='blue' onclick='findColor(this)'>blue</li><li id='brown' onclick='findColor(this)'>brown</li><li id='gray' onclick='findColor(this)'>gray</li><li id='green' onclick='findColor(this)'>green</li>	<li id='pink' onclick='findColor(this)'>pink</li><li id='red' onclick='findColor(this)'>red</li>	<li id='white' onclick='findColor(this)'>white</li></ul></li>"
		}
		
		function findPrice(e){
			 price = document.getElementById('price');
		     price.innerHTML = "<li id = 'price'  class = 'price' style = 'list-style:none'>"
					+ e.innerText
			        + "<ul class='priceMenu'><li id='Price' onclick='findPrice(this)'>Price</li><li id='가격1' onclick='findPrice(this)'>0~200000</li><li id='가격2' onclick='findPrice(this)'>200001~400000</li><li id='가격3' onclick='findPrice(this)'>400001~600000</li><li id='가격4' onclick='findPrice(this)'>600001~800000</li><li id='가격5' onclick='findPrice(this)'>800001~1000000</li><li id='가격5' onclick='findPrice(this)'>1000001~</li></ul></li>";
			}
		
		
	      function listContainerCreate(page){
	            var tc = new Array();
	            var temp = new Array();
	           
	            var html = '';
	            var pagehtml ='';
	            var totalpage;
	            if(local.length%10==0){
	               totalpage = parseInt(local.length/10);
	            } else {
	               totalpage = parseInt(local.length/10)+1;
	            }
	            var start = (page-1)*10;
	            var end = page*10-1;
	            
	            for(;start<=end;start++){
	              if(start==local.length) break;
	               tc.push({num : local[start].num, name : local[start].name, brand : local[start].brand, type : local[start].type, price : local[start].price, image : local[start].image, detail : local[start].detail, modeling : local[start].modeling }); 
	            }

	            if(tc.length == 0){
					html = '<p style="font-size:20px;font-family:Jua, sans-serif; margin-top:250px; text-align:center;">일치하는 가구가 없습니다.</p>';
					$("#listview").empty();
					$("#listview").append(html);	
				}else{
	               for(key in tc){
	                   var price = tc[key].price.toString();
	                   html += '<table border = "1" width="100%" height="30%">';
	                   html += '<tr>';
	                   html += '<td rowspan="4" width="20%"  style = "text-align:center"><img src="' + tc[key].image + '" height="140"/></td>';
	                   html += '<td colspan="3" height ="30%" style="font-size:25px; font-family:Jua, sans-serif;">' + tc[key].name + '</td>';
	                   html += '</tr>';
	                   html += '<tr>';
	                   html += '<td colspan="3"height ="20%" style="font-size:15px; font-family:Jua, sans-serif;">' + tc[key].brand + '</td>';
	                   html += '</tr>';
	                   html += '<tr>';
	                   html += '<td colspan = "3"height ="30%" style = "font-size:20px; font-family:Jua, sans-serif;">' +price.replace(/\B(?=(\d{3})+(?!\d))/g, ",") + '원</td>';
	                   html += '</tr>';
	                   html += '<tr>';
	                   html += "<td width='20%'height ='20%'><button class = 'btn' onclick = 'insertbasket("+tc[key].num+")' style='width:100%; height:100%;align:center; background-color:#ededed; border:white 0px; outline:0; font-family:Jua, sans-serif;'>장바구니</button></td>";
	                   html += '<td width="20%"height ="20%"><button class = "btn" onclick="add(\'' + tc[key].num + '\',\'' + tc[key].modeling + '\')" style=" width:100%; height:100%; align:center background-color:#ededed; border:white 0px; outline:0;font-family:Jua, sans-serif; ">가구 추가</button></td>';
	                  html += '<td width="20%"height ="20%"><button class = "btn" onclick = "window.open(\'' + tc[key].detail + '\')" target="_blank" style=" width:100%; height:100%; align:center background-color:#ededed; border:white 0px; outline:0;font-family:Jua, sans-serif; ">구매 링크</button></td>';
	                  html += '</tr>';
	                  html += '</table>';   
	               }
	               $("#listview").empty();
	               $("#listview").append(html);   
	               $('.btn').on({
	                   mouseenter: function(){$(this).css('background-color','#dedede');},
	                   mouseleave: function(){$(this).css('background-color','#ededed');}
	               });
	            }
	            
	            if(tc.length == 0){
	                  $("#page").empty();
	           } else{
	              var ps;
	              if(page%10==0){
	                 ps = page-9;
	              } else {
	                 ps = parseInt(page/10)*10+1;
	              }
	              var pe = ps+9;
	              
	              if(ps!=1) pagehtml += '<a onclick="paging('+1+','+ps+')">'+'&nbsp;\<&nbsp;'+'</a>';
	              for(;ps<=pe;ps++){
	                 if(ps>totalpage) break;
	                 pagehtml += '<a onclick="listContainerCreate('+ps+')">&nbsp;'+ps+'&nbsp;</a>';
	              }
	              if(pe<totalpage) pagehtml += '<a onclick="paging('+2+','+pe+')">'+'&nbsp;\>&nbsp;'+'</a>';
	              
	              $("#page").empty();
	               $("#page").append(pagehtml); 
	           }
	       }
	      function paging(check,startend){
	          var ps;
	          var pe;
	          var pagehtml = '';
	          var totalpage;
	             if(local.length%10==0){
	                totalpage = parseInt(local.length/10);
	             } else {
	                totalpage = parseInt(local.length/10)+1;
	             }
	          if(check==1){
	             ps = startend - 10;
	             pe = ps+9;
	          } else {
	             ps = startend + 1;
	             pe = ps+9;
	          }
	            if(ps!=1) pagehtml += '<a onclick="paging('+1+','+ps+')">'+'&nbsp;\<&nbsp;'+'</a>';
	            for(;ps<=pe;ps++){
	               if(ps>totalpage) break;
	               pagehtml += '<a onclick="listContainerCreate('+ps+')">&nbsp;'+ps+'&nbsp;</a>';
	            }
	            if(pe<totalpage) pagehtml += '<a onclick="paging('+2+','+pe+')">'+'&nbsp;\>&nbsp;'+'</a>';
	            $("#page").empty();
	             $("#page").append(pagehtml);
	       }
		function basketContainerCreate(list){
			var checkId = "${sessionScope.loginUser.id}";
			var tc = new Array();
			var html = '';
			var totalprice = 0;
			for(var i = 0 in list){   
				tc.push({id : list[i].id, num : list[i].num, name : list[i].name, brand : list[i].brand, price : list[i].price, image : list[i].image, detail : list[i].detail, count : list[i].count}); 
				totalprice += list[i].price * list[i].count;
			}
			if(tc.length == 0){
				$("#totalprice").empty().append("<label style = 'float:right; font-size:25px; margin-right:30px;'>총 금액 :   "+totalprice+" 원</label>");
				$("#basketview").empty();
			}else{
	        	for(key in tc){
	                var price = tc[key].price.toString();
	                html += '<table border = "1" width="100%" height="30%">';
	                html += '<tr>';
	                html += '<td rowspan="4" width="20%" style = "text-align:center"><img src="' + tc[key].image + '" height="150"/></td>';
	                html += '<td colspan="3"height ="30%" style="font-size:25px; font-family:Jua, sans-serif;">' + tc[key].name + '</td>';
	                html += '</tr>';
	                html += '<tr>';
	                html += '<td colspan="3"height ="20%" style="font-size:15px; font-family:Jua, sans-serif;">' + tc[key].brand + '</td>';
	                html += '</tr>';
	                html += '<tr>';
	                html += '<td colspan = "3"height ="30%" style="font-size:20px; font-family:Jua, sans-serif;">' +price.replace(/\B(?=(\d{3})+(?!\d))/g, ",") + '원</td>';
	                html += '</tr>';
	                html += '<tr>';
	                html += "<td width='20%' height ='20%'><button onclick = 'count("+tc[key].num+","+tc[key].count+",1)' style = 'height:100%; float:left; font-family:Jua, sans-serif;'>-</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label style='font-size:15px; font-family:Jua, sans-serif; margin-top:6px;'>"+tc[key].count+"</label><button onclick = 'count("+tc[key].num+","+tc[key].count+",2)' style = 'height:100%; float:right; font-family:Jua, sans-serif;'>+</button></td>";
	                html += "<td width='20%' height ='20%'><button class = 'btn' onclick = 'deletebasket("+tc[key].num+")' style='width:100%; height:100%;align:center; background-color:#ededed; border:white 0px; outline:0; font-size:15px; font-family:Jua, sans-serif;'>장바구니 삭제</button></td>";
	                html += '<td width="20%" height ="20%"><button class = "btn" onclick ="window.open(\'' + tc[key].detail + '\')" style="width:100%; height:100%;align:center; background-color:#ededed; border:white 0px; outline:0;font-size:15px; font-family:Jua, sans-serif;">구매 링크</button></td>';   
	                html += '</tr>';
	            	html += '</table>';
	            }
				$("#basketview").empty().append(html);
				
				$("#totalprice").empty().append("<label style = 'float:right; font-size:25px; margin-right:30px; font-family:Jua, sans-serif;'>총 금액 :   "+totalprice.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "원</label>");
				$('.btn').on({
				    mouseenter: function(){$(this).css('background-color','#dedede');},
				    mouseleave: function(	){$(this).css('background-color','#ededed');}
				});
			}		
		}
	
		var local = new Array();
		
		function showList(){
	         $.ajax({
	            url : "/jquery/list.do",
	            type : 'POST',
	            data : {type : type.innerText, brand : brand.innerText, color : color.innerText, price : price.innerText},
	            success : function(check){
	               local = check.valueOf();
	               listContainerCreate(1);
	            }
	         })
	      }
		
		
		function logoutCall() {
			$.ajax({
				url : "/jquery/logout.do",
				type : 'POST',
				success : function(data) {
					if (data == 1) {
						location.href = "/user/home";
					} else {
						return false;
					}
				}
			})
		}

		 function logoutCall2(){
			 $.ajax({
					url : "jquery/logout2.do",
					type:'POST',
					success:function(data){
						if(data==1){
							location.href="/";
						}else {
							alert("에러");
							return false;
						}
					},
					error:function(e){
						 alert(e.responseText);	       },
				     complete : function(data) {
				        //alert("complete : " + data);
				     }
					
				})
		 }
		
		window.onload = reloadbasket();
		window.onload = showList();
		
		function reloadbasket(){
			var reloadbasket = "${sessionScope.loginUser.id}";
			if(reloadbasket != ""){
				$.ajax({
					url : "/jquery/basket.do",
					type : 'POST',
					data : {reloadID : reloadbasket},
					success : function(check){
						basketContainerCreate(check);
					}
				})
			}else{
				var html = '<p style="font-size:20px;font-family:Jua, sans-serif; margin-top:250px; text-align:center;">로그인 하세요.</p>';
				$("#basketview").empty().append(html);
			}
		}
		
		function insertbasket(furnNum){
			var insertbasket = "${sessionScope.loginUser.id}";
			if(insertbasket != ""){
				$.ajax({
					url : "/jquery/insert.do",
					type : 'POST',
					data : {insertID : insertbasket, insertFurn : furnNum},
					success : function(check){
						if(check == 0) alert("이미 추가되어 있는 가구");
						else {
							alert("장바구니 담기")
							reloadbasket();
						}
					}
				})
			}else{
			}
		}
		
		function deletebasket(furnNum){
			var deletebasket = "${sessionScope.loginUser.id}";
			if( deletebasket != ""){
				$.ajax({
					url : "/jquery/delete.do",
					type : 'POST',
					data : {deleteID : deletebasket, deleteFurn : furnNum},
					success : function(check){
						if(check == 1) {
							reloadbasket();
						}
					}
				})
			}else{
			}
		}		
		
		function count(num, count, type){
			var changebasket = "${sessionScope.loginUser.id}";
			var check;
			if(type ==1){
				if(count == 1){
					deletebasket(num);
				}else{
					check = count - 1;
				}
			}else{
				check = count +1;
			}
			$.ajax({
				url : "/jquery/count.do",
				type : 'POST',
				data : {changeID : changebasket, changeNum: num, count : check},
				success : function(check){
					if(check == 1) {
						reloadbasket();
					}
				}
			})
		}
		
		
		
		
		function add(addinfo, model){
	         if(model == "O"){
	            unityInstance.SendMessage('JsonManager','addfurniture',addinfo);
	         }
	         else {
	            alert("모델링이 안되어 있습니다.");
	         }
	      }

	      function saveweb(arg){ 
	         
	         var save = "${sessionScope.loginUser.id}";
	         if(save != ""){
	            $.ajax({
	                url : "/jquery/save.do",
	                type : 'POST',
	                data : {ID : save, route : arg},
	                success : function(check){
	                   if(check == 1) {
	                      alert("저장 완료");
	                      }else{
	                      alert("저장 실패");
	                   }   
	                }
	            })
	         }else{
	            alert("로그인하세요");
	         }
	      }

	      function loadunity(){
	         
	         var load = "${sessionScope.loginUser.id}";
	         var temp = "no";
	         if(load != ""){
	            $.ajax({
	               url : "/jquery/load.do",
	               type : 'POST',
	               data : {ID : load},
	               success : function(check){
	                  unityInstance.SendMessage('JsonManager','FromWebString',check); // room 정보
	               }
	            })
	         }else{
	            alert("로그인하세요");
	            unityInstance.SendMessage('JsonManager','FromWebString',temp);
	         }

	      }

	</script>

</body>
</html>
