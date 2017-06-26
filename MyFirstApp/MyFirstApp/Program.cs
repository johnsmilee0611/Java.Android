using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var commitsFile = File.ReadAllLines(@"C:\CommitsOfMaster.txt");

            var commits = commitsFile.Select(t => {
                return t.Split(' ')[0];
            }).ToList();

            commits.Reverse();

            commits = commits.Select(t => "git cherry-pick --strategy=recursive -X theirs " + t).ToList();
            var cherryPick = string.Join(Environment.NewLine, commits);
        }
    }
}
