using AdHoc.Shared.Base;

namespace AdHoc.Shared.Dto.Criteria
{
    public class AnswersSearchCriteriaDto : SearchCriteriaDto
    {
        #region Enums
        //public enum OrderByExepression
        //{
        //    Id = 0,
        //    Name = 1,
        //    TopicId = 2,
        //    QuestionId = 3
        //}
        #endregion
        #region Props.

        public string Name { get; set; }
        public int TopicId { get; set; }
        public int QuestionId { get; set; }
        public int? OrderBy { get; set; }

        #endregion
    }
}
