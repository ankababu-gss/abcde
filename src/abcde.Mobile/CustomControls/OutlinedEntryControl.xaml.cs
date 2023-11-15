using System.Runtime.CompilerServices;

namespace abcde.Mobile.CustomControls;

public partial class OutlinedEntryControl : ContentView
{
	public OutlinedEntryControl()
	{
		InitializeComponent();
        showpassword.IsVisible = Password;
        if (Password)
            showpassword.Text = "Hide";
        else
            showpassword.Text = "Show";
    }

    // create a bindable property for the Isreadonly property of the entry
    public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
               propertyName: nameof(IsReadOnly),
                      returnType: typeof(bool),
                             declaringType: typeof(OutlinedEntryControl),
                                    defaultValue: false,
                                           defaultBindingMode: BindingMode.TwoWay);
    public bool IsReadOnly
    {
        get { return (bool)GetValue(IsReadOnlyProperty); }
        set { SetValue(IsReadOnlyProperty, value); }
    }
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(OutlinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);

    // Bindable Text property
    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public static readonly BindableProperty PasswordProperty =
       BindableProperty.Create(nameof(Password), typeof(bool), typeof(OutlinedEntryControl), null);

    // Bindable password type entry
    public bool Password
    {
        get { return (bool)GetValue(PasswordProperty); }
        set { SetValue(PasswordProperty, value); }
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
      propertyName: nameof(Placeholder),
      returnType: typeof(string),
      declaringType: typeof(OutlinedEntryControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);

    // Bindable placeholder text
    public string Placeholder
    {
        get { return (string)GetValue(PlaceholderProperty); }
        set { SetValue(PlaceholderProperty, value); }
    }   

    // method invoked when entry is focused    
    private async void TextBox_Focused(object sender, FocusEventArgs e)
    {
        await TranslateLabelToTitle();
    }

    // method invoked when entry is unfocused
    private async void TextBox_Unfocused(object sender, FocusEventArgs e)
    {
        await TranslateLabelToPlaceHolder();
    }

    // move label from placeholder position to frame border    
    private async Task TranslateLabelToTitle()
    {
            var placeHolder = this.PlaceHolderLabel;
            var distance = GetPlaceholderDistance(placeHolder);
            await placeHolder.TranslateTo(0, -distance);
    }

    // move label from frame border to placeholder position
    private async Task TranslateLabelToPlaceHolder()
    {
        if (string.IsNullOrEmpty(this.Text))
        {
            await this.PlaceHolderLabel.TranslateTo(0, 0);
        }
    }

    // Calculate label displacement    
    private double GetPlaceholderDistance(Label control)
    {
        var distance = 0d;
        if (DeviceInfo.Platform == DevicePlatform.iOS)
            distance = 7;
        else
            distance = 5;

        distance = control.Height + distance;
        return distance;
    }

    // Event handler when text is entered or changed in entry

    public event EventHandler<Microsoft.Maui.Controls.TextChangedEventArgs> TextChanged;
    // method invoked when text is entered
    public virtual void OnTextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        TextChanged?.Invoke(this, e);
    }

    // Unfocus the password field when login page loads   
    private void TextBox_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsPassword")
        {
            Device.BeginInvokeOnMainThread(() => { TextBox.Unfocus(); });
        }
        if (!string.IsNullOrWhiteSpace(this.Text))
        {
            TranslateLabelToTitle();
        }
        else
        {
            TranslateLabelToPlaceHolder();
        }

    }
    
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (propertyName == nameof(Password))
            {
                showpassword.IsVisible = Password;
            }
        });
    }
    
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (TextBox.IsPassword)
            {
                TextBox.IsPassword = false;
                showpassword.Text = "Hide";
            }
            else
            {
                TextBox.IsPassword = true;
                showpassword.Text = "Show";
            }
        });
    }
}