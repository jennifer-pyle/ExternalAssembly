using System;
using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;


namespace MOAB.Optix.Core.Streamer
{
    public static class Streamer
    {
        public static void CauseTrouble()
        {
            var UIFolder = Project.Current.Get("UI");
            var screen1 = Project.Current.Get("UI/Screens/Screen1");
            var newButton = InformationModel.Make<Button>("testButton");
            newButton.Text = "NewButton";
            newButton.Width = 50;
            newButton.Height = 50;

            screen1.Add(newButton);
            var variable = Project.Current.GetVariable("Model1/CounterVariable");
            var button1 = Project.Current.Get<Button>("UI/Screens/Screen1/Button1");
            
            while(true)
            {
                Thread.Sleep(1000);
                Int32 oldvalue = variable.Value;
                oldvalue = oldvalue + 1;
                variable.Value = oldvalue;

                //Both of these work. 
                //button1.Text = $"Button {oldvalue}";
                //button1.Width = button1.Width + oldvalue;

            }


        }
    }
}
