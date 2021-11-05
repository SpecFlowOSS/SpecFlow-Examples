using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace SpecFlowCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Calculator _calculator;
        private EditText _firstNumber;
        private EditText _secondNumber;
        private EditText _result;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            _calculator = new Calculator();

            _result = FindViewById<EditText>(Resource.Id.resultTextBox);
            _firstNumber = FindViewById<EditText>(Resource.Id.firstNumberTextBox);
            _secondNumber = FindViewById<EditText>(Resource.Id.secondNumberTextBox);

            var addButton = FindViewById<Button>(Resource.Id.addButton);
            addButton.Click += AddButton_Click;

            var subtractButton = FindViewById<Button>(Resource.Id.subtractButton);
            subtractButton.Click += SubtractButton_Click;

            var multiplyButton = FindViewById<Button>(Resource.Id.multiplyButton);
            multiplyButton.Click += MultiplyButton_Click;

            var divideButton = FindViewById<Button>(Resource.Id.divideButton);
            divideButton.Click += DivideButton_Click;
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            _calculator.FirstNumber = int.Parse(_firstNumber.Text);
            _calculator.SecondNumber = int.Parse(_secondNumber.Text);

            _calculator.Divide();

            _result.Text = _calculator.Result.ToString();
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            _calculator.FirstNumber = int.Parse(_firstNumber.Text);
            _calculator.SecondNumber = int.Parse(_secondNumber.Text);

            _calculator.Multiply();

            _result.Text = _calculator.Result.ToString();
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            _calculator.FirstNumber = int.Parse(_firstNumber.Text);
            _calculator.SecondNumber = int.Parse(_secondNumber.Text);

            _calculator.Subtract();

            _result.Text = _calculator.Result.ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _calculator.FirstNumber = int.Parse(_firstNumber.Text);
            _calculator.SecondNumber = int.Parse(_secondNumber.Text);

            _calculator.Add();

            _result.Text = _calculator.Result.ToString();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
