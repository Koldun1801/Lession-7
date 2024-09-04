using System;
using System.Collections.Generic;
using System.IO;


namespace Lesson_7
{
    class Repository
    {
        //private int lastId = 0;
        private string path = "Repository.csv";
        
        /// <summary>
        /// Чтение списка работников
        /// </summary>
        /// <returns>список работников</returns>
        public Worker[] GetAllWorkers()
        {
            int count = 1;
            Worker[] workers;
            string[] allLines;
                allLines = File.ReadAllLines(path);
                count = allLines.Length;
                workers = new Worker[count];
                for (int i = 0; i < allLines.Length; i++)
                    workers[i] = StringToWorker(allLines[i]);
            //lastId = workers[workers.Length - 1].ID();
            return workers;
        }

        /// <summary>
        /// Работник по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Worker с необходимым ID( ID= -1 если работник не найден)</returns>
        public Worker GetWorkerById(int id)
        {
            Worker[] workers = GetAllWorkers();
            foreach (Worker worker in workers)
                if (id == worker.ID())
                    return worker;
            Worker result=new Worker(-1);
            return result;
        }

        /// <summary>
        /// Удаление Worker по ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(int id)
        {
            Worker[] workers = GetAllWorkers();
            string allText = "";
            for(int i = 0;i<workers.Length;i++)
            {
                if (workers[i].ID() != id)
                    allText += workers[i].ToStringWorker()+"\n";
            }
            File.WriteAllText(path, allText);
        }

        /// <summary>
        /// Добавление Worker в файл
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            worker.ReplaceId(LastId() + 1);
            File.AppendAllText(path, worker.ToStringWorker()+"\n");
        }

        /// <summary>
        /// Список добавленых между датами
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workersIn = GetAllWorkers();
            List<Worker> workers = new List<Worker> { };
            foreach(Worker worker in workersIn)
            {
                if((dateFrom<=worker.dateAdd) && (dateTo>=worker.dateAdd))
                {
                    workers.Add(worker);
                }
            }

            Worker[] workersResult = new Worker[workers.Count];
            for(int i = 0; i<workers.Count;i++)
            {
                workersResult[i] = workers[i];
            }
            return workersResult;
        }

        /// <summary>
        /// ID последнего Worker
        /// </summary>
        /// <returns></returns>
        private int LastId()
        {
            if (File.Exists(path))
            {
                Worker[] workers = GetAllWorkers();
                return workers[workers.Length - 1].ID();
            }
            return 0;
        }

        /// <summary>
        /// Сорировка на случай замены ID
        /// </summary>
        /// <param name="workers"></param>
        /// <returns></returns>
        private Worker[] SortAllWorker(Worker[] workers)
        {
            Array.Sort(workers, (worker1, worker2) => worker1.ID().CompareTo(worker2.ID()));
            return workers;
        }
        private Worker StringToWorker(string stringLine)
        {
            Worker worker;
            string[] filds = stringLine.Split('#');
            if (filds.Length >= 7)
                worker = new Worker(Convert.ToInt32(filds[0]),
                                    Convert.ToDateTime(filds[1]),
                                    filds[2],
                                    Convert.ToInt32(filds[3]),
                                    Convert.ToInt32(filds[4]),
                                    Convert.ToDateTime(filds[5]),
                                    filds[6]);
            else
                worker = new Worker(-1);

            return worker;
        }
    }
}
