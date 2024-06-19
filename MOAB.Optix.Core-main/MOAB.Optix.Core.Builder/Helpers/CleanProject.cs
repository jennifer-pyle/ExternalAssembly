using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTOptix.Core;
using FTOptix.HMIProject;
using UAManagedCore;

namespace MOAB.Optix.Core.Builder.Helpers;

public class CleanProject
{
    //TODO - Ask Keith about Folder layout
    //All folders are within one containing folder 
    public CleanProject()
    {
    }


    public void CleanAll()
    {
        CleanMainWindow();
        CleanFolders();

    }


    public void CleanMainWindow()
    {
        Project.Current.Get("UI/MainWindow").Children.Clear();
    }


    public void CleanFolders()
    {
        // To do: Add recursiveness so that duplicate folders also get deleted
        var folder = Project.Current.Get<Folder>("UI/Components");
        if (folder != null)
        {
            folder.Delete();
        }

        var modelComponentsFolder = Project.Current.Get<Folder>("Model/Components");
        if (modelComponentsFolder != null)
        {
            modelComponentsFolder.Delete();
        }


    }

    // Commenting out temporarily, posssibly need later 
    //private void CheckAndRemoveFolders(IList<Folder> folderList)
    //{
    //    foreach (Folder folder in folderList)
    //    {
    //        if (folder != null)
    //        {
    //            folder.Delete();
    //        }
    //    }
    //}
}
