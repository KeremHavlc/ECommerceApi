using AutoMapper;
using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using System.Reflection.Metadata.Ecma335;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IOrderDal _orderDal;
        private readonly IMapper _mapper;
        private readonly IProductDal _productDal;
        private readonly IUserDal _userDal;
        private readonly IOrderItemDal _orderItemDal;
        public CommentManager(ICommentDal commentDal, IOrderDal orderDal,IMapper mapper , IProductDal productdal,IUserDal userDal, IOrderItemDal orderItemDal)
        {
            _commentDal = commentDal;
            _orderDal = orderDal;
            _mapper = mapper;
            _productDal = productdal;
            _userDal = userDal;
            _orderItemDal = orderItemDal;
        }

        public Result Add(CommentDto commentDto)
        {
            try
            {
                var completedOrders = _orderDal.GetAll(o =>
                    o.UserId == commentDto.UserId &&
                    o.Status == "completed");

                if (completedOrders == null || !completedOrders.Any())
                {
                    return new ErrorResult("You can only comment after completing the order.");
                }

                var completedOrderIds = completedOrders.Select(o => o.Id).ToList();

                var orderItems = _orderItemDal.GetAll(oi =>
                    completedOrderIds.Contains(oi.OrderId) &&
                    oi.ProductId == commentDto.ProductId);

                if (!orderItems.Any())
                {
                    return new ErrorResult("You must complete a purchase for this product before commenting.");
                }

                var newComment = _mapper.Map<Comment>(commentDto);
                _commentDal.Add(newComment);
                return new SuccessResult("Comment added successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }


        public Result Delete(Guid commentId)
        {
            try
            {
                var comment = _commentDal.Get(c => c.Id == commentId);
                if(comment == null)
                {
                    return new ErrorResult("Comment not found!");
                }
                _commentDal.Delete(comment);
                return new SuccessResult("Comment deleted successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }

        public DataResult<List<CommentDto>> GetAllCommentByProductId(Guid productId)
        {
            try
            {
                var product = _productDal.Get(p => p.Id == productId);
                if(product == null)
                {
                    return new ErrorDataResult<List<CommentDto>>("Product not found!");
                }
                var comments = _commentDal.GetAll(c => c.ProductId == productId);
                if(comments == null)
                {
                    return new ErrorDataResult<List<CommentDto>>("Comments not found by product!");
                }
                var commentDtos = _mapper.Map<List<CommentDto>>(comments);
                return new SuccessDataResult<List<CommentDto>>(commentDtos, "Comments retrieved successfully!");
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CommentDto>>("Something went wrong!");
            }
        }

        public DataResult<List<CommentDto>> GetAllCommentByUserId(Guid userId)
        {
            try
            {
                var user = _userDal.Get(u => u.Id == userId);
                if(user == null)
                {
                    return new ErrorDataResult<List<CommentDto>>("User not found!");
                }
                var comments = _commentDal.GetAll(c => c.UserId == userId);
                if(comments == null)
                {
                    return new ErrorDataResult<List<CommentDto>>("Comments not found!");
                }
                var newCommentDto = _mapper.Map<List<CommentDto>>(comments);
                return new SuccessDataResult<List<CommentDto>>(newCommentDto, "Comment listed successfully!");
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CommentDto>>("Something went wrong!");
            }
        }

        public Result Update(CommentDto commentDto, Guid commentId)
        {
            try
            {
                var comment = _commentDal.Get(c => c.Id == commentId);
                if (comment == null)
                {
                    return new ErrorResult("Comment not found!");
                }
                var order = _orderDal.Get(o => o.UserId == commentDto.UserId);
                if (order == null)
                {
                    return new ErrorResult("Order not found!");
                }
                if (order.Status == "pending")
                {
                    return new ErrorResult("You cannot update a comment on a pending order!");
                }
                _mapper.Map(commentDto, comment);

                _commentDal.Update(comment);

                return new SuccessResult("Comment updated successfully!");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Something went wrong!");
            }
        }
       
    }
}
