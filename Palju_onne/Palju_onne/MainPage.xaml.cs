using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Palju_onne
{
	public partial class MainPage : ContentPage
	{
		List<string> friends, mail, number, greets;
		Picker friendpic;
		Label lbl1, lbl2,lbl3;
		Button btn;

		Switch type;

		public MainPage()
		{
			friendpic = new Picker { Title="Выбрать контакт..."};
			lbl1 = new Label { Text=""};
			lbl2 = new Label { Text =""};
			lbl3 = new Label { Text="Отправить смс"};
			btn = new Button { Text="Отправить поздравление"};
			type = new Switch { IsToggled = false };
			friends = new List<string>() { "Alisa", "Karina", "Nicole" };
			number = new List<string>() { "55574635", "5910203", "55574635" };
			mail = new List<string> { "alisa.krupenko18@gmail.com", "krostislav468@gmail.com", "karimbasharov@gmail.com" };
			greets = new List<string> { "С новым годом!", "Привет от деда мороза!", "Верни долг и с новым годом!", "Счастья в новом году!", "Меньше хлопот в новом году!" };
			
			btn.Clicked += Btn_Clicked;
			friendpic.ItemsSource = friends;
			friendpic.SelectedIndexChanged += Friendpic_SelectedIndexChanged;
			StackLayout stackLayout = new StackLayout()
			{
				Children = { friendpic,btn,lbl1,lbl2, type,lbl3}
			};
			Content = stackLayout;
		}

		private void Friendpic_SelectedIndexChanged(object sender, EventArgs e)
		{
			lbl1.Text = mail[friendpic.SelectedIndex];
			lbl2.Text = number[friendpic.SelectedIndex];
		}

		private async void Btn_Clicked(object sender, EventArgs e)
		{
			Random ran = new Random();
			int rand = ran.Next(5);
			if (type.IsToggled == true)
			{
				await Sms.ComposeAsync(new SmsMessage { Body = greets[rand], Recipients = new List<string> { number[friendpic.SelectedIndex] } });
			}
			else
			{
				await Email.ComposeAsync("Поздравление", greets[rand], mail[friendpic.SelectedIndex]);
			}
		}
	}
}
