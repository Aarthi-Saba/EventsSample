using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class NotifyThruMail
    {
        public void Mail(object source, OrderPlacedEventArgs orderargs)
        {
            Console.WriteLine($"Email for your order {orderargs.OrderNo} , {orderargs.Item} , {orderargs.CustId}");
        }

    }
}
