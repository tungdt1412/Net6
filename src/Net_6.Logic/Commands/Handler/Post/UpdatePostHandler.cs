﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Handler
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost,
        BaseCommandResultWithData<Post>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdatePostHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public Task<BaseCommandResultWithData<Post>> Handle(
            UpdatePost request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Post>();

            try
            {
                var post = database.Post.FirstOrDefault(x => x.Id == request.Id);

                if (post != null)
                {
                    mapper.Map(request, post);
                    post.SetUpdateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.Update(post);

                    if (request.Tags != null)
                    {
                        var oldPostTags = database.PostTags.Where(x => x.PostId == post.Id);
                        database.RemoveRange(oldPostTags);

                        var postTags = request.Tags.Select(x => new PostTag()
                        {
                            PostId = post.Id,
                            TagId = x.Id,
                            CreatedAt = AppGlobal.SysDateTime,
                            CreatedBy = request.UserName,
                        });

                        database.PostTags.AddRange(postTags);
                    }

                    if (request.Categories != null)
                    {
                        var oldPostCategories = database.PostCategories.Where(x => x.PostId == post.Id);
                        database.RemoveRange(oldPostCategories);

                        var postCategories = request.Categories.Select(x => new PostCategory()
                        {
                            PostId = post.Id,
                            CategoryId = x.Id,
                            CreatedAt = AppGlobal.SysDateTime,
                            CreatedBy = request.UserName,
                        });

                        database.PostCategories.AddRange(postCategories);
                    }

                    if (request.Relates != null)
                    {
                        var oldPostRelates = database.PostRelateds.Where(x => x.PostId == post.Id);
                        database.RemoveRange(oldPostRelates);

                        var postRelates = request.Relates.Select(x => new PostRelated()
                        {
                            PostId = post.Id,
                            RelatedId = x.Id,
                            CreatedAt = AppGlobal.SysDateTime,
                            CreatedBy = request.UserName,
                        });

                        database.PostRelateds.AddRange(postRelates);
                    }

                    database.SaveChanges();

                    result.Success = true;
                    result.Data = post;
                }
                else
                {
                    result.Messages = $"Can't not find post with id is {request.Id}";
                }
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }

            return Task.FromResult(result);
        }
    }
}
