
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MMT.Util;

namespace MMT.Logic
{
    public class StartDbVM : INotifyPropertyChanged
    {
        public StartDbVM()
        {
            var tmp = SaveParams.ReadSettings();
            if (tmp != null)
            {
                MongoDLocation = tmp["md"];
                MongoRestoreLocation = tmp["mr"];
                MongoDump = tmp["mp"];
                DumpLocation = tmp["dp"];
                DbLocation = tmp["db"];
                DBName = tmp["nm"];
                CreateDumpLocation = tmp["cd"];
            }
            
            
        }

        private string _mongoDLocation;
        public string MongoDLocation
        {
            get { return _mongoDLocation; }
            set
            {
                _mongoDLocation = value;
                DataToSave.Mongod = value;
                OnPropertyChanged(nameof(MongoDLocation));
            }
        }

        private string dbLocation;
        public string DbLocation
        {
            get { return dbLocation; }
            set
            {
                dbLocation = value;
                DataToSave.Db = value;
                OnPropertyChanged(nameof(DbLocation));
            }
        }

        private string createDumpLocation;
        public string CreateDumpLocation
        {
            get { return createDumpLocation; }
            set
            {
                createDumpLocation = value;
                DataToSave.CreateDump = value;
                OnPropertyChanged(nameof(CreateDumpLocation));
            }
        }

        private string _mongoRestoreLocation;
        public string MongoRestoreLocation
        {
            get { return _mongoRestoreLocation; }
            set
            {
                _mongoRestoreLocation = value;
                DataToSave.Mongorestore = value;
                OnPropertyChanged(nameof(MongoRestoreLocation));
            }
        }

        private string mongoDump;
        public string MongoDump
        {
            get { return mongoDump; }
            set
            {
                mongoDump = value;
                DataToSave.Mdp = value;
                OnPropertyChanged(nameof(MongoDump));
            }
        }

        private string dumpLocation;
        public string DumpLocation
        {
            get { return dumpLocation; }
            set
            {
                dumpLocation = value;
                DataToSave.Dump = value;
                OnPropertyChanged(nameof(DumpLocation));
            }
        }

        private string _dbName;
        public string DBName
        {
            get { return _dbName; }
            set
            {
                _dbName = value;
                DataToSave.Name = value;
                OnPropertyChanged(nameof(DBName));
            }
        }

        private ICommand runDb;
        public ICommand RunDb => runDb ?? (runDb = new RelayCommand(RunDbCommand));

        private async void RunDbCommand(object obj)
        {
            await Task.Run(() =>
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = MongoDLocation;
                startInfo.Arguments = $"--dbpath {DbLocation}";
                process.StartInfo = startInfo;
                process.Start();
            });
        }

        private ICommand restoreDB;
        public ICommand RestoreDB => restoreDB ?? (restoreDB = new RelayCommand(RestoreDbCommand));

        private async void RestoreDbCommand(object obj)
        {
            await Task.Run(() =>
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = MongoRestoreLocation;
                startInfo.Arguments = $"--db {DBName} {DumpLocation}";
                process.StartInfo = startInfo;
                process.Start();
            });
        }


        private ICommand dumpDB;
        public ICommand DumpDB => dumpDB ?? (dumpDB = new RelayCommand(DumpDbCommand));

        private async void DumpDbCommand(object obj)
        {
            await Task.Run(() =>
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = MongoDump;
                startInfo.Arguments = $"-d {DBName} -o {CreateDumpLocation}";
                process.StartInfo = startInfo;
                process.Start();
            });
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}