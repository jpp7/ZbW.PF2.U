// See https://aka.ms/new-console-template for more information

using MB14.QueueExample;

Console.WriteLine("Hello, World!");


var x = new QueueLinkedList();

DateTime dateTime = DateTime.Now;
string itemText = "hello";
string itemName = "name";

x.Enqueue(dateTime);
x.Enqueue(itemText);
x.Enqueue(itemName);

var item = x.Dequeue();
item = x.Dequeue();


for(int i=0; i < 10; i++) {
    x.Peek();
}
    

item = x.Dequeue();


