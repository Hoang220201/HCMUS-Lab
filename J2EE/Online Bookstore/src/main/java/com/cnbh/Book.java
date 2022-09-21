package com.cnbh;

public class Book {
	private String id;
	private String title;
	private String author;
	private String description;
	private double price;
	
	public Book(String id, String title, String author, String description, double price) {
		this.id = id;
		this.title = title;
		this.author = author;
		this.description = description;
		this.price = price;
	}
	
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public String getAuthor() {
		return author;
	}
	public void setAuthor(String author) {
		this.author = author;
	}
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public double getPrice() {
		return price;
	}
	public void setPrice(double price) {
		this.price = price;
	}
}
