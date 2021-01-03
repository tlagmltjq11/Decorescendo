package com.capstone.project.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.capstone.project.dao.UserDAO;
import com.capstone.project.logic.Members;

@Service
public class UserServiceImpl implements UserService {

	@Autowired
	UserDAO userDAO;

	@Override
	public Members getUserOne(String common,String col) {
		return userDAO.getUserOne(common,col);
	}

	@Override
	public int userJoin(Members members) {
		return userDAO.userJoin(members);
	}


	@Override
	public int setFurn(String ID, String route) {
		return userDAO.setFurn(ID, route);
	}

	@Override
	public Members getFurn(String ID) {
		return userDAO.getFurn(ID);
	}
}
