
using ReVision.Helper;
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

        Subject currentSubject;
        QAModel currentQuestion;
        List<Subject> AllSubjects;

        TextBox AddSubjectTextBox;
        TextBox AddQuestionTextBox;


        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Get all subjects from json db file.
            AllSubjects = JsonRevisionHelper.ReadSubjects();
            AddSubjectButtonForEachSubject();

        }

        #region Functions relative to UI of ADDING elements in DB (subjets, questions, answers)
        public void AddNewSubjectElements()
        {
            // adds the textbox and button for adding subject
            StackPanel addSubjectSP = new StackPanel();
            addSubjectSP.Orientation = Orientation.Horizontal;

            AddSubjectTextBox = new TextBox();
            AddSubjectTextBox.Name = "NewSubjectTitle";
            AddSubjectTextBox.Width = 60;

            Button addSubjectButton = new Button();
            addSubjectButton.Content = "Add Subject";
            addSubjectButton.Click += AddSubject;
            addSubjectSP.Children.Add(AddSubjectTextBox);
            addSubjectSP.Children.Add(addSubjectButton);

            SubjectSP.Children.Add(addSubjectSP);
        }

        public void AddNewQuestionElements()
        {
            // adds the textbox and button for adding question
            StackPanel addQuestionSP = new StackPanel();
            addQuestionSP.Orientation = Orientation.Horizontal;

            AddQuestionTextBox = new TextBox();
            AddQuestionTextBox.Name = "NewQuestionTitle";
            AddQuestionTextBox.Width = 60;

            Button addQuestionButton = new Button();
            addQuestionButton.Content = "Add Question";
            addQuestionButton.Click += AddQuestion;

            addQuestionSP.Children.Add(AddQuestionTextBox);
            addQuestionSP.Children.Add(addQuestionButton);

            QuestionSP.Children.Add(addQuestionSP);
        }

        #endregion

        #region Functions relative to ADDING elements in DB (subjets, questions, answers)

        private void AddSubject(object sender, RoutedEventArgs e)
        {
            Subject newSubject = new Subject()
            {
                Name = AddSubjectTextBox.Text
            };

            AllSubjects.Add(newSubject);
            RefreshData();

        }
        private void AddQuestion(object sender, RoutedEventArgs e)
        {
            QAModel newQuestion = new QAModel();
            newQuestion.Question = AddQuestionTextBox.Text;
            currentSubject.Qas.Add(newQuestion);
            RefreshData();
            AddQuestionButtonForEachQuestion();

        }

        #endregion

        #region Functions relative to UI of selecting elements (subjets, questions, answers)

        public void AddSubjectButtonForEachSubject()
        {
            SubjectSP.Children.Clear();

            foreach (Subject sub in AllSubjects)
            {
                Button newSubjectButton = new Button();
                newSubjectButton.Content = sub.Name;
                newSubjectButton.Style = this.FindResource("ButtonStyle") as Style;
                newSubjectButton.Click += subjectButtonClicked;
                SubjectSP.Children.Add(newSubjectButton);
            }

            AddNewSubjectElements();
        }
        public void AddQuestionButtonForEachQuestion()
        {
            QuestionSP.Children.Clear();
            foreach (QAModel qa in currentSubject.Qas)
            {
                Button questionButton = new Button();
                questionButton.Content = qa.Question;
                questionButton.Style = this.FindResource("ButtonStyle") as Style;
                questionButton.Click += questionButtonClicked;
                QuestionSP.Children.Add(questionButton);

            }
            AddNewQuestionElements();

        }
        public void AddAnswerButtonForEachAnswer()
        {
            AnswerSP.Children.Clear();

            List<Proposition> allProps = new List<Proposition>(currentQuestion.FalsePropositions);

            // insert true answer in random position
            int randomPos = new Random().Next(0, allProps.Count + 1);
            allProps.Insert(randomPos, currentQuestion.Answer);

            // adds the answers for the current selected question
            foreach (Proposition prop in allProps)
            {
                Button propButton = new Button();
                propButton.Style = this.FindResource("ButtonStyle") as Style;
                propButton.Content = prop.PropositionTitle;
                propButton.Click += answerButtonClicked;
                AnswerSP.Children.Add(propButton);
            }
        }

        #endregion

        #region Functions triggered when selection buttons clicked
        private void subjectButtonClicked(object sender, RoutedEventArgs e)
        {
            var subjectTitleOfButtonClicked = (e.Source as Button).Content.ToString();
            Subject selectedSub = AllSubjects.Find(x => x.Name == subjectTitleOfButtonClicked);
            currentSubject = selectedSub;
            AddQuestionButtonForEachQuestion();
        }

        private void questionButtonClicked(object sender, RoutedEventArgs e)
        {
            var questionTitleOfButtonClicked = (e.Source as Button).Content.ToString();
            QAModel selectedQuestion = currentSubject.Qas.Find(x => x.Question == questionTitleOfButtonClicked);
            currentQuestion = selectedQuestion;
            AddAnswerButtonForEachAnswer();
        }

        private void answerButtonClicked(object sender, RoutedEventArgs e)
        {
            var selectedAnswer = (e.Source as Button).Content.ToString();
            string trueAnswer = currentQuestion.Answer.PropositionTitle;
            if (selectedAnswer == trueAnswer)
            {
                SelectedAnswerResult.Text = "correct !";
            }
            else
            {
                SelectedAnswerResult.Text = "INCORRECT !";
            }

        }

        #endregion
        private void RefreshData()
        {
            AllSubjects = JsonRevisionHelper.RewriteAndReload(AllSubjects);
            AddSubjectButtonForEachSubject();
        }
    }
}
