using Lesson_7;
using System;
using System.IO;
using System.Text;

namespace Lesson6
{
    class Programm
    {
        static Repository repository = new Repository();
        static void Main(string[] args)
        {
            ConsoleKeyInfo ski;
            string pathFile = "DataWorkers.csv";
            

            Console.WriteLine("Нажмите на кнопку \n\t1 — вывести данные на экран; \n\t2 — заполнить данные и добавить новую запись в конец файла.");

            while (true)
            {
                ski = Console.ReadKey();

                if (ski.Key == ConsoleKey.D1 || ski.Key == ConsoleKey.NumPad1)
                {
                    Exercise_1(pathFile);
                    break;
                }

                if (ski.Key == ConsoleKey.D2 || ski.Key == ConsoleKey.NumPad2)
                {
                    Exercise_2(pathFile);
                    break;
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// выводит данные о всех работниках в консоль
        /// </summary>
        /// <param name="path">путь к файлу с таблицей</param>
        static void Exercise_1(string path)
        {
            if (File.Exists("Repository.csv") == true)
            {
                Worker[] workers = repository.GetAllWorkers();

                Write(StringOutputFormat("ID#Дата добавления#ФИО#Возраст#Рост#Дата рождения#Место рождения"));

                foreach (Worker worker in workers)
                {
                    Write(StringOutputFormat(worker.ToStringWorker()));
                }
            }
            else
            {
                File.Create("Repository.csv");
                Write("Создан пустой файл");
            }
        }

        /// <summary>
        /// метод для добавления сотрудника в таблицу
        /// </summary>
        /// <param name="path">путь к файлу с таблицей</param>
        static void Exercise_2(string path)
        {
            char key = 'д';

            do
            {
                
                repository.AddWorker(FillingForm());

                Console.WriteLine("Добавить ещё сотрудника? д/н");
                key = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(key) == 'д');
        }

        /// <summary>
        /// метод выводящий переменные типа string построчно
        /// </summary>
        /// <param name="words">выводимые переменные</param>
        static void Write(string[] words)
        {
            Console.WriteLine("\n");
            foreach (string word in words)
            {
                string wordOut = StringOutputFormat(word);
                Console.WriteLine(wordOut);
            }
        }
        static void Write(string word)
        {
            Console.WriteLine("\n" + word);
        }

        /// <summary>
        /// приведение строк к единному формату, для аккуратного вывода
        /// </summary>
        /// <param name="inputString">строка формата "из таблицы"</param>
        /// <returns>Строка готовая к выводу в консоль</returns>
        static string StringOutputFormat(string inputString)
        {
            //параметры форматирования строк для вывода
            int valueNumber = 5,
                valueDataAdd = 20,
                valueName = 33,
                valueAge = 10,
                valueHeight = 10,
                valueDataBirth = 16,
                valueTown = 32;

            string[] words = inputString.Split('#');
            string result;

            if (words[0] == "") return "Файл пуст";


            result = NormalizeWord(words[0], valueNumber);
            result += NormalizeWord(words[1], valueDataAdd);
            result += NormalizeWord(words[2], valueName);
            result += NormalizeWord(words[3], valueAge);
            result += NormalizeWord(words[4], valueHeight);
            result += NormalizeWord(words[5], valueDataBirth);
            result += NormalizeWord(words[6], valueTown);

            return result;
        }

        /// <summary>
        /// приводит строку к необходипой длине(обрезает конец или добавляет пробелы)
        /// </summary>
        /// <param name="word">строка приводимая к необходимой длине</param>
        /// <param name="lenghtWord">необходимая длина строки</param>
        /// <returns>строка приведённая к необходимой длине</returns>
        static string NormalizeWord(string word, int lenghtWord)
        {
            string result = word;
            if (word.Length > lenghtWord)
            {
                result = word.Substring(0, lenghtWord);
            }
            if (word.Length < lenghtWord)
            {
                while (result.Length < lenghtWord)
                {
                    result += " ";
                }
            }
            return result;

        }

        /// <summary>
        /// метод для сбора данных о сотруднике
        /// </summary>
        /// <returns>Работник с заполнеными данными</returns>
        static Worker FillingForm()
        {
            Worker worker;
            DateTime dataAdd = DateTime.Now;

            Console.WriteLine("введите Ф.И.О. сотрудника");
            string name = Console.ReadLine();

            Console.WriteLine("введите возраст сотрудника");
            int age = -1;
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
            }
            catch { }


            Console.WriteLine("введите рост сотрудника");
            int lenght = -1;
            try
            {
                lenght = Convert.ToInt32(Console.ReadLine());
            }
            catch { }

            Console.WriteLine("введите дату рождения сотрудника");
            DateTime dateBirth = new DateTime(2000, 1, 1, 0, 0, 0);
            try
            {
                dateBirth = Convert.ToDateTime(Console.ReadLine());
            }
            catch { }

            Console.WriteLine("введите место рождения сотрудника");
            string placeBirth = Console.ReadLine();

            if (name == null)
                worker = new Worker(-1);
            else
            {
                if (dateBirth == null)
                    worker = new Worker(-1, name);
                else
                {
                    if (placeBirth == null)
                        worker = new Worker(-1, dataAdd, name, dateBirth);
                    else
                    {
                        if(lenght==-1)
                            worker = new Worker(-1, dataAdd, name, dateBirth,placeBirth);
                        else
                        {
                            if (age == -1)
                                worker = new Worker(-1, dataAdd, name, lenght, dateBirth, placeBirth);
                            else
                                worker = new Worker(-1, dataAdd, name, age, lenght, dateBirth, placeBirth);
                        }
                    }
                }
            }
            return worker;
        }
    }
}