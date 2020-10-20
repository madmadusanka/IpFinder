
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IpFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseView : ContentPage
    {
        public BaseView()
        {
            InitializeComponent();
        }
    }
}