
using ReactiveUI;
using System;
using System.Linq.Expressions;
using System.Reactive.Concurrency;
namespace Caliburn.Micro.ReactiveUI
{
    /// <summary>
    /// Get the ToProperty working correctly on Caliburn.Micro.
    /// </summary>
    public static class ToPropertyHelpers
    {
        /// <summary>
        /// Converts an Observable to an ObservableAsPropertyHelper and
        /// automatically provides the onChanged method to raise the property
        /// changed notification on a Caliburn.Micro PropertyChangedBase class.
        /// </summary>
        /// <param name="source">The ReactiveObject that has the property</param>
        /// <param name="property">An Expression representing the property (i.e.
        /// 'x => x.SomeProperty'</param>
        /// <param name="initialValue">The initial value of the property.</param>
        /// <param name="scheduler">The scheduler that the notifications will be
        /// provided on - this should normally be a Dispatcher-based scheduler
        /// (and is by default)</param>
        /// <param name="result">Save the helper to an object directly rather than the result of the call. For ease of use.</param>
        /// <param name="This">The stream that will be used to back the property.</param>
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

        /// <summary>
        /// Converts an Observable to an ObservableAsPropertyHelper and
        /// automatically provides the onChanged method to raise the property
        /// changed notification on a Caliburn.Micro PropertyChangedBase class.
        /// </summary>
        /// <param name="source">The ReactiveObject that has the property</param>
        /// <param name="property">An Expression representing the property (i.e.
        /// 'x => x.SomeProperty'</param>
        /// <param name="initialValue">The initial value of the property.</param>
        /// <param name="scheduler">The scheduler that the notifications will be
        /// provided on - this should normally be a Dispatcher-based scheduler
        /// (and is by default)</param>
        /// <param name="This">The source stream to push to the property.</param>
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
            var ret = source.observableToProperty(This, property, initialValue, scheduler);
            return ret;
        }
    }
}
