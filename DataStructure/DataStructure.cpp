// DataStructure.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

#pragma region  Single LinkedList Implementaion
//class linkedListNode
//{
//public:
//	int data;
//	linkedListNode* next;
//
//	linkedListNode(int _data)
//	{
//		this->data = _data;
//		this->next = NULL;
//	};
//
//
//};
//class linkedlistIterator
//{
//private:
//	linkedListNode* currentNode;
//public:
//	linkedlistIterator() { currentNode = NULL; }
//	linkedlistIterator(linkedListNode* node) { currentNode = node; }
//	int data() { return this->currentNode->data; }
//	linkedlistIterator next()
//	{
//		this->currentNode = this->currentNode->next;
//		return *this;
//	}
//	linkedListNode* current()
//	{
//		return this->currentNode;
//	}
//};
//class linkedlist
//{
//public:
//	linkedListNode* head = NULL;
//	linkedListNode* tail = NULL;
//	linkedlistIterator begin()
//	{
//		linkedlistIterator itr(this->head);
//		return itr;
//	}
//	void print()
//	{
//		for (linkedlistIterator itr = this->begin(); itr.current() != NULL; itr.next())
//		{
//			cout << itr.data() << " -->";
//		}
//		cout << "\n";
//	}
//	void InsertLast(int _data)
//	{
//		// Create Pointer for NewNode
//		linkedListNode* newNode = new linkedListNode(_data);
//		//Validation 
//		// Check LinkedList Empty or Not 
//		if (head == NULL)
//		{
//			this->head = newNode;
//			this->tail = newNode;
//		}
//		// there are data in LinkedList 
//		else
//		{
//			this->tail->next = newNode;
//			this->tail = newNode;
//		}
//
//	}
//	linkedListNode* FindNode(int _data)
//	{
//		for (linkedlistIterator itr = this->begin(); itr.current() != NULL; itr.next())
//		{
//			if (_data == itr.data())
//				return itr.current();
//		}
//		return NULL;
//	}
//	//Work with InsertAfter need input Node so will make function find the node and return it ;
//	void InsertAfter(linkedListNode* node, int _data)
//	{
//		if (node == NULL) return;
//		linkedListNode* NewNode = new linkedListNode(_data);
//		NewNode->next = node->next;
//		node->next = NewNode;
//		if (node->next == NULL)
//		{
//			this->tail = NewNode;
//		}
//	}
//	// Find Parent Node Which Before Node i Already Sent 
//	linkedListNode* FindParent(linkedListNode* Node)
//	{
//		for (linkedlistIterator itr = this->begin(); itr.current() != NULL; itr.next())
//		{
//			if (itr.current()->next == Node)
//				return itr.current();
//		}
//		return NULL;
//	}
//	void InsertBefore(linkedListNode* node, int _data)
//	{
//		if (node == NULL) return;
//		linkedListNode* newNode = new linkedListNode(_data);
//		newNode->next = node;
//		linkedListNode* Parent = this->FindParent(node);
//		if (Parent == NULL)
//		{
//			this->head = newNode;
//		}
//		else
//		{
//			Parent->next = newNode;
//		}
//	}
//	void DeleteNode(linkedListNode* node)
//	{
//		if (node == NULL) return;
//		if (this->head == node && this->tail == node)
//		{
//			this->head = this->tail = NULL;
//		}
//		else if (this->head == node)
//		{
//			this->head = node->next;
//		}
//		else
//		{
//			linkedListNode* Parent = this->FindParent(node);
//			if (this->tail == node)
//			{
//				this->tail = Parent;
//			}
//			else
//			{
//				Parent->next = node->next;
//			}
//		}
//		delete node;
//	}
//
//};

#pragma endregion

#pragma region  Double LinkedList Implementaion
class linkedListNode
{
public:
	int data;
	linkedListNode* next;
	linkedListNode* back;
	linkedListNode(int _data)
	{
		this->data = _data;
		this->next = NULL;
		this->back = NULL;
	};
};
class linkedlistIterator
{
private:
	linkedListNode* currentNode;
public:
	linkedlistIterator() { currentNode = NULL; }
	linkedlistIterator(linkedListNode* node) { currentNode = node; }
	int data() { return this->currentNode->data; }
	linkedlistIterator next()
	{
		this->currentNode = this->currentNode->next;
		return *this;
	}
	linkedListNode* current()
	{
		return this->currentNode;
	}
};
class linkedlist
{
public:
	linkedListNode* head = NULL;
	linkedListNode* tail = NULL;
	linkedlistIterator begin()
	{
		linkedlistIterator itr(this->head);
		return itr;
	}
	void print()
	{
		for (linkedlistIterator itr = this->begin(); itr.current() != NULL; itr.next())
		{
			cout << itr.data() << " -->";
		}
		cout << "\n";
	}
	
	linkedListNode* FindNode(int _data)
	{
		for (linkedlistIterator itr = this->begin(); itr.current() != NULL; itr.next())
		{
			if (_data == itr.data())
				return itr.current();
		}
		return NULL;
	}
	//Work with InsertAfter need input Node so will make function find the node and return it ;
	void InsertAfter(linkedListNode* node, int _data)
	{
		if (node == NULL) return;
		linkedListNode* newNode = new linkedListNode(_data);
		newNode->next = node->next;
		newNode->back = node; 
		node->next = newNode;
		if (newNode->next == NULL)
		{
			this->tail = newNode;
		}
		else
		{
			newNode->next->back = newNode; 
		}
	}
	
	void InsertBefore(linkedListNode* node, int _data)
	{
		if (node == NULL) return;
		linkedListNode* newNode = new linkedListNode(_data);
		newNode->back = node->back;
		newNode->next = node;
		if (node->back == NULL)
			this->head = newNode;
		else 
		{
			node->back->next = newNode;
		}
		node->back = newNode;
	}
	void InsertLast(int _data)
	{
		linkedListNode* newNode = new linkedListNode(_data); 
		if (this->tail == NULL)
		{
			this->head = newNode;
			this->tail = newNode;
		}
		else
		{
			newNode->back = tail; 
			this->tail->next = newNode;
			this->tail = newNode; 
		}


	}
	void DeleteNode(linkedListNode* node)
	{
		if (node == NULL) return;
		if (this->head == this->tail ) // (this->head ==node && this->tail == node ) ==> onlyone element in list
			this->head = this->tail = NULL;
		else if (this->head == node)
		{
			node->next->back = NULL;
			this->head = node->next;
		}
		else if(this->tail==node)
		{
				node->back->next = NULL;
				this->tail = node->back;
		}
		else
		{
			node->back->next = node->next;
			node->next->back = node->back;
		}

		delete node;
	}

};

#pragma endregion
int main()
{
	linkedlist* list = new linkedlist(); ;
	list->InsertLast(1);
	list->InsertLast(2);
	list->InsertLast(3);
	list->InsertLast(4);
	list->print();

	list->InsertAfter(list->FindNode(2), 98);
	list->print();
	list->InsertBefore(list->FindNode(1), 90);
	list->print();
	/*list->DeleteNode(list->FindNode(4));
	list->print();*/

	
	
	
}


