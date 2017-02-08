using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MMT.Util;

namespace MMT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            
            SaveParams.WriteSettings(DataToSave.Mongod, DataToSave.Mongorestore, DataToSave.Dump, DataToSave.Db, DataToSave.Name, DataToSave.CreateDump, DataToSave.Mdp);
            

        }
    }
}
