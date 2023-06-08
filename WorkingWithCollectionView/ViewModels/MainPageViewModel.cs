using BindingToObject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace WorkingWithCollectionView.ViewModels
{
    public class MainPageViewModel:ViewModel
    {
        public ObservableCollection<Student> Students { get; set; }

        public ICommand LoadDataCommand { get; private set; }

        public ICommand ClearDataCommand { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        public ICommand AddStuCommand { get; private set; }

        private string currentName;
        public string CurrentName { get => Student.Name; set { if (name != value) { name = value; OnPropertyChanged(); } } }

        DateTime date;
        public DateTime CurrentDate { get { return date; } set { if (date != value) { date = value; OnPropertyChanged(); } } }

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

            LoadDataCommand = new Command(LoadStudents);
            ClearDataCommand = new Command(Students.Clear);
            AddStuCommand = new Command(() => Students.Add(new Student() { BirthDate = CurrentDate, Image = $"{Student.Name}.jpg", Name =Student.Name }));
            OnPropertyChanged("Students");
        }

       


        #region כדי שהמסך יתעדכן כתוצאה מעדכון נתון עלינו להפעיל את אירוע בכל שינוי ערך שלו. לכן עלינו ליצור שדות מגבה

        private Student _student;//תלמיד נבחר
        #endregion

        #region בכל שינוי בשדות נפעיל את האירוע
        public Student Student { get => _student; set { if (_student != value) { _student = value; OnPropertyChanged("Student"); } } }

        #endregion

        /// <summary>
        /// פעולה הטוענת את נתוני התלמידים 
        /// מכיוון ש
        /// Students הוא ObeservableCollection
        /// הפקד המקושר יתעדכן אוטומטית
        /// </summary>
        private void LoadStudents()
        {
            this.Students.Clear();
            //דוגמה להוספת תלמיד בעקבות השינוי של גרסא 6 - אין צורך לציין אחרי
            //new שם מחלקה
            Students.Add(new() { Name = "Roni", Image = "roni.jpg", BirthDate = new DateTime(2006, 2, 19) });
            //הוספת תלמיד בדרך המלאה
            Students.Add(new Student { Name = "Omer", BirthDate = new DateTime(2006, 2, 9), Image = "omer.jpg" });
            Student = Students[0];
            OnPropertyChanged(nameof(Students));

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            LoadStudents();
            OnPropertyChanged(nameof(Students));

        }
    }
}
