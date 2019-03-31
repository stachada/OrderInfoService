using System;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class SelectedOrderChangedEventArgs : EventArgs
    {
        public SelectedOrderChangedEventArgs(OrderDto order)
        {
            Order = order;
        }

        public OrderDto Order { get; private set; }
    }
}
