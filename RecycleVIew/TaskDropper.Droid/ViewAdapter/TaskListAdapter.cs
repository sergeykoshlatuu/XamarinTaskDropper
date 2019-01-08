using Android.Support.V7.Widget;
using Android.Views;
using System;
using RecycleVIew.Core.Services;
using MvvmCross.ViewModels;

namespace RecycleView.Droid.ViewAdapter
{
    public class TaskListAdapter : RecyclerView.Adapter
    {
        private MvxObservableCollection<Tasks> _taskList;
        public TaskListAdapter(MvxObservableCollection<Tasks> taskList)
        {
            _taskList = taskList;
        }

        public override int ItemCount
        {
            get { return _taskList.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TasksViewHolder vh = holder as TasksViewHolder;
            vh.Title.Text = _taskList[position].Title;
            vh.Status.Checked = _taskList[position].Status;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListItemView, parent, false);
            TasksViewHolder vh = new TasksViewHolder(itemView);
            return vh;
        }

    }
}