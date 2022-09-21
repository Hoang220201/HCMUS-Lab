package com.cnbh;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;


/**
 * Servlet implementation class BookPage
 */
@WebServlet("/BookPage")
public class BookPage extends HttpServlet {
	private static final long serialVersionUID = 1L;
	
	//Tao du lieu book
	private List<Book> bookList = new ArrayList<>();
	public BookPage() {
		Book Java = new Book("hoang001", "Fast learing Java", "Hoang", "Basic java coding for newbie", 9.99);
		Book CPP = new Book("hoang002", "The C++ Programming Language", "Hoang", "Basic C++ coding for PRO!!", 10.90);
		Book CPP2 = new Book("knuth001", "The Art of Computer Programming", "Donald Knuth", "Just some basic coding for Bill Gates", 8.42);
		Book HPS = new Book("rowling001", "The Harry Potter Series", "J.K.Rowling", "Its faking Harry Potter mate!!", 60.90);
		Book DGF = new Book("manson001", "The Subtle Art of Not Giving a F*ck", "Mark Manson", "Lets be honest, shit is f**ked and we have to live with it.", 13.76);
		bookList.add(Java);
		bookList.add(CPP);
		bookList.add(CPP2);
		bookList.add(HPS);
		bookList.add(DGF);
	
	}
	
    
	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpSefastrvletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		PrintWriter out = response.getWriter();
		// HTML
		out.println(
				"<HTML>\n" +
				"<HEAD></HEAD>\n" +
				"<BODY BGCOLOR=\"#FDF5E6\">\n");
		out.println("<h1 lig style=\"text-align: center\">All-Time Best Books </h1>");
		out.println("<hr  width=\"100%\"\" align=\"center\" />");
		HttpSession session = request.getSession();
		session.setAttribute("List", bookList);
		response.setContentType("text/html");

		for(Book b : bookList)
		{
			
			out.println("<p><i>"+b.getTitle()+"</i> "
					+ "<b>by "+b.getAuthor()+"</b> "
					+"<b>($"+b.getPrice()+")</b></p>");
			
			out.println("<p>"+b.getDescription()+"</p>");
			
			out.println("<form action=\"Cart\" method=\"POST\" align=\"center\">\r\n"
					+ "	<button align-items=\"center\" type=\"submit\" name=\"id\" value=\""+b.getId()+"\">Add to Shopping Cart</button> \r\n"
					+ "</form>");
			out.println("<hr  width=\"100%\"\" align=\"center\" />");
			

		}
		out.println("</BODY></HTML>");
		
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
