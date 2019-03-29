using Autofac;
using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Read;
using OrderInfoService.WinFormsApp.Presentation;
using System;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Bootstrap().Resolve<MainForm>());
        }

        static Autofac.IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            // Infrastructure
            builder.RegisterType<OrdersReader>().As<IOrdersReader>();
            builder.RegisterType<OrdersInMemoryDb>().As<IOrdersInMemoryDb>().SingleInstance();

            // Application
            builder.RegisterType<OrdersQueries>().As<IOrdersQueries>();
            builder.RegisterType<FileDialogs>().As<IFileDialogs>();

            // Forms
            builder.RegisterType<MainForm>().AsSelf();

            builder.RegisterType<AllOrdersView>().As<IAllOrdersView>();
            builder.RegisterType<AllOrdersPresenter>()
                .Keyed<IReportPresenter>(OrderReportType.AllOrders);

            builder.RegisterType<OrdersForClientView>().As<IOrdersForClientView>();
            builder.RegisterType<OrdersForClientPresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersForClient);

            builder.RegisterType<OrdersAmountView>().As<IOrdersAmountView>();
            builder.RegisterType<OrdersAmountPresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersAmount);

            builder.RegisterType<OrdersAmountForClientView>().As<IOrdersAmountForClientView>();
            builder.RegisterType<OrdersAmountForClientPresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersAmountForClient);

            builder.RegisterType<OrdersAverageView>().As<IOrdersAverageView>();
            builder.RegisterType<OrdersAveragePresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersAverage);

            builder.RegisterType<OrdersAverageForClientView>().As<IOrdersAverageForClientView>();
            builder.RegisterType<OrdersAverageForClientPresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersAverageForClient);

            builder.RegisterType<OrdersQuantityView>().As<IOrdersQuantityView>();
            builder.RegisterType<OrdersQuantityPresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersQuantity);

            builder.RegisterType<OrdersQuantityForClientView>().As<IOrdersQuantityForClientView>();
            builder.RegisterType<OrdersQuantityForClientPresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersQuantityForClient);

            builder.RegisterType<OrdersInPriceRangeView>().As<IOrdersInPriceRangeView>();
            builder.RegisterType<OrdersInPriceRangePresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersInPricerange);

            builder.RegisterType<OrdersQuantityGroupedByNameView>().As<IOrdersQuantityGroupedByNameView>();
            builder.RegisterType<OrdersQuantityGroupedByNamePresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersQuantityGroupedByName);

            builder.RegisterType<OrdersQuantityGroupedByNameForClientView>().As<IOrdersQuantityGroupedByNameForClientView>();
            builder.RegisterType<OrdersQuantityGroupedByNameForClientPresenter>()
                .Keyed<IReportPresenter>(OrderReportType.OrdersQuantityGroupedByNameForClient);

            builder.RegisterType<LoadingDataReport>()
                .Keyed<Form>(OrderReportType.LoadingData);

            builder.RegisterType<ReportsFactory>().As<IReportsFactory>();
            builder.RegisterType<ReportPresentersFactory>().As<IReportPresentersFactory>();

            builder.Register<Func<OrderReportType, Form>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    return ctx.ResolveKeyed<Form>(t);
                };
            });

            builder.Register<Func<OrderReportType, IReportPresenter>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    return ctx.ResolveKeyed<IReportPresenter>(t);
                };
            });

            var container = builder.Build();
            return container;

        }
    }
}
