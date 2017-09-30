using System;
using MvvmCross.Core.ViewModels;

namespace MvxApp.ViewModels
{
    public class RegisterViewModel : MvxViewModel
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }

        public RegisterViewModel()
        {
            Date = DateTime.Now;
            Text = "";
        }
    }
}
