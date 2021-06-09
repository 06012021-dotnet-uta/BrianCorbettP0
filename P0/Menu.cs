using System.Collections.Generic;
using System;

namespace P0
{
    public class Menu
    {
        List<string> OptionsList;
        UserInteract userInteract = new UserInteract();
        Type MenuType;

        public Menu(List<string> optionsList, Type menuType)
        {
            this.OptionsList = optionsList;
            this.MenuType = menuType;
        }

        public bool SelectionInBounds(int userSelection)
        {
            return (userSelection > 0 && userSelection <= OptionsList.Count);
        }

        public void PlaceMenu()
        {
            for (int i = 1; i < (OptionsList.Count + 1); i++)
            {
                userInteract.PutLine($"{i}. {OptionsList[i - 1]}");
            }
        }

        public string MenuLoop()
        {
            while (true)
            {
                PlaceMenu();
                double UserSelection;
                int UserSelectionInt;
                if (MenuType == MenuInputType.TypeInteger())
                {
                    UserSelection = userInteract.GetNumber();
                    if (UserSelection == -1)
                    {
                        userInteract.PutLine("Your selection was invalid.");
                        continue;
                    }
                    else if (UserSelection.ToString().Contains('.'))
                    {
                        userInteract.PutLine("Your selection cannot have a decimal");
                        continue;
                    }

                    UserSelectionInt = Convert.ToInt32(UserSelection);
                    if (!SelectionInBounds(UserSelectionInt))
                    {
                        userInteract.PutLine("Your selection is not in the menu");
                        continue;
                    }
                    else
                    {
                        return OptionsList[UserSelectionInt - 1];
                    }
                }
                else if (MenuType == MenuInputType.TypeString())
                {
                    return userInteract.GetString();
                }
            }
        }
    }
}