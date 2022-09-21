package com.cnbh;

import java.util.List;


public class BookMap implements BookLookupService {

	@Override
	public List<Book> getAllBooks() {
		BookDao dao = new BookDaoDbImpl();
		List<Book> book = dao.getAllBooks();
		
		return book;
	}

}
