using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Poz
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        List<string> friends, mail, sms, pozdrav;

        private void type_Toggled(object sender, ToggledEventArgs e)
        {
            if(type.IsToggled == true)
            {
                state.Text = "Отправка СМС";
            }
            else
            {
                state.Text = "Отправка почтой";
            }
        }

        public MainPage()
        {
            InitializeComponent();
            friends = new List<string>() { "Vitalik", "Afonasii" }; //имена друзей
            sms = new List<string>() { "5999383204545454545", "5556667778834345345324" }; //номера
            mail = new List<string> { "prorokadolbobeka@gmail.com", "karimbasharov@gmail.com" }; //почта
            pozdrav = new List<string> { "С новым годом шиш)", "Привет от Дедули", "Счастья тебе и с Новым Годом!" }; //поздравления
            friend.ItemsSource = friends; //выбираем друга с списка
            friend.SelectedIndexChanged += Friend_SelectedIndexChanged;
            congr.Clicked += Congr_Clicked;
        }
        private void Friend_SelectedIndexChanged(object sender, EventArgs e)
        {
            maill.Text = mail[friend.SelectedIndex];
            num.Text = sms[friend.SelectedIndex];
        }
        private async void Congr_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int rand = random.Next(3);
            if (type.IsToggled == true)
            {
                await Sms.ComposeAsync(new SmsMessage { Body = pozdrav[rand], Recipients = new List<string> { sms[friend.SelectedIndex] } });
                //отправка смс если свитчер вкл
            }
            else
            {
                state.Text = "Отправка почтой";
                await Email.ComposeAsync("Поздравление", pozdrav[rand], mail[friend.SelectedIndex]);
                //отправка почтой если свитчер выкл
            }
        }
    }
}
