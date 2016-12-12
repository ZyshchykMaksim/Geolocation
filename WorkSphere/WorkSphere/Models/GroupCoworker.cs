using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Models
{
    public class GroupCoworker : ObservableCollection<Coworker>
    {
        public GroupCoworker(string firstInitial)
        {
            FirstInitial = firstInitial;
        }

        public string FirstInitial
        {
            get;
            private set;
        }
    }
}
