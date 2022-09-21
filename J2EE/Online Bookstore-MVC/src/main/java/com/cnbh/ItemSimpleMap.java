package com.cnbh;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class ItemSimpleMap implements ItemService {
	private Map<String, Item> items;
	
		
	public ItemSimpleMap() {
		this.items = new HashMap<>();
		this.items.put("1", new Item("1", "Fast learing Java", "Hoang", "Basic java coding for newbie", 9.99, 0));
		this.items.put("2", new Item("2", "The C++ Programming Language", "Hoang", "Basic C++ coding for PRO!!", 10.90, 0));
		this.items.put("3", new Item("3", "The Art of Computer Programming", "Donald Knuth", "Just some basic coding for Bill Gates", 8.42, 0));
		this.items.put("4", new Item("4", "The Harry Potter Series", "J.K.Rowling", "Its faking Harry Potter mate!!", 60.90, 0));
		this.items.put("5", new Item("5", "The Subtle Art of Not Giving a F*ck", "Mark Manson", "Lets be honest, shit is f**ked and we have to live with it.", 13.76, 0));
		
	}
	
	@Override
	public List<Item> firstBuy(String id){
		for (Item i : items.values()){
			if(i.getId().equals(id)) {
				i.setNumber(i.getNumber()+1);
				itemList.add(i);
				break;
			}
				
		}
		return itemList;
	}
	
	
	public List<Item> updateItem(String id, String number) {
		for (Item i : itemList) {
			if(i.getId().equals(id)) {
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
		return itemList;
	}
	

}
