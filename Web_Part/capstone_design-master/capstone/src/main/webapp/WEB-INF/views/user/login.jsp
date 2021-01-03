<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js" integrity="sha384-aJ21OjlMXNL5UyIl/XNwTMqvzeRMZH2w8c5cRVpzpU8Y5bApTppSuUkhZXN0VxHd" crossorigin="anonymous"></script>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">

<style>
body {
   font: 13px/20px 'Helvetica Neue', Helvetica, Arial, sans-serif;
   color: #333333;
   background: #ededed;
}

.signUp {
   position: relative;
   margin: 50px auto;
   width: 320px;
   padding: 33px 25px 29px;
   background: #FFFFFF;
   border-bottom: 1px solid #C4C4C4;
   border-radius: 5px;
   -webkit-box-shadow: 0 1px 5px rgba(0, 0, 0, 0.25);
   box-shadow: 0 1px 5px rgba(0, 0, 0, 0.25);
}

.signUp:before,
.signUp:after {
   content: '';
   position: absolute;
   bottom: 1px;
   left: 0;
   right: 0;
   height: 10px;
   background: inherit;
   border-bottom: 1px solid #D2D2D2;
   border-radius: 4px;
}

.signUp:after {
   bottom: 3px;
   border-color: #DCDCDC;
}

.signUpTitle {
   margin: -25px -25px 25px;
   padding: 15px 25px;
   line-height: 35px;
   font-size: 26px;
   font-weight: 300;
   color: #777;
   text-align: center;
   text-shadow: 0 1px rgba(255, 255, 255, 0.75);
   background: #F7F7F7;
}

.signUpTitle:before {
   content: '';
   position: absolute;
   top: 0;
   left: 0;
   right: 0;
   height: 8px;
   background: #C4E17F;
   border-radius: 5px 5px 0 0;
   background-image: -webkit-linear-gradient(left, #C4E17F, #C4E17F 12.5%, #F7FDCA 12.5%, #F7FDCA 25%, #FECF71 25%, #FECF71 37.5%, #F0776C 37.5%, #F0776C 50%, #DB9DBE 50%, #db9CBE 62.5%, #C49CDE 62.5%, #C49CDE 75%, #669AE1 75%, #669AE1 87.5%, #62C2E4 87.5%, #62C2E4);
   background-image: -moz-linear-gradient(left, #c4e17f, #C4E17F 12.5%, #F7FDCA 12.5%, #F7FDCA 25%, #FECF71 25%, #FECF71 37.5%, #F0776C 37.5%, #F0776C 50%, #DB9DBE 50%, #DB9CBE 62.5%, #C49CDE 62.5%, #C49CDE 75%, #669AE1 75%, #669AE1 87.5%, #62C2E4 87.5%, #62C2E4);
   background-image: -o-linear-gradient(left, #C4E17F, #C4E17F 12.5%, #F7FDCC 12.5%, #F7FDCA 25%, #FECF71 25%, #FECF71 37.5%, #F0776C 37.5%, #F0776C 50%, #DB9DBE 50%, #DB9DBE 62.5%, #C49CDE 62.5%, #C49CDE 75%, #669AE1 75%, #669AE1 87.5%, #62C2E4 87.5%, #62C2E4);
   background-image: linear-gradient(to right, #C4E17F, #C4E17F 12.5%, #F7FDCA 12.5%, #F7FDCA 25%, #FECF71 25%, #FECF71 37.5%, #F0776C 37.5%, #F0776C 50%, #DB9DBE 50%, #DB9CBE 62.5%, #c49cde 62.5%, #C49CDE 75%, #669AE1 75%, #669AE1 87.5%, #62c2e4 87.5%, #62C2E4);
}


.modal-dialog {
   position: relative;
   width: 430px;
   margin: 40px auto;
}


input {
   font-family: inherit;
   color: inherit;
   -webkit-box-sizing: border-box;
   -moz-box-sizing: border-box;
   box-sizing: border-box;
}

.loginInput {
   width: 100%;
   height: 50px;
   margin-bottom: 25px;
   padding: 0 15px 2px;
   font-size: 17px;
   background: white;
   border: 2px solid #EBEBEB;
   border-radius: 4px;
   -webkit-box-shadow: inset 0 -2px #EBEBEB;
   box-shadow: inset 0 -2px #EBEBEB;
}

.signUpInput {
   width: 100%;
   height: 30px;
   margin-bottom: 5px;
   padding: 0 15px 2px;
   font-size: 17px;
   background: white;
   border: 2px solid #EBEBEB;
   border-radius: 4px;
   -webkit-box-shadow: inset 0 -2px #EBEBEB;
   box-shadow: inset 0 -2px #EBEBEB;
}

.emailInput {
   width: 44%;
   height: 30px;
   margin-bottom: 25px;
   padding: 0 15px 2px;
   font-size: 17px;
   background: white;
   border: 2px solid #EBEBEB;
   border-radius: 4px;
   -webkit-box-shadow: inset 0 -2px #EBEBEB;
   box-shadow: inset 0 -2px #EBEBEB;
}

.signUpInput:focus {
   border-color: #62C2E4;
   outline: none;
   -webkit-box-shadow: inset 0 -2px #62C2E4;
   box-shadow: inset 0 -2px #62C2E4;
}

.lt-ie9 .signUpInput {
   line-height: 48px;
}

.loginButton {
   position: relative;
   vertical-align: top;
   width: 100%;
   height: 54px;
   padding: 0;
   font-size: 22px;
   color: white;
   text-align: center;
   text-shadow: 0 1px 2px rgba(0, 0, 0, 0.25);
   background: #CCCCFF;
   border: 0;
   border-bottom: 2px solid #D76B60;
   border-radius: 5px;
   cursor: pointer;
   -webkit-box-shadow: inset 0 -2px #D76B60;
   box-shadow: inset 0 -2px #D76B60;
}

.loginButton:active {
   top: 1px;
   outline: none;
   -webkit-box-shadow: none;
   box-shadow: none;
}

.signUpButton {
   position: relative;
   vertical-align: top;
   width: 100%;
   height: 54px;
   padding: 0;
   font-size: 18px;
   color: white;
   text-align: center;
   text-shadow: 0 1px 2px rgba(0, 0, 0, 0.25);
   background: #F0776C;
   border: 0;
   border-bottom: 2px solid #D76B60;
   border-radius: 5px;
   cursor: pointer;
   -webkit-box-shadow: inset 0 -2px #D76B60;
   box-shadow: inset 0 -2px #D76B60;
}

.signUpButton:active {
   top: 1px;
   outline: none;
   -webkit-box-shadow: none;
   box-shadow: none;
}

:-moz-placeholder {
   color: #AAAAAA;
   font-weight: 300;
}

::-moz-placeholder {
   color: #AAAAAA;
   opacity: 1;
   font-weight: 300;
}

::-webkit-input-placeholder {
   color: #AAAAAA;
   font-weight: 300;
}

:-ms-input-placeholder {
   color: #AAAAAA;
   font-weight: 300;
}

::-moz-focus-inner {
   border: 0;
   padding: 0;
}
</style>
</head>
<body>

<form class="signUp" id="signinForm">
   <h1 class="signUpTitle">로그인</h1>
   <input type="text" id="userId" class="loginInput" placeholder="ID" autofocus onkeyup="enterKeyCheck()">
   <input type="password" id="password" class="loginInput" placeholder="Password" onkeyup="enterKeyCheck()">
   <input type="button" value="로그인" onclick="loginValidation()" class="loginButton">
   <input type="button" value="회원가입" onclick="signUpModalPop()" class="signUpButton">
</form>

<div class="modal fade" id="signUpModal" role="dialog"  tabindex="-1" aria-labelledby="modal-login-label" aria-hidden="true">
      <div class="modal-dialog">
         <!-- Modal content-->
         <div class="modal-content">
            <!--  <div class="modal-header" style="padding: 30px 30px;">                
            </div> -->
            <form class="form-horizontal" method="POST" id="Frm" name="Frm"> 
               <div class="modal-body" style="padding: 30px 40px; height: 480px;">
                  <form class="signUp" id="signupForm">
                     <h1 class="signUpTitle">회원가입</h1>
                     
                     <div class="fieldlabel"><label for="userId">*아이디</label></div>
                       <div class="formfield"><input type="text" id="signup_userId" class="signUpInput" name="userId" maxlength="20" value=""></div>
                       
                       <div class="fieldlabel"><label for="password">*패스워드</label></div>
                       <div class="formfield">
                        <input type="password" id="signup_password" class="signUpInput" name="password" maxlength="20" autocomplete="off">
                     </div>
               
                       <div class="fieldlabel"><label for="passwordCheck">패스워드확인</label></div>
                       <div class="formfield">
                        <input type="password" id="signup_passwordCheck" class="signUpInput" name="passwordCheck" maxlength="20" autocomplete="off">
                     </div>
                      
                       <div class="fieldlabel"><label for="email">*이메일</label></div>
                       <div class="formfield"><input type="text" id="signup_email" class="emailInput" name="email" size="20" maxlength="20" 
                            value="" autocomplete="off"><span>@</span>
                           <input id="domain" list="domains" name="domain" placeholder="도메인입력/선택">
                           <datalist id="domains">
                               <option value="naver.com">
                               <option value="daum.net">
                               <option value="gmail.com">
                               <option value="yahoo.co.kr">
                           </datalist>
                       </div>
                     <input type="button" value="가입" onclick="signUpValidation()" class="signUpButton">
                  </form>
               </div>
            <div class="modal-footer">
            </div>
            </form>
         </div>
      </div>
</div>
<script type="text/javascript">

function loginValidation(){
   
   var vuserId = $("#userId").val();
   var vpassword = $("#password").val();
   
   if(!vuserId){
      alert("아이디를 입력하세요.");
      $("#userId").focus();
      return false;
   }else if(!vpassword){
      alert("비밀번호를 입력하세요.");
      $("#password").focus();
      return false;
   }else {
      login(vuserId,vpassword);
   }
   
}

function login(userid,userpw){

   $.ajax({
      url : "/jquery/login.do",
      type : 'POST',
      data : { userId : userid, 
            password : userpw   
      },
      success:function(data){
         if(data == 2){
            alert("아이디 혹은 비밀번호가 맞지 않습니다.");
            return false;
         }else if(data == 3){
        	 
            location.href="/";
         }
      },
      error:function(e){
            alert(e.responseText); 
      },
      complete : function(data) {
           //alert("complete : " + data);
       }
      
   })
   
}

function signUpValidation(){
	   
	   var userId = $("#signup_userId").val();
	   var userPw = $("#signup_password").val();
	   var userPwCheck = $("#signup_passwordCheck").val();
	   var email = $("#signup_email").val() + '@' + $("#domain").val();
	   var domain = $("#domain").val();
	   
	   if(!userId){
	      alert("아이디 입력은 필수입니다.");
	      $("#signup_userId").focus();
	   }else if(!userPw){
	      alert("비밀번호 입력은 필수입니다.");
	      $("#signup_password").focus();
	   }else if(!userPwCheck){
	      alert("비밀번호 확인 입력은 필수입니다.");
	      $("#signup_passwordCheck").focus();
	   }else if(userPw != userPwCheck){
	      alert("비밀번호가 맞지 않습니다.");
	      $("#signup_userPwCheck").focus();      
	   }else if(!email){
	      alert("이메일 입력은 필수입니다.");
	      $("#signup_email").focus();
	   } else if(!domain){
	      alert("이메일 도메인을 선택해주세요.");
	      $("#domain").focus();
	   }else {
	      signUp(userId, userPw, email);
	   }
	   
	}


function signUp(id, pw, email){
   $.ajax({
      url : "/user/jquery/signUp.do",
      type:'POST',
      data :  { userId : id, userPw : pw, email : email},
      success:function(data){
         if(data==1){
            alert("회원가입이 완료됐습니다.");
            $('#signUpModal').modal('hide');
         }else if(data==2){
            alert("이미 존재하는 아이디입니다.");
            return false;
         } 
      },
      error:function(e){
          alert(e.responseText);     
      }      
   })
}

function enterKeyCheck(){
   
 if(event.keyCode == 13)
     {
    loginValidation();
     }
   
   
}

function signUpModalPop(){
   $('#signUpModal').modal('show');
}



</script>
</body>
</html>