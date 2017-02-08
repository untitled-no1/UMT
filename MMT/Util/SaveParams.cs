using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMT.Util
{
    public class SaveParams
    {
        public static void WriteSettings(string mongod, string mongorestore, string dump, string db, string name, string createDump, string mdp)
        {
            var dir = Directory.GetCurrentDirectory();
            List<string> tmp = new List<string>();
            tmp.Add("md " + mongod);
            tmp.Add("mr " + mongorestore);
            tmp.Add("dp " + dump);
            tmp.Add("db " + db);
            tmp.Add("nm " + name);
            tmp.Add("cd " + createDump);
            tmp.Add("mp " + mdp);
            File.WriteAllLines(dir + @"\settings.unt", tmp.ToArray());
        }

        public static Dictionary<string, string> ReadSettings()
        {
            Dictionary<string, string> tmp = new Dictionary<string, string>();
            var dir = Directory.GetCurrentDirectory();
            if (!File.Exists(dir + @"\settings.unt"))
            {
                
                return null;
            }
            foreach (var line in File.ReadLines(dir + @"\settings.unt"))
            {
                if (line.StartsWith("md"))
                {
                    tmp["md"] = line.Substring(3);
                }
                else if (line.StartsWith("mr"))
                {
                    tmp["mr"] = line.Substring(3);
                }
                else if (line.StartsWith("dp"))
                {
                    tmp["dp"] = line.Substring(3);
                }
                else if (line.StartsWith("db"))
                {
                    tmp["db"] = line.Substring(3);
                }
                else if (line.StartsWith("nm"))
                {
                    tmp["nm"] = line.Substring(3);
                }
                else if (line.StartsWith("cd"))
                {
                    tmp["cd"] = line.Substring(3);
                }
                else if (line.StartsWith("mp"))
                {
                    tmp["mp"] = line.Substring(3);
                }
            }

            return tmp;
        }
    }
}
