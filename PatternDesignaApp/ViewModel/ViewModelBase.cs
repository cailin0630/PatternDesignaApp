using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PatternDesignaApp.ViewModel
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        private bool _showLoading;

        public bool ShowLoading
        {
            get { return _showLoading; }
            set
            {
                _showLoading = value;
                RaisePropertyChanged();
            }
        }

        public void DoCommand(Func<bool> action)
        {
            ShowLoading = true;
            Task.Run(() => action.Invoke())
                .ContinueWith(ctx =>
            {
                if(ctx.Result)
                    ShowLoading = false;
            });
            
            
        }
        //public void DoCommand(Action act, bool mutex = true)
        //{

        //    DoCommand(() =>
        //    {
        //        act();
        //        return true;
        //    }, mutex);
        //}

        //public Task<bool> DoCommand(Action act, bool mutex = true)
        //{
        //    var watch = Stopwatch.StartNew();
        //    if (mutex && ShowLoading)
        //        return new Task<bool>(() => default(bool));
        //    ShowLoading = true;
        //    return Task.Run(() =>
        //    {
        //        act.Invoke();
        //    }).ContinueWith(ctx =>
        //    {
        //        watch.Stop();
        //        var total = watch.ElapsedMilliseconds;
        //        Console.WriteLine(total);
        //        ShowLoading = false;
        //        if (ctx.IsFaulted)
        //            throw new Exception("异步操作中存在未处理异常");
        //        return ctx.IsCompleted;
        //    });
        //    //DoCommand(() =>
        //    //{
        //    //    act();
        //    //    return true;
        //    //}, mutex);
        //}

        //public Task<T> DoCommand<T>(Func<T> action, bool mutex = true)
        //{
        //    var watch = Stopwatch.StartNew();
        //    if (mutex && ShowLoading)
        //        return new Task<T>(() => default(T));
        //    ShowLoading = true;
        //    return Task.Run(() =>
        //    {
        //        return action.Invoke();
        //    }).ContinueWith(ctx =>
        //    {
        //        watch.Stop();
        //        var total = watch.ElapsedMilliseconds;
        //        Console.WriteLine(total);
        //        ShowLoading = false;
        //        if (ctx.IsFaulted)
        //            throw new Exception("异步操作中存在未处理异常");
        //        return ctx.Result;
        //    });
        //}
    }
}