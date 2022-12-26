using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGUI
{
    internal class CustomTask
    {
        public int Id { get; set; }

        public string TaskText { get; set; }

        public string TaskPicture { get; set; }

        public string Answer { get; set; }

        public int Subtheme { get; set; }

        public int TaskSolutionId { get; set; }

        public int Difficulty { get; set; }

        public int SolutionId { get; set; }

        public string SolutionText { get; set; }

        public string SolutionPicture { get; set; }

        public CustomTask(int id, string taksText, string taskPicture, string answer, int subtheme, int taskSolutionId, int difficulty, int solutionId, string solutionText, string solutionPicture)
        {
            Id = id;
            TaskText = taksText;
            TaskPicture = taskPicture;
            Answer = answer;
            Subtheme = subtheme;
            TaskSolutionId = taskSolutionId;
            Difficulty = difficulty;
            SolutionId = solutionId;
            SolutionText = solutionText;
            SolutionPicture = solutionPicture;
        }
    }
}
