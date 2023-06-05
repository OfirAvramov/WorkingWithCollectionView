using BindingToObject.Models;
using System.Collections.ObjectModel;


namespace WorkingWithCollectionView.View;

public partial class MainPage : ContentPage
{
    //אוסף התלמידים
    

    #region כדי שהמסך יתעדכן כתוצאה מעדכון נתון עלינו להפעיל את אירוע בכל שינוי ערך שלו. לכן עלינו ליצור שדות מגבה
   
    private Student _student;//תלמיד נבחר
    #endregion

    #region בכל שינוי בשדות נפעיל את האירוע
    public Student Student { get => _student; set { if (_student != value) { _student = value; OnPropertyChanged("Student"); } } }
    
    #endregion

    public MainPage()
    {
       
        //נקשר את הדף שלנו לאובייקט המכיל את הקוד שלו
        this.BindingContext = this;

        InitializeComponent();
    }

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

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        LoadStudents();
        OnPropertyChanged(nameof(Students));

    }
}

