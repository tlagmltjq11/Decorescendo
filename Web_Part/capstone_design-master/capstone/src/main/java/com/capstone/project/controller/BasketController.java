package com.capstone.project.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import com.capstone.project.logic.Baskets;
import com.capstone.project.service.BasketService;

@Controller
public class BasketController {
	
	@Autowired
	BasketService basketService;

	@RequestMapping(value="/jquery/insert.do",method = RequestMethod.POST)
	public @ResponseBody int insertBasket(HttpSession session, HttpServletRequest httpServletRequest) {
		int insertCheck = 0;
		try{
			insertCheck = basketService.insertBasket(httpServletRequest.getParameter("insertID"),httpServletRequest.getParameter("insertFurn"));
		}catch(Exception e) {
			insertCheck = 0;
		}
		return insertCheck;
	}
	

	@RequestMapping(value="/jquery/delete.do",method = RequestMethod.POST)
	public @ResponseBody int deleteBasket(HttpSession session, HttpServletRequest httpServletRequest) {
		int deleteCheck = basketService.deleteBasket(httpServletRequest.getParameter("deleteID"),httpServletRequest.getParameter("deleteFurn"));
		return deleteCheck;
	}
	
	
	@RequestMapping(value="/jquery/basket.do",method = RequestMethod.POST)
	public @ResponseBody List<Baskets> basket(HttpSession session, HttpServletRequest httpServletRequest) {
		List<Baskets> basketCheck = basketService.getBasketList(httpServletRequest.getParameter("reloadID"));
		return basketCheck;
	}
	

	@RequestMapping(value="/jquery/count.do",method = RequestMethod.POST)
	public @ResponseBody int countBasket(HttpSession session, HttpServletRequest httpServletRequest) {
		int countCheck = basketService.countBasket(httpServletRequest.getParameter("changeID"),httpServletRequest.getParameter("changeNum"),httpServletRequest.getParameter("count"));
		return countCheck;
	}
}