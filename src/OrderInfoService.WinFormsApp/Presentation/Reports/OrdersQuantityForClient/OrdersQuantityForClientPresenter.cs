﻿using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class OrdersQuantityForClientPresenter : IReportPresenter
    {
        private readonly IOrdersQuantityForClientView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private int _ordersQuantity;

        public OrdersQuantityForClientPresenter(IOrdersQuantityForClientView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
        {
            _view = view;
            _ordersQueries = ordersQueries;
            _fileDialogs = fileDialogs;

            _view.Load += OnLoad;
            _view.Save += OnSave;
            _view.Generate += OnGenerate;
        }

        public Form View => throw new NotImplementedException();

        private void OnLoad(object sender, EventArgs e)
        {
            _view.ClientIds = _ordersQueries.GetClientIds().ToList();
            _view.CanSave = false;
        }

        private void OnGenerate(object sender, EventArgs e)
        {
            _ordersQuantity = _ordersQueries.GetOrdersQuantityForClient(_view.SelectedClientId);
            _view.OrdersQuantity = _ordersQuantity;
            _view.CanSave = true;
        }

        private void OnSave(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveCsvFiles();
            if (path == "" || path == string.Empty)
            {
                return;
            }
            var records = new[]
                    {
                        new { Client_Id = _view.SelectedClientId, Orders_Quantity = _ordersQuantity }
                    }.ToList();
            try
            {
                OrdersWriter.SaveToCsv(records, path);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
            }
        }
    }
}
