package com.capstone.project.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import com.capstone.project.logic.Lists;
import com.capstone.project.service.ListService;

@Controller
public class ListController {
	
	@Autowired
	ListService listService;

	@RequestMapping(value="/jquery/list.do",method = RequestMethod.POST)
	public @ResponseBody List<Lists> list(HttpSession session, HttpServletRequest httpServletRequest) {
		List<Lists> listCheck = listService.getListOne(httpServletRequest.getParameter("type"),
													   httpServletRequest.getParameter("brand"),
													   httpServletRequest.getParameter("color"),
													   httpServletRequest.getParameter("price"));
		
		
		return listCheck;
	}
}