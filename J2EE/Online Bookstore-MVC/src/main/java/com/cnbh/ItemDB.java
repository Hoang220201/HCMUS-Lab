package com.cnbh;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Properties;

public class ItemDB implements ItemService {
	private Map<String, Item> items;
	
	public ItemDB() {
		this.items = new HashMap<>();

		// Step 1: Load the Driver
		try {
			Class.forName("com.mysql.jdbc.Driver");
		} catch (ClassNotFoundException cnfe) {
			System.out.println("Error loading driver: " + cnfe);
		}
		
		// Step 2: Define the Connection URL
		String mySqlUrl = "jdbc:mysql://localhost:3306/onlinebook";
				
		// Step 3: Establish the Connection
		Properties userInfo = new Properties();
		userInfo.put("user", "root");
		userInfo.put("password", "220201");
		Connection connection = null;
		ResultSet resultSet = null;
		try {
			connection = DriverManager.getConnection(mySqlUrl, userInfo);
			

			// Step 4: Make a Statement
			Statement statement = connection.createStatement();
			
			// Step 5: Execute a Query
			String query = "SELECT id, title, author, description, price FROM books";
			resultSet = statement.executeQuery(query);
			
			// Step 6: Process the Result
			while(resultSet.next()) {
				String id = resultSet.getString("id");
				String title = resultSet.getString("title");
				String author = resultSet.getString("author");
				String description = resultSet.getString("description");
				double price = resultSet.getDouble("price");
				this.items.put(id, new Item(id, title, author, description, price, 0));
			}
			
			// Step 7: Close the Connection
			connection.close();
		} catch (SQLException e) {
			e.printStackTrace();
		}		
				
	}
	
	
	@Override
	public List<Item> firstBuy(String id){
		for (Item i : itemList) {
			if(i.getId().equals(id)) {
				i.setNumber(i.getNumber()+1);
				return itemList;
			}
		}
		for (Item i : items.values()){
			if(i.getId().equals(id)) {
				i.setNumber(i.getNumber()+1);
				itemList.add(i);
				break;
			}
				
		}
		return itemList;
	}
	
	
	public List<Item> updateItem(String id, String number) {
		for (Item i : itemList) {
			if(i.getId().equals(id)) {
				int n = Integer.parseInt(number);
				if(n == 0) {
					itemList.remove(i);
					break;
				}
				else {
					i.setNumber(n);
				}
			}
		}
		return itemList;
	}
		
}
	