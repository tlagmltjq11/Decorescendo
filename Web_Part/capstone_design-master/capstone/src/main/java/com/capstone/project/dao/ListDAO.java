package com.capstone.project.dao;
import java.util.HashMap;
import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.capstone.project.logic.Lists;

@Repository
public class ListDAO {

	@Autowired
	public SqlSession sqlSession;
	
	public List<Lists> getListOne(String type, String brand,  String color, String price) {
		HashMap<String, Object> map = new HashMap<String, Object>();
		map.put("type",type);
		map.put("brand",brand);
		map.put("color",color);
		if(price.equals("Price")) {
			map.put("price", price);
		} else {
			String[] temp = price.split("~");
			map.put("price", temp[0]);
			if(temp.length == 1) map.put("maxPrice", "max");
			else map.put("maxPrice", temp[1]);
		}
		return sqlSession.selectList("getListOne",map);
	}

	
	public int insertFurn(Lists lists) {
		return sqlSession.insert("insertFurn",lists);
	}
	
}
