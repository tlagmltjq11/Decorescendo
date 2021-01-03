package com.capstone.project.dao;
import java.util.HashMap;

import org.apache.ibatis.session.SqlSession;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.capstone.project.logic.Members;

@Repository
public class UserDAO {

	@Autowired
	public SqlSession sqlSession;

	public Members getUserOne(String common, String col) {
		HashMap<String, Object> map = new HashMap<String, Object>();
		if(col.equals("userId")) {
			map.put("userId",common);
		}
		return sqlSession.selectOne("getUserOne",map);
	}

	public int userJoin(Members members) {
		return sqlSession.insert("userJoin",members);
	}

	
	
	
	public int setFurn(String ID, String route) {
		HashMap<String, Object> map = new HashMap<String, Object>();
		map.put("ID", ID);
		map.put("route", route);
		return sqlSession.update("setFurn", map);
	}

	public Members getFurn(String ID) {
		HashMap<String, Object> map = new HashMap<String, Object>();
		map.put("ID", ID);
		return sqlSession.selectOne("getFurn", map);
	}
}
