package com.capstone.project.service;


import com.capstone.project.logic.Members;

public interface UserService {

	Members getUserOne(String common, String col);

	int userJoin(Members members);

	
	int setFurn(String ID, String route);
	
	Members getFurn(String ID);

}