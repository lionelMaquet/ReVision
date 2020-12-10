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
        string currentSubject;

        public MainWindow()
        {
            InitializeComponent();
            Data = new SampleData();
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
            currentSubject = subjectTitleOfButtonClicked;
            Subject selectedSub = Data.allSubjects.Find(x => x.name == currentSubject);

            foreach( QAModel qa in selectedSub.qas)
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
            Subject selectedSub = Data.allSubjects.Find(x => x.name == currentSubject);
            var questionTitleOfButtonClicked = (e.Source as Button).Content.ToString();
            QAModel selectedQuestion = selectedSub.qas.Find(x => x.question == questionTitleOfButtonClicked);


            List<Proposition> allProps = new List<Proposition>(selectedQuestion._falsePropositions);

            int randomPos = new Random().Next(0, 3);
            allProps.Insert(randomPos, selectedQuestion.answer);

            foreach(Proposition prop in allProps)
            {
                Button propButton = new Button();
                propButton.Content = prop.proposition;
                AnswerSP.Children.Add(propButton);
            }

        }
    }
}
