package com.capstone.project.dao;
import java.util.HashMap;
import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.capstone.project.logic.Baskets;


@Repository
public class BasketDAO {

	@Autowired
	public SqlSession sqlSession;
	
	public int insertBasket(String insertID, String num) {
		HashMap<String, Object> map = new HashMap<String, Object>();
		map.put("insertID",insertID);
		map.put("num",num);
		map.put("count","1");
		return sqlSession.insert("insertBasket",map);
	}

	public int deleteBasket(String deleteID, String num) {
		HashMap<String, Object> map = new HashMap<String, Object>();
		map.put("deleteID",deleteID);
		map.put("num",num);
		return sqlSession.delete("deleteBasket", map);
	}

	public List<Baskets> getBasketList(String reloadID) {
		HashMap<String,Object> map = new HashMap<String,Object>();
		map.put("reloadID",reloadID);
		return sqlSession.selectList("getBasketList",map);
	}

	public int countBasket(String countID, String num, String count) {
		HashMap<String,Object> map = new HashMap<String,Object>();
		map.put("countID", countID);
		map.put("num", num);	
		map.put("count", count);	
		return sqlSession.update("countBasket", map);
	}
	
}
