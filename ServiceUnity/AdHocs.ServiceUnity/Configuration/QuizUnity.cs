using System;
using AdHoc.QuizUnity.Services.Topic.Contract;
using AdHoc.QuizUnity.Services.Topics.Handler;
using AdHoc.QuizUnity.Services.Questions.Handler;
using AdHoc.QuizUnity.Services.Questions.Contract;
using AdHoc.QuizUnity.Services.Quiz.Contract;
using AdHoc.QuizUnity.Services.Quizs.Handler;

namespace AdHoc.QuizUnity.Configuration
{
    public static class QuizBusinessUnity
    {
        #region cst.

        static QuizBusinessUnity()
        {
            Initialized = Initialize();
        }
        #endregion

        #region helpers.

        private static bool Initialize()
        {
            try
            {
                Topics = new TopicHandler();
                Questions = new QuestionHandler();
                Quizs = new QuizsHandler();
                return true;
            }
            catch (Exception)
            {
                //TODO Log
                return false;
            }
        }

        #endregion

        #region props.

        private static bool Initialized { get; }

        public static ITopicHandler Topics { get; set; }
        public static IQuestionHandler Questions { get; set; }
        public static IQuizsHandler Quizs { get; set; }
        
        #endregion
    }
}