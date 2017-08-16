﻿using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers
{
    public class BlogCriadoEventHandler : INotificationHandler<BlogCriadoDomainEvent>
    {
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository _blogWriteOnlyRepository;

        public BlogCriadoEventHandler(
            IBlogReadOnlyRepository blogReadOnlyRepository,
            IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
            _blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }
        public void Handle(BlogCriadoDomainEvent message)
        {
            Blog blog = new Blog(message.AggregateRootId);

            _blogWriteOnlyRepository.Add(blog).ConfigureAwait(true);
        }
    }
}