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
 * Servlet implementation class Cart
 */
@WebServlet("/Cart")
public class Cart extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Cart() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		PrintWriter out = response.getWriter();
		HttpSession session = request.getSession();
		
		List<Book> bookList = new ArrayList<>();
		List<Item> itemList = new ArrayList<>();
		itemList = (List<Item>) session.getAttribute("ListItem");
		if(itemList==null) 
			itemList = new ArrayList<>();
		
		bookList = (List<Book>) session.getAttribute("List");
		
		boolean check = true;
		String Id = request.getParameter("id");
		String number = request.getParameter("number");
		
		
		if(Id!=null && number==null) {
			for(Book b: bookList) {
				if(b.getId().equals(Id)) {
					for(Item i : itemList) {
						if(i.getId().equals(Id)) {
							i.setNumber(i.getNumber()+1);
							check = false;
							break;
						}	
					}
					if(check == true) {
						Item item = new Item(b.getId(),b.getTitle(),b.getAuthor(),b.getDescription(),b.getPrice(),1);
						itemList.add(item);
					}
				}
			}
		}else if(number!=null && Id!=null) {
			for (Item i : itemList) {
				if(i.getId().equals(Id)) {
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
		}
		
		// HTML
		out.println(
				"<HTML>\n" +
				"<HEAD></HEAD>\n" +
				"<BODY BGCOLOR=\"#FDF5E6\">\n");
		out.println("<h1 lig style=\"text-align: center\">Status of Your Order</h1>");
		out.println("<table BORDER=1 style=\"width:100%\">"
				+ "<tr BGCOLOR=\"#FFAD00\">"
				+ "<th>Item ID</th>"
				+ "<th style=\"width:60%\">Description</th>"
				+ "<th>Unit Cost</th>"
				+ "<th>Number</th>"
				+ "<th>Total Cost</th>"
				+ "</tr>");
		if(itemList != null) {
			for(Item i : itemList) {
				out.println("<tr>"
						+ "<td>"+i.getId()+"</td>"
						+ "<td>"+i.getDescription()+"<b> by "+i.getAuthor()+"</b></td>"
						+ "<td>$"+i.getPrice()+"</td>"
						+ "<td style=\"width:5%\"><form action=\"Cart\" method=\"POST\">\r\n"
							+ "<input type=\"nubmer\" name=\"number\" value=\""+i.getNumber()+"\">"
							+ "<button align-items=\"center\" type=\"submit\" name=\"id\" value=\""+i.getId()+"\">Update</button>\r\n"
							+ "</form></td>"
						+ "<td>$"+((double)i.getNumber()*i.getPrice())+"</td>"
						+ "</tr>");
			}
		}
		out.println("</table>");
		out.println("<p lig style=\"text-align: right\"><a href=\"BookPage\">Back to BookPage</a></p>");
		out.println("</BODY></HTML>");
		if(itemList != null) {
			session.setAttribute("ListItem", itemList);
		}
	}
	
	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
