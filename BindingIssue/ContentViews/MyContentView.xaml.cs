using System.Diagnostics;
using Xamarin.Forms;

namespace BindingIssue.ContentViews
{
    public partial class MyContentView : ContentView
    {
        public MyContentView()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public static readonly BindableProperty MyTextProperty =
            BindableProperty.Create(nameof(MyText), typeof(string), typeof(MyContentView), default(string), defaultBindingMode: BindingMode.TwoWay, propertyChanged: MyTextChanged);
        private static void MyTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Called 7 times on first load (there are only 5 items in the MockDataStore).
            // Called 1 time when performing a RefreshView/LoadItemsCommand.
            Debug.WriteLine($"MyTextChanged, oldValue: {oldValue}, newValue: {newValue}");
            ((MyContentView)bindable).MyTextChanged((string)oldValue, (string)newValue);
        }
        private void MyTextChanged(string oldValue, string newValue)
        {
            MyText = newValue;
        }
        public string MyText
        {
            get
            {
                return (string)GetValue(MyTextProperty);
            }
            private set
            {
                SetValue(MyTextProperty, value);
            }
        }
    }
}
