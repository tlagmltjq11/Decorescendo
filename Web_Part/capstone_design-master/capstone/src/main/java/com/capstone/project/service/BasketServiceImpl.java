package com.capstone.project.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.capstone.project.dao.BasketDAO;
import com.capstone.project.logic.Baskets;

@Service
public class BasketServiceImpl implements BasketService{
   
   @Autowired
   BasketDAO basketDAO;
   
   @Override
   public int insertBasket(String ID, String num) {
      return basketDAO.insertBasket(ID, num);
   }
   
   @Override
   public int deleteBasket(String ID, String num) {
      return basketDAO.deleteBasket(ID, num);
   }

   @Override
   public List<Baskets> getBasketList(String reloadID){
	   return basketDAO.getBasketList(reloadID);
   }
   
   @Override
   public int countBasket(String countID, String num, String count) {
	   return basketDAO.countBasket(countID, num, count);
   }
   
   
}