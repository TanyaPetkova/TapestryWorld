namespace TapestryWorld.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using TapestryWorld.Web.Infrastructure.Mapping;
    using TapestryWorld.Data.Models;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {
        }

        public PostCommentViewModel(int tapestryId)
        {
            this.StitchedTapestryId = tapestryId;
        }

        public int StitchedTapestryId { get; set; }

        [Required]
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}