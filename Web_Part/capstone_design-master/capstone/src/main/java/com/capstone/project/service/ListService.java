package com.capstone.project.service;

import java.util.List;

import com.capstone.project.logic.Lists;

public interface ListService {

	List<Lists> getListOne(String type, String brand, String color, String price);
	int insertFurn(Lists lists);
}