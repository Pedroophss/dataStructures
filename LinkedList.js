class Node {
  constructor(data) {(
        this.data = data,
        this.next = null,
        this.previous = null
        )}
}

class LinkedList {
  constructor() {
    this.head = null;
    this.tail = null;
  }

    setNewHead = data => {
        var newHead = new Node(data);
        if(this.head) {
            newHead.next = this.head;
            this.head.previous = newHead;
        }
        this.head = newHead;
    };

    addItem = (data, index = null) => {
        let newItem = new Node(data);
        if(index)
        {
            let current = this.searchItem(index);
            if(current) {
                current.previous.next = newItem;
                current.previous = newItem;
            }
            this.addItem(data);
        } else {
            if (this.head) {
                let current = this.head;
                while(current.next)
                {
                    current = current.next;
                }
                current.next = newItem;
                newItem.previous = current;
                this.tail = newItem;
            } else {
                this.setNewHead(data);
            }
        }
    };
    
    searchItem = index => {
        if (index == 0) {
            return this.head;
        } else {
            let count = 0;
            let current = this.head;
            while(current)
            {
                if (count == index) {
                    return current;
                }
                count++;
                current = current.next;
            }
        }
    };
    
    deleteItem = data => {
        if(data == this.head.data) {
            if (this.head.next) {
                this.head = this.head.next;
            } else {
                this.head = null;
            }
        } else {
            let current = this.head;
            while(current) {
                if (current.data == data)
                {
                    this.tail = current == this.tail ? current.previous : this.tail;
                    current.previous.next = current.next;
                }
                current = current.next;
            }
        }
    };
    
    deleteByIndex = index => {
        let toDelete = this.searchItem(index);
        this.deleteItem(toDelete.data);
        console.log(myList);
    };
    
};