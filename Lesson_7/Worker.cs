using System;
namespace Lesson_7
{
    struct Worker
    {
        private int Id;
        public DateTime dateAdd { get; }
        private string fullName;
        private int age;
        private int lenght;
        private DateTime birthDate;
        private string birthPlace;


        /// <summary>
        /// создание сотрудника
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        /// <param name="dateAdd">Дата добавления</param>
        /// <param name="fullName">Полное имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="lenght">Рост</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="birthPlace">Место рождения</param>
        public Worker(int Id, DateTime dateAdd, string fullName, int age, int lenght,DateTime birthDate, string birthPlace)
        {
           this.Id = Id;
           this.dateAdd = dateAdd;
           this.fullName = fullName;
           this.age = age;
           this.lenght = lenght;
           this.birthDate = birthDate;
           this.birthPlace = birthPlace;
        }

        /// <summary>
        /// создание сотрудника
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        /// <param name="dateAdd">Дата добавления</param>
        /// <param name="fullName">Полное имя</param>
        /// <param name="lenght">Рост</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="birthPlace">Место рождения</param>
        public Worker(int Id, DateTime dateAdd, string fullName, int lenght, DateTime birthDate, string birthPlace)
            :this(Id,dateAdd,fullName,birthDate.Year-dateAdd.Year,lenght,birthDate,birthPlace)
        {

        }

        /// <summary>
        /// создание сотрудника
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        /// <param name="dateAdd">Дата добавления</param>
        /// <param name="fullName">Полное имя</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="birthPlace">Место рождения</param>
        public Worker(int Id, DateTime dateAdd, string fullName, DateTime birthDate, string birthPlace)
            : this(Id, dateAdd, fullName, birthDate.Year - dateAdd.Year, 175, birthDate, birthPlace)
        {

        }

        /// <summary>
        /// создание сотрудника
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        /// <param name="dateAdd">Дата добавления</param>
        /// <param name="fullName">Полное имя</param>
        /// <param name="birthDate">Дата рождения</param>
        public Worker(int Id, DateTime dateAdd, string fullName, DateTime birthDate)
            : this(Id, dateAdd, fullName, birthDate.Year - dateAdd.Year, 175, birthDate, "Планета Земля")
        {

        }

        /// <summary>
        /// создание сотрудника
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        /// <param name="fullName">Полное имя</param>
        /// <param name="birthDate">Дата рождения</param>
        public Worker(int Id, string fullName, DateTime birthDate)
            : this(Id, DateTime.Now, fullName, birthDate.Year - DateTime.Now.Year, 175, birthDate, "Планета Земля")
        {

        }

        /// <summary>
        /// создание сотрудника
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        /// <param name="fullName">Полное имя</param>
        public Worker(int Id, string fullName)
            : this(Id, DateTime.Now, fullName, 20, 175, new DateTime(2000,1,1,0,0,0), "Планета Земля")
        {

        }

        /// <summary>
        /// создание сотрудника
        /// </summary>
        /// <param name="Id">ID сотрудника</param>
        public Worker(int Id)
            : this(Id, DateTime.Now, "Тед Иваненко", 20, 175, new DateTime(2000, 1, 1, 0, 0, 0), "Планета Земля")
        {

        }
        
        /// <summary>
        /// Замена ID
        /// </summary>
        /// <param name="newId">Новый ID</param>
        public void ReplaceId(int newId)
        {
            Id = newId;
        }
        
        /// <summary>
        /// Worker to string
        /// </summary>
        /// <returns>строку для записи</returns>
        public string ToStringWorker()
        {
            string Result = Id.ToString() + "#" 
                + dateAdd.ToString("d") + "#" 
                + fullName + "#" 
                + age.ToString() + "#" 
                + lenght.ToString() + "#" 
                + birthDate.ToString("d") + "#" 
                + birthPlace;
            return Result;
        }

        /// <summary>
        /// ID
        /// </summary>
        /// <returns>ID</returns>
        public int ID()
        {
            return Id;
        }
    }
}
