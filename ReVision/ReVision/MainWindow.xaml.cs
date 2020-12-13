
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
        TextBox AddPropositionTextBox;


        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Get all subjects from json db file.
            AllSubjects = JsonRevisionHelper.ReadSubjects();
            AddSubjectButtonForEachSubject();
        }

        public void MainWindow_Closing(object sender, EventArgs e)
        {
            JsonRevisionHelper.WriteSubjects(AllSubjects);
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

        public void AddNewAnswerElements()
        {
            StackPanel AddPropositionSP = new StackPanel();
            AddPropositionSP.Orientation = Orientation.Horizontal;

            AddPropositionTextBox = new TextBox();
            AddPropositionTextBox.Name = "NewPropositionTitle";
            AddPropositionTextBox.Width = 200;

            Button addFalseAnswerButton = new Button();
            addFalseAnswerButton.Content = "Add false answer";
            addFalseAnswerButton.Click += AddFalseAnswer;

            Button addOrModifyAnswerButton = new Button();
            addOrModifyAnswerButton.Content = "Add or modify answer";
            addOrModifyAnswerButton.Click += AddOrModifyAnswer;

            AddPropositionSP.Children.Add(AddPropositionTextBox);
            AddPropositionSP.Children.Add(addFalseAnswerButton);
            AddPropositionSP.Children.Add(addOrModifyAnswerButton);

            AnswerSP.Children.Add(AddPropositionSP);

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
            RefreshUi();

        }
        private void AddQuestion(object sender, RoutedEventArgs e)
        {
            QAModel newQuestion = new QAModel();
            newQuestion.Question = AddQuestionTextBox.Text;
            currentSubject.Qas.Add(newQuestion);
            RefreshUi();


        }
        private void AddOrModifyAnswer(object sender, RoutedEventArgs e)
        {
            Proposition newAnswer = new Proposition();
            newAnswer.PropositionTitle = AddPropositionTextBox.Text;
            currentQuestion.Answer = newAnswer;
            RefreshUi();
        }
        private void AddFalseAnswer(object sender, RoutedEventArgs e)
        {
            Proposition newFalseAnswer = new Proposition();
            newFalseAnswer.PropositionTitle = AddPropositionTextBox.Text;
            currentQuestion.FalsePropositions.Add(newFalseAnswer);
            RefreshUi();
        }

        #endregion

        #region Functions relative to UI of selecting elements (subjets, questions, answers)

        public void AddSubjectButtonForEachSubject()
        {
            

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

            AddNewAnswerElements();
        }

        #endregion

        #region Functions triggered when selection buttons clicked
        private void subjectButtonClicked(object sender, RoutedEventArgs e)
        {
            var subjectTitleOfButtonClicked = (e.Source as Button).Content.ToString();
            Subject selectedSub = AllSubjects.Find(x => x.Name == subjectTitleOfButtonClicked);
            currentSubject = selectedSub;
            currentQuestion = null;
            RefreshUi();
        }

        private void questionButtonClicked(object sender, RoutedEventArgs e)
        {
            var questionTitleOfButtonClicked = (e.Source as Button).Content.ToString();
            QAModel selectedQuestion = currentSubject.Qas.Find(x => x.Question == questionTitleOfButtonClicked);
            currentQuestion = selectedQuestion;
            RefreshUi();
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

        #region Functions relative to refreshing data and ui
        
        private void RefreshUi()
        {
            SubjectSP.Children.Clear();
            QuestionSP.Children.Clear();
            AnswerSP.Children.Clear();

            AddSubjectButtonForEachSubject();

            if (currentSubject != null )
            {
                AddQuestionButtonForEachQuestion();
            }

            if (currentQuestion != null )
            {
                AddAnswerButtonForEachAnswer();
            }
        }

        #endregion
    }
}
