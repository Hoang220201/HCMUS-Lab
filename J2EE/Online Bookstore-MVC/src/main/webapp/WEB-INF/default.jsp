<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<%@ taglib uri = "http://java.sun.com/jsp/jstl/core" prefix = "c" %>

<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
<title>BookPage</title>
</head>
<body>
   <h1 class="text-center">Online Book Store</h1>
    <table class="table table-bordered table-sm">
        <tr>
            <th>Book Name</th>
            <th>Description</th>
            <th>Author</th>
            <th>Price</th>
            <th>Cart</th>
         </tr>

      <c:forEach var="book" items="${books}">
          <tr>
            <td>
                 ${book.title} 
            </td>
            <td>
                 ${book.description}
            </td>
            <td>
                 ${book.author} 
            </td>
            <td>
                 ${book.price}$ 
            </td>
            <td>
                 <form action="BookPage">
                     <button type="submit" name="bookId" value="${book.id}">Add to Cart</button> 
                 </form>
            </td>
         </tr>
      </c:forEach>
    </table>
</body>
</html>