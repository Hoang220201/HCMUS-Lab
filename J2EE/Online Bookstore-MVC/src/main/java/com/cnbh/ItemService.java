package com.cnbh;

import java.util.*;

public interface ItemService {
	public List<Item> firstBuy(String bookId);
	public List<Item> updateItem(String itemId, String number);
	List<Item> itemList = new ArrayList<>();
}
