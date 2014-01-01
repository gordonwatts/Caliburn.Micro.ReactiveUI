using ReactiveUI;
using Splat;
using System;
using System.Linq.Expressions;
using System.Reactive.Concurrency;

namespace Caliburn.Micro.ReactiveUI
{
    internal static class OAPHCreationHelperMixinCM
    {
        public static ObservableAsPropertyHelper<TRet> observableToProperty<TObj, TRet>(
                this TObj This,
                IObservable<TRet> observable,
                Expression<Func<TObj, TRet>> property,
                TRet initialValue = default(TRet),
                IScheduler scheduler = null)
            where TObj : PropertyChangedBase
        {
            string prop_name = Reflection.SimpleExpressionToPropertyName(property);
            var ret = new ObservableAsPropertyHelper<TRet>(observable,
                _ => This.NotifyOfPropertyChange(prop_name),
                initialValue, scheduler);

            LogHost.Default.Debug("OAPH {0:X} is for {1}", ret, prop_name);
            return ret;
        }

        /// <summary>
        /// Converts an Observable to an ObservableAsPropertyHelper and
        /// automatically provides the onChanged method to raise the property
        /// changed notification.         
        /// </summary>
        /// <param name="source">The ReactiveObject that has the property</param>
        /// <param name="property">An Expression representing the property (i.e.
        /// 'x => x.SomeProperty'</param>
        /// <param name="initialValue">The initial value of the property.</param>
        /// <param name="scheduler">The scheduler that the notifications will be
        /// provided on - this should normally be a Dispatcher-based scheduler
        /// (and is by default)</param>
        /// <param name="This">The source stream to match the property.</param>
        /// <returns>An initialized ObservableAsPropertyHelper; use this as the
        /// backing field for your property.</returns>
        public static ObservableAsPropertyHelper<TRet> ToProperty<TObj, TRet>(
            this IObservable<TRet> This,
            TObj source,
            Expression<Func<TObj, TRet>> property,
            TRet initialValue = default(TRet),
            IScheduler scheduler = null)
            where TObj : PropertyChangedBase
        {
            return source.observableToProperty(This, property, initialValue, scheduler);
        }

        /// <summary>
        /// Converts an Observable to an ObservableAsPropertyHelper and
        /// automatically provides the onChanged method to raise the property
        /// changed notification.         
        /// </summary>
        /// <param name="source">The ReactiveObject that has the property</param>
        /// <param name="property">An Expression representing the property (i.e.
        /// 'x => x.SomeProperty'</param>
        /// <param name="initialValue">The initial value of the property.</param>
        /// <param name="scheduler">The scheduler that the notifications will be
        /// provided on - this should normally be a Dispatcher-based scheduler
        /// (and is by default)</param>
        /// <param name="This">The source stream to back the property.</param>
        /// <param name="result">Out parameter to set the ObservableAsPropertyHelper instead of the equal.</param>
        /// <returns>An initialized ObservableAsPropertyHelper; use this as the
        /// backing field for your property.</returns>
        public static ObservableAsPropertyHelper<TRet> ToProperty<TObj, TRet>(
            this IObservable<TRet> This,
            TObj source,
            Expression<Func<TObj, TRet>> property,
            out ObservableAsPropertyHelper<TRet> result,
            TRet initialValue = default(TRet),
            IScheduler scheduler = null)
            where TObj : PropertyChangedBase
        {
            var ret = source.observableToProperty(This, property, initialValue, scheduler);

            result = ret;
            return ret;
        }
    }

}
