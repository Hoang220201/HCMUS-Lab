<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<%@ taglib uri = "http://java.sun.com/jsp/jstl/core" prefix = "c" %> 
    
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
<title>Cart</title>
</head>
<body>
 <h1 class="text-center">CART</h1>
	<table class="table table-bordered table-sm">
        <tr>
            <th>Book Name</th>
            <th>Description</th>
            <th>Author</th>
            <th>Price</th>
            <th>Number</th>
            <th>Total</th>
         </tr>

      <c:forEach var="item" items="${items}">
          <tr>
            <td>
                 ${item.title} 
            </td>
            <td>
                 ${item.description}
            </td>
            <td>
                  ${item.author} 
            </td>
            <td>
                 ${item.price}$
            </td>
            <td>
                <form action="BookPage">
                     <input type="number" name="number" value="${item.number}"></input>
                     <button type="submit" name="itemId" value="${item.id}">Update</button> 
                 </form>
            </td>
            <td>
                  ${item.number*item.price}$
            </td>
         </tr>
      </c:forEach>
    </table>
      <p><a href="BookPage">Back to BookPage</a></p>
</body>
</html>