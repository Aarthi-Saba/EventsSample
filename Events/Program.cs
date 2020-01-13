using System;
using System.Collections;

public class Program
{

    public static void Main()
    {
        //STEP 5 : Add subscription/associate the event with the event handler
        OrderPlaced op = new OrderPlaced();
        NotifyThruMsg msg = new NotifyThruMsg();
        NotifyThruMail email = new NotifyThruMail();
        op.SendMessage += msg.Message;
        op.SendMessage += email.Mail;

        //STEP 6 : Trigger the event,i.e call the method that starts the event
        op.Order(515, "Paint",109879);
        op.Order(102, "Toy", 9803);
    }
}

//STEP 2 : delegate with signature that matches Event Handler

public delegate void Notify(object source, OrderPlacedEventArgs orderargs);
//STEP 1 : Class to pass args to eventhandler ,inherit from eventargs for customization
public class OrderPlacedEventArgs : EventArgs
{
    public int OrderNo { get; private set; }
    public string Item { get; set; }
    public int CustId { get; set; }
    public OrderPlacedEventArgs(int ONo,string OItem,int CId)
    {
        OrderNo = ONo;
        Item = OItem;
        CustId = CId;
    }
}
//STEP 3 : Event class,with an event variable and method that raises the event "protected virtual void mname()"
public class OrderPlaced
{
    public event Notify SendMessage;
    public void Order(int OrderNo,string OrderItem,int CustId)
    {
        Console.WriteLine($"{CustId} placed {OrderNo} for {OrderItem}");
        OrderSuccess(OrderNo,OrderItem,CustId);
    }
    protected virtual void OrderSuccess(int OrderNumber,string OrderItem,int CustId)
    {
        if(SendMessage != null)
        {
            SendMessage(this, new OrderPlacedEventArgs(OrderNumber,OrderItem,CustId));
        }
    }
}
//STEP 4 : Subscriber/EventHandler with method signature matching delegate's signature
public class NotifyThruMsg
{
    public void Message(object source,OrderPlacedEventArgs orderargs)
    {
        Console.WriteLine($"Msg : Your order {orderargs.OrderNo} for {orderargs.Item} by {orderargs.CustId} placed on {DateTime.Now}");
    }
}


public class NotifyThruMail
{
    public void Mail(object source,OrderPlacedEventArgs orderargs)
    {
        Console.WriteLine($"Email for your order {orderargs.OrderNo} , {orderargs.Item} , {orderargs.CustId}");
    }

}
