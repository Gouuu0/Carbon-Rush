using Godot;
using System;
using System.Collections.Generic;

//Author : Merfoud Kélyan

namespace Com.IsartDigital.Game
{

	public class LgManager : Node2D
	{
		static public int lengthChecker;

		private static Dictionary<Control, List<string>> translate = new Dictionary<Control, List<string>>() { };
		public static List<Control> translationList = new List<Control>() { };
		private List<Button> buttonList = new List<Button>() { };

		private int language = 0; //use as the list index (choose the language)
		private Color startColor;
		public override void _Ready()
		{
			foreach (Button item in GetChildren())
			{
				buttonList.Add(item);
				item.Connect(StrManager.PRESSED, this, nameof(Translation), new Godot.Collections.Array() { (item) });
			}
			startColor = buttonList[0].Modulate;

			SetGrey(buttonList[0]); //our default language is the only one in the basic color (at the beggining)
		}

		public static void TranslateAdd(Control pControl, List<string> pList) //to simplify our task dear teammates
		{
			switch (pControl)
			{
				case Label pLabel:
					pLabel = pControl as Label;
					translate.Add(pLabel, pList);
					translationList.Add(pLabel);
					break;
				case Button pButton:
					pButton = pControl as Button;
					translate.Add(pButton, pList);
					translationList.Add(pButton);
					break;
				default:
					break;
			}
			if (lengthChecker != 0 && pList.Count - 1 != lengthChecker)
			{
				GD.Print("Problem of length detected from the list " + pList + " the number of index difference is ", lengthChecker - pList.Count - 1);//call this when a list too many or not enough index
			}
			else lengthChecker = pList.Count - 1;
		}

		private void Translation(Button pButton)
		{
			language = buttonList.IndexOf(pButton);
			for (int i = 0; i < translationList.Count; i++)
			{
				switch (translationList[i])
				{
					case Label lLabel:
						lLabel = translationList[i] as Label;
						lLabel.Text = translate[translationList[i]][language];
						break;
					case Button lButton:
						lButton = translationList[i] as Button;
						lButton.Text = translate[translationList[i]][language];
						break;
					default:
						break;
				}
			}
			SetGrey(pButton);
		}
		private void SetGrey(Button pButton)
		{
			foreach (Button item in buttonList) item.Modulate = Colors.DarkSlateGray;
			pButton.Modulate = startColor;
		}
	}
}