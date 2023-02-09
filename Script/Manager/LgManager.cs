using Godot;
using System;
using System.Collections.Generic;

namespace Com.IsartDigital.Manager
{

	public class LgManager : Node2D
	{
		static public int lenghtChecker;

		[Export] private NodePath buttonContainerPath;
		private Node2D buttonContainer;


		private static Dictionary<Control, List<string>> translate = new Dictionary<Control, List<string>>() { };
		public static List<Control> translationList = new List<Control>() { };
		private List<Button> buttonList = new List<Button>() { };

		private int language = 0; //use as the list index (choose the language)

		public override void _Ready()
		{
			buttonContainer = (Node2D)GetNode(buttonContainerPath);
			foreach (Button item in buttonContainer.GetChildren())
			{
				buttonList.Add(item);
				item.Connect(StrManager.PRESSED, this, nameof(Translation), new Godot.Collections.Array() { (item) });
			}
		}

		public static void translateAdd(Control pControl, List<string> pList) //to simplify our task dear teammates
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
			if (lenghtChecker != 0 && pList.Count - 1 != lenghtChecker)
			{
				GD.Print("Problem of lenght detected from the list " + pList + " the number of index difference is ", lenghtChecker - pList.Count - 1);//call this when a list too many or not enough index
			}
			else lenghtChecker = pList.Count - 1;
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
		}
	}
}