using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class NotifyThruMsg
    {
        public void Message(object source, OrderPlacedEventArgs orderargs)
        {
            Console.WriteLine($"Msg : Your order {orderargs.OrderNo} for {orderargs.Item} by {orderargs.CustId} placed on {DateTime.Now}");
        }
    }

}
