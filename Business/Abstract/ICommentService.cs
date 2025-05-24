using Core.Dtos;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICommentService
    {
        Result Add(CommentDto commentDto);
        DataResult<List<CommentDto>> GetAllCommentByProductId(Guid productId);
        DataResult<List<CommentDto>> GetAllCommentByUserId(Guid userId);
        Result Delete(Guid commentId);
        Result Update(CommentDto commentDto, Guid commentId);
    }
}
