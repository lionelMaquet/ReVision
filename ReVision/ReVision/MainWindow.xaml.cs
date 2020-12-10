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

        public MainWindow()
        {
            InitializeComponent();
            Data = new SampleData();

            // adds a subject button for all subjects in dataset
            foreach (Subject sub in Data.allSubjects)
            {
                Button newSubjectButton = new Button();
                newSubjectButton.Content = sub.name;
                newSubjectButton.Click += subjectButtonClicked;
                SubjectSP.Children.Add(newSubjectButton);
            }
        }

        private void subjectButtonClicked(object sender, RoutedEventArgs e)
        {
            QuestionSP.Children.Clear();

            var subjectTitleOfButtonClicked = (e.Source as Button).Content.ToString();
            
            Subject selectedSub = Data.allSubjects.Find(x => x.name == subjectTitleOfButtonClicked);
            currentSubject = selectedSub;

            // adds the questions for all questions in current selected subject
            foreach ( QAModel qa in selectedSub.qas)
            {
                Button questionButton = new Button();
                questionButton.Content = qa.question;
                questionButton.Click += questionButtonClicked;
                QuestionSP.Children.Add(questionButton);

            }
        }

        private void questionButtonClicked(object sender, RoutedEventArgs e)
        {
            
            AnswerSP.Children.Clear();
            
            var questionTitleOfButtonClicked = (e.Source as Button).Content.ToString();
            QAModel selectedQuestion = currentSubject.qas.Find(x => x.question == questionTitleOfButtonClicked);
            currentQuestion = selectedQuestion;

            List<Proposition> allProps = new List<Proposition>(selectedQuestion._falsePropositions);
            
            // insert true answer in random position
            int randomPos = new Random().Next(0, allProps.Count + 1);
            allProps.Insert(randomPos, selectedQuestion.answer);

            // adds the answers for the current selected question
            foreach(Proposition prop in allProps)
            {
                Button propButton = new Button();
                propButton.Content = prop.proposition;
                propButton.Click += answerButtonClicked;
                AnswerSP.Children.Add(propButton);
            }

        }

        private void answerButtonClicked(object sender, RoutedEventArgs e)
        {
            var selectedAnswer = (e.Source as Button).Content.ToString();
            string trueAnswer = currentQuestion.answer.proposition;
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
