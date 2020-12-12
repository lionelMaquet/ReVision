
using ReVision.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReVision
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        SampleData Data;
        Subject currentSubject;
        QAModel currentQuestion;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Data = new SampleData();

            // adds a subject button for all subjects in dataset
            foreach (Subject sub in Data.allSubjects)
            {
                Button newSubjectButton = new Button();
                newSubjectButton.Content = sub.Name;
                newSubjectButton.Style = this.FindResource("ButtonStyle") as Style;
                newSubjectButton.Click += subjectButtonClicked;
                SubjectSP.Children.Add(newSubjectButton);
            }

            
        }

        private void subjectButtonClicked(object sender, RoutedEventArgs e)
        {
            QuestionSP.Children.Clear();

            var subjectTitleOfButtonClicked = (e.Source as Button).Content.ToString();

            Subject selectedSub = Data.allSubjects.Find(x => x.Name == subjectTitleOfButtonClicked);
            currentSubject = selectedSub;

            // adds the questions for all questions in current selected subject
            foreach (QAModel qa in selectedSub.Qas)
            {
                Button questionButton = new Button();
                questionButton.Content = qa.Question;
                questionButton.Style = this.FindResource("ButtonStyle") as Style;
                questionButton.Click += questionButtonClicked;
                QuestionSP.Children.Add(questionButton);

            }

            
           
        }

        private void questionButtonClicked(object sender, RoutedEventArgs e)
        {
            
            AnswerSP.Children.Clear();
            
            var questionTitleOfButtonClicked = (e.Source as Button).Content.ToString();
            QAModel selectedQuestion = currentSubject.Qas.Find(x => x.Question == questionTitleOfButtonClicked);
            currentQuestion = selectedQuestion;

            List<Proposition> allProps = new List<Proposition>(selectedQuestion.FalsePropositions);
            
            // insert true answer in random position
            int randomPos = new Random().Next(0, allProps.Count + 1);
            allProps.Insert(randomPos, selectedQuestion.Answer);

            // adds the answers for the current selected question
            foreach(Proposition prop in allProps)
            {
                Button propButton = new Button();
                propButton.Style = this.FindResource("ButtonStyle") as Style;
                propButton.Content = prop.PropositionTitle;
                propButton.Click += answerButtonClicked;
                AnswerSP.Children.Add(propButton);
            }

        }

        private void answerButtonClicked(object sender, RoutedEventArgs e)
        {
            var selectedAnswer = (e.Source as Button).Content.ToString();
            string trueAnswer = currentQuestion.Answer.PropositionTitle;
            if (selectedAnswer == trueAnswer)
            {
                SelectedAnswerResult.Text = "correct !";
            } else
            {
                SelectedAnswerResult.Text = "INCORRECT !";
            }
        }
    }
}
