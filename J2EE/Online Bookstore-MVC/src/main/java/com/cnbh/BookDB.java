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


public class BookDB  implements BookLookupService {
	private Map<String, Book> books;
	
	public BookDB() {
		this.books = new HashMap<>();

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
				this.books.put(id, new Book(id, title, author, description, price));
			}
			
			// Step 7: Close the Connection
			connection.close();
		} catch (SQLException e) {
			e.printStackTrace();
		}		
				
	}
	
	@Override
	public List<Book> getAllBooks() {
		return new ArrayList<Book>(this.books.values());
	}

}
