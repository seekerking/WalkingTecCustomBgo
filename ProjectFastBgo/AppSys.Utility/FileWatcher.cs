using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace AppSys.Utility
{
    /// <summary>
    /// 文件变化监视器,解决原生FileSystemWatcher 在监控文件Changed事件是出发两次的问题
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///     FileWatcher watcher=new FileWatcher(Path.GetDirectoryName(filterWordPath), "*.txt", file=>{
    ///         if (Path.GetFileName(file) == "FilterWord.txt") {
    ///             //TODO:
    ///         }
    ///     });
    ///     watcher.StartWatch();
    /// ]]>
    /// </code>
    /// </example>
    public class FileWatcher
    {
        string watcherName;
        string path;
        FileSystemWatcher watcher;

        Action<string> onChanged;
        Timer timer;

        List<string> files = new List<string>();
        /// <summary>
        /// 实例化一个监控器
        /// </summary>
        /// <param name="path">监控目录</param>
        /// <param name="filter">监控的文件类型</param>
        /// <param name="onChanged">变化事件</param>
        /// <param name="watcherName">监控器名称</param>
        public FileWatcher(string path, string filter = null, Action<string> onChanged = null, string watcherName = null)
        {
            this.watcherName = watcherName ?? Guid.NewGuid().ToString();
            this.path = path;
            this.onChanged = onChanged;
            this.watcher = new FileSystemWatcher(path);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                watcher.Filter = filter;
            }
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += new FileSystemEventHandler(Watcher_Changed); //监视业务模块配置文件更改操作;
        }

        /// <summary>
        /// 启动监视器
        /// </summary>
        public void StartWatch()
        {
            watcher.EnableRaisingEvents = true;
            if (timer == null)
            {
                timer = new Timer(new TimerCallback(OnWatchedFileChange), null, Timeout.Infinite, Timeout.Infinite);
            }
        }

        /// <summary>
        /// 文件变化触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Mutex mutex = new Mutex(false, this.watcherName);
            mutex.WaitOne();
            if (!files.Contains(e.Name))
            {
                files.Add(e.Name);
            }
            mutex.ReleaseMutex();
            timer.Change(1000, Timeout.Infinite);    //仅执行一次，延时执行
        }

        private void OnWatchedFileChange(object state)
        {
            Mutex mutex = new Mutex(false, this.watcherName);
            mutex.WaitOne();
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (onChanged != null)
                    {
                        onChanged(file);
                    }
                }
                files.Clear();
            }
            mutex.ReleaseMutex();
        }
    }
}
