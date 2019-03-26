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

            // Forms
            builder.RegisterType<MainForm>().AsSelf();

            builder.RegisterType<LoadingDataReport>()
                .Keyed<Form>(OrderReportType.LoadingData);
            builder.RegisterType<AllOrders>()
                .Keyed<Form>(OrderReportType.AllOrders);
            builder.RegisterType<OrdersForClient>()
                .Keyed<Form>(OrderReportType.OrdersForClient);
            builder.RegisterType<OrdersAverage>()
                .Keyed<Form>(OrderReportType.OrdersAverage);
            builder.RegisterType<OrdersAverageForClient>()
                .Keyed<Form>(OrderReportType.OrdersAverageForClient);
            builder.RegisterType<OrdersAmount>()
                .Keyed<Form>(OrderReportType.OrdersAmount);
            builder.RegisterType<OrdersAmountForClient>()
                .Keyed<Form>(OrderReportType.OrdersAmountForClient);
            builder.RegisterType<OrdersInPriceRange>()
                .Keyed<Form>(OrderReportType.OrdersInPricerange);
            builder.RegisterType<OrdersQuantity>()
                .Keyed<Form>(OrderReportType.OrdersQuantity);
            builder.RegisterType<OrdersQuantityForClient>()
                .Keyed<Form>(OrderReportType.OrdersQuantityForClient);
            builder.RegisterType<OrdersQuantityGroupedByName>()
                .Keyed<Form>(OrderReportType.OrdersQuantityGroupedByName);
            builder.RegisterType<OrdersQuantityGroupedByNameForClient>()
                .Keyed<Form>(OrderReportType.OrdersQuantityGroupedByNameForClient);
            builder.RegisterType<ReportsFactory>().As<IReportsFactory>();

            builder.Register<Func<OrderReportType, Form>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    return ctx.ResolveKeyed<Form>(t);
                };
            });

            var container = builder.Build();
            return container;

        }
    }
}
