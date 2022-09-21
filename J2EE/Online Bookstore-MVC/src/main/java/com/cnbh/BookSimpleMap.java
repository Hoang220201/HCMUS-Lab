package com.cnbh;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class BookSimpleMap implements BookLookupService {

	private Map<String, Book> books;
	
	public BookSimpleMap() {
		this.books = new HashMap<>();
		this.books.put("1", new Book("1", "Fast learing Java", "Hoang", "Basic java coding for newbie", 9.99));
		this.books.put("2", new Book("2", "The C++ Programming Language", "Hoang", "Basic C++ coding for PRO!!", 10.90));
		this.books.put("3", new Book("3", "The Art of Computer Programming", "Donald Knuth", "Just some basic coding for Bill Gates", 8.42));
		this.books.put("4", new Book("4", "The Harry Potter Series", "J.K.Rowling", "Its faking Harry Potter mate!!", 60.90));
		this.books.put("5", new Book("5", "The Subtle Art of Not Giving a F*ck", "Mark Manson", "Lets be honest, shit is f**ked and we have to live with it.", 13.76));
	}

	@Override
	public List<Book> getAllBooks() {
		return new ArrayList<Book>(this.books.values());
	}
}
