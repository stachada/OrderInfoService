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
            var mainPresenter = Bootstrap().Resolve<MainPresenter>();
            Application.Run(mainPresenter.View);
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
            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<MainPresenter>().AsSelf();

            builder.RegisterType<AllOrdersView>().As<IAllOrdersView>();
            builder.RegisterType<AllOrdersPresenter>()
                .Keyed<IPresenter>(OrderReportType.AllOrders);

            builder.RegisterType<OrdersForClientView>().As<IOrdersForClientView>();
            builder.RegisterType<OrdersForClientPresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersForClient);

            builder.RegisterType<OrdersAmountView>().As<IOrdersAmountView>();
            builder.RegisterType<OrdersAmountPresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersAmount);

            builder.RegisterType<OrdersAmountForClientView>().As<IOrdersAmountForClientView>();
            builder.RegisterType<OrdersAmountForClientPresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersAmountForClient);

            builder.RegisterType<OrdersAverageView>().As<IOrdersAverageView>();
            builder.RegisterType<OrdersAveragePresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersAverage);

            builder.RegisterType<OrdersAverageForClientView>().As<IOrdersAverageForClientView>();
            builder.RegisterType<OrdersAverageForClientPresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersAverageForClient);

            builder.RegisterType<OrdersQuantityView>().As<IOrdersQuantityView>();
            builder.RegisterType<OrdersQuantityPresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersQuantity);

            builder.RegisterType<OrdersQuantityForClientView>().As<IOrdersQuantityForClientView>();
            builder.RegisterType<OrdersQuantityForClientPresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersQuantityForClient);

            builder.RegisterType<OrdersInPriceRangeView>().As<IOrdersInPriceRangeView>();
            builder.RegisterType<OrdersInPriceRangePresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersInPricerange);

            builder.RegisterType<OrdersQuantityGroupedByNameView>().As<IOrdersQuantityGroupedByNameView>();
            builder.RegisterType<OrdersQuantityGroupedByNamePresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersQuantityGroupedByName);

            builder.RegisterType<OrdersQuantityGroupedByNameForClientView>().As<IOrdersQuantityGroupedByNameForClientView>();
            builder.RegisterType<OrdersQuantityGroupedByNameForClientPresenter>()
                .Keyed<IPresenter>(OrderReportType.OrdersQuantityGroupedByNameForClient);

            builder.RegisterType<LoadingDataReportView>().As<ILoadingDataReportView>();
            builder.RegisterType<LoadingDataReportPresenter>()
                .Keyed<IPresenter>(OrderReportType.LoadingData);
            
            builder.RegisterType<ReportPresentersFactory>().As<IReportPresentersFactory>();
            
            builder.Register<Func<OrderReportType, IPresenter>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    return ctx.ResolveKeyed<IPresenter>(t);
                };
            });

            var container = builder.Build();
            return container;

        }
    }
}
