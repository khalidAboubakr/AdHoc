using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Infrastructure.EntityFramework.Framework.Data.Context
{
    public class DataContext : DbContext
    {
        #region CSt

        public DataContext() //: base("name=Models")
        {
            HandleReferences();
            Database.Connection.ConnectionString = Xdb.Settings.Connections("Infrastructure.DB.AdHoc");
        }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region entities.

            modelBuilder.Configurations.Add(new DataContextConfigurations.EmployeeConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.DepartmentConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.DepartmentManagerHistoryConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.QuartersLookupConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.YearLookupConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.AnswerConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.QuestionConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.AtemptScoreConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.C_QuizActivatationConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.EmployeeQuizConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.EmployeeQuizAtemptConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.QuizConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.QuizAtemptAnswerConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.QuizExpireMetaDataConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.QuizQuestionConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.QuizTimeOutMetaDataConfiguration());
            modelBuilder.Configurations.Add(new DataContextConfigurations.TopicConfiguration());
            
            #endregion

            #region settings

            base.OnModelCreating(modelBuilder);

            #endregion
        }

        #endregion

        #region Props

        public virtual DbSet<QuizActivatation> QuizActivatation { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AtemptScore> AtemptScores { get; set; }
        public virtual DbSet<DepartmentManagerHistory> DepartmentManagerHistories { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeQuiz> EmployeeQuizs { get; set; }
        public virtual DbSet<EmployeeQuizAtempt> EmployeeQuizAtempts { get; set; }
        public virtual DbSet<QuartersLookup> QuartersLookups { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizs { get; set; }
        public virtual DbSet<QuizAtemptAnswer> QuizAtemptAnswers { get; set; }
        public virtual DbSet<QuizExpireMetaData> QuizExpireMetaDatas { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }
        public virtual DbSet<QuizTimeOutMetaData> QuizTimeOutMetaDatas { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<YearLookup> YearLookups { get; set; }

        #endregion

        #region Helpers

        private static class Xdb
        {
            #region Nested

            public static class Settings
            {
                public static string Connection { get; private set; }

                public static string Connections(string connectionName)
                {
                    try
                    {
                        var connectionstring = XConfig.GetConnectionString(connectionName);
                        if (connectionstring.Contains("Catalog"))
                            return connectionstring;
                        return connectionstring;
                    }
                    catch (Exception x)
                    {
                        //Log
                        return null;
                    }
                }
            }

            #endregion
        }

        private static class XConfig
        {
            public static string GetValue(string key)
            {
                return ConfigurationManager.AppSettings[key];
            }

            public static string GetConnectionString(string key)
            {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
        }

        private void HandleReferences()
        {
            var x = typeof(SqlProviderServices);
            var y = x.ToString();
        }

        #endregion
    }
}