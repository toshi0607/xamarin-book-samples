using Foundation;
using System;
using System.Threading;
using UIKit;

namespace KitchenTimeriOS
{
    public partial class MyViewController : UIViewController
    {
        private TimeSpan _remainingTime = new TimeSpan(0);
        private bool _isStart = false;
        private Timer _timer;

        public MyViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetButtonBorder(StartButton);
            SetButtonBorder(Add10MinButton);
            SetButtonBorder(Add1MinuteButton);
            SetButtonBorder(Add10SecButton);
            SetButtonBorder(Add1SecButton);
            SetButtonBorder(ClearButton);

            Add10MinButton.TouchUpInside += Add10MinButton_TouchUpInside;

            Add1MinuteButton.TouchUpInside += (sender, e) => 
            {
                _remainingTime = _remainingTime.Add(TimeSpan.FromMinutes(1));
                ShowRemainingTime();
            };

            Add10SecButton.TouchUpInside += (sender, e) =>
            {
                _remainingTime = _remainingTime.Add(TimeSpan.FromSeconds(10));
                ShowRemainingTime();
            };

            Add1SecButton.TouchUpInside += (sender, e) =>
            {
                _remainingTime = _remainingTime.Add(TimeSpan.FromSeconds(1));
                ShowRemainingTime();
            };

            StartButton.TouchUpInside += StartButton_TouchUpInside;

            ClearButton.TouchUpInside += (sender, e) => 
            {
                _remainingTime = new TimeSpan(0);
                ShowRemainingTime();
            };

            _timer = new Timer(Timer_OnTick, null, 0, 100);
        }

        private void SetButtonBorder(UIButton button)
        {
            button.Layer.CornerRadius = 3;
            button.Layer.BorderColor = UIColor.LightGray.CGColor;
            button.Layer.BorderWidth = 1f;
        }

        void Add10MinButton_TouchUpInside(object sender, EventArgs e)
        {
            _remainingTime = _remainingTime.Add(TimeSpan.FromMinutes(10));
            ShowRemainingTime();
        }

        private void ShowRemainingTime()
        {
            RemainingTimeLabel.Text = string.Format("{0:f0}:{1:d2}", _remainingTime.TotalMinutes, _remainingTime.Seconds);
        }

        private void StartButton_TouchUpInside(object sender, EventArgs e)
        {
            _isStart = !_isStart;
            if (_isStart)
            {
                StartButton.SetTitle("ストップ", UIControlState.Normal);
            }
            else
            {
                StartButton.SetTitle("スタート", UIControlState.Normal);
            }
        }

        private void Timer_OnTick(object state)
        {
            if (!_isStart)
            {
                return;
            }

            InvokeOnMainThread(() =>
            {
                _remainingTime = _remainingTime.Add(TimeSpan.FromMilliseconds(-100));

                if (_remainingTime.TotalSeconds <= 0)
                {
                    _isStart = false;
                    _remainingTime = new TimeSpan(0);
                    StartButton.SetTitle("スタート", UIControlState.Normal);
                    var sound = new AudioToolbox.SystemSound(1005);
                    sound.PlayAlertSound();
                }
                ShowRemainingTime();
            });
        }
    }
}