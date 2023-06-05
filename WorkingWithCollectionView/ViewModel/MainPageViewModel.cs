using BindingToObject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithCollectionView.ViewModel
{
    internal class MainPageViewModel
    {
        public ObservableCollection<Student> Students { get; set; }
        public MainPageViewModel()
        {
            //נגדיר רשימה ריקה
            Students = new ObservableCollection<Student>();
            Student student = new()
            {
                Image = "dotnet_bot.svg",
                Name = "ברירת מחדל",
                BirthDate = new DateTime()
            };
            //נאתחל את התלמיד הבודד לריק
            Students.Add( student);

        }
    }
}
