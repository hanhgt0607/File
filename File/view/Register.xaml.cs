using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using File.entity;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace File.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private Member currentMember;
        public Register()
        {
            this.InitializeComponent();
            this.currentMember = new Member();
            
        }

        private async void Do_Submit(object sender, RoutedEventArgs e)
        {
            this.currentMember.Name = this.name.Text;
            this.currentMember.Phone = this.phone.Text;
            this.currentMember.Email = this.email.Text;
            string jsonMember = JsonConvert.SerializeObject(this.currentMember);

            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "File";
            StorageFile file = await savePicker.PickSaveFileAsync();
            await Windows.Storage.FileIO.WriteTextAsync(file, jsonMember);

        }

        private async void Do_Loader(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();
            string content = await Windows.Storage.FileIO.ReadTextAsync(file);
            Member menber = JsonConvert.DeserializeObject<Member>(content);
            name.Text = menber.Name;
            phone.Text = menber.Phone;
            email.Text = menber.Email;
        }
    }
}
