package com.cnbh;

import java.io.IOException;
import java.util.Collection;
import java.util.List;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;


/**
 * Servlet implementation class BookPage
 */
@WebServlet("/BookPage")
public class BookPage extends HttpServlet {
	private static final long serialVersionUID = 1L;
	
	
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
   
		String bookId = request.getParameter("bookId");
		//BookLookupService service = new BookSimpleMap();    
		//BookLookupService service = new BookDB();           //DB
		BookLookupService service = new BookMap();            //DAO
		String address = null;
		
   
		String itemId = request.getParameter("itemId");
		String number = request.getParameter("number");
		//ItemService service2 = new ItemSimpleMap();
		ItemService service2 = new ItemDB();
	
		
		
		if (bookId == null && itemId == null) {
			List<Book> books = service.getAllBooks();
			request.setAttribute("books", books);
			address = "WEB-INF/default.jsp";
		} else if(bookId != null && itemId == null)
		{
			List<Item> items = service2.firstBuy(bookId);  
			request.setAttribute("items", items);
			address = "WEB-INF/cart.jsp";
			
		}else if(number != null && itemId != null) {
			List<Item> items = service2.updateItem(itemId, number); 
			request.setAttribute("items", items);
			address = "WEB-INF/cart.jsp";
		}
		 
		
		RequestDispatcher dispatcher = request.getRequestDispatcher(address);
		dispatcher.forward(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
